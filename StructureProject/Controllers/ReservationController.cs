using Microsoft.AspNet.Identity;
using StructureProject.Models;
using StructureProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StructureProject.Controllers
{
    [Authorize]

    public class ReservationController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public ReservationController()
        {
            context = new ApplicationDbContext();
        }


        public ActionResult Show()
        {

            var identityId = User.Identity.GetUserId();

            if (identityId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

           var myReservations = context.Reservations
                .Include(s=> s.Host)
                .Include(s=> s.Customer)
                .Include(s => s.Pet)
                .Include(s=>s.Pet.Kind)
                .Where(s => s.Customer.IdentityUserId == identityId)
                .ToList();

            var myReservationsWithHostMe = context.Reservations
                .Include(s => s.Host)
                .Include(s => s.Customer)
                .Include(s =>s.Pet)
                .Include(s => s.Pet.Kind)
                .Where(s => s.Host.IdentityUserId == identityId)
                .ToList();

            return View("ReservationList", new ReservationsShowViewModel(myReservations,myReservationsWithHostMe));
        }
        public ActionResult Make()
        {
            return View(new ReservationViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Make(ReservationViewModel viewModel)
        {
            var identityId = User.Identity.GetUserId();

            if (identityId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = context.Persons.Where(s => s.IdentityUserId == identityId).SingleOrDefault();
            var host = context.Persons.Where(s => s.Id == viewModel.HostId).SingleOrDefault();
            var pet = context.Pets.Where(s => s.Id == viewModel.PetId).SingleOrDefault();
            var newReservation = new Reservation(host, user, pet, viewModel.Date, viewModel.Price, Acceptance.Waiting);

            var newNotification = newReservation.GetNotification();

            context.HostNotifications.Add(new HostNotification(user, newNotification, pet, host));
            context.Reservations.Add(newReservation);

            context.SaveChanges();

            TempData["Reservation"] = "Made";

            return RedirectToAction("Show");        
        }
    }
}
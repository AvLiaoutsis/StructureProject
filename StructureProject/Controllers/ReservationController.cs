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

            var PersonToUpdate = context.Persons.Where(s => s.IdentityUserId == identityId).SingleOrDefault();
            var hostToUpdate = context.Persons.Where(s => s.Id == viewModel.HostId).SingleOrDefault();
            var PetToUpdate = context.Pets.Where(s => s.Id == viewModel.PetId).SingleOrDefault();


            context.Reservations.Add(new Reservation(hostToUpdate, PersonToUpdate, PetToUpdate, viewModel.Date,viewModel.Price, Acceptance.Waiting));
            context.SaveChanges();

            TempData["Reservation"] = "Made";

            return RedirectToAction("Show");        
        }
    }
}
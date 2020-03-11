using Microsoft.AspNet.Identity;
using StructureProject.Models;
using StructureProject.ViewModels;
using System;
using System.Collections.Generic;
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

        // GET: Reservation
        public ActionResult Make()
        {
            var viewModel = new ReservationViewModel();
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Make(ReservationViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }

            var identityId = User.Identity.GetUserId();

            if (identityId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var PersonToUpdate = context.Persons.Where(s => s.IdentityUserId == identityId).SingleOrDefault();
            var hostToUpdate = context.Persons.Where(s => s.Id == viewModel.HostId).SingleOrDefault();


            var reservation = new Reservation()
            {
                Customer = PersonToUpdate,
                Date = viewModel.Date,
                Host = hostToUpdate
            };
            context.Reservations.Add(reservation);
            context.SaveChanges();

            TempData["Reservation"] = "Made";

            return RedirectToAction("Index", "Home");        
        }
    }
}
using StructureProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;


namespace StructureProject.Controllers
{
    [Authorize]
    public class HostController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public HostController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Host
        public ActionResult Edit()
        {
            var identityId = User.Identity.GetUserId();


            var hosting = context.HostInfos.Include(s=>s.Person)
                .Where(s => s.Person.IdentityUserId == identityId).SingleOrDefault();

            if (hosting is null)
            {
                hosting = new HostInfo();
            }
            return View(hosting);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HostInfo info)
            {
            if (info.Id == 0)
            {
                var identityId = User.Identity.GetUserId();

                var personInDb = context.Persons.Single(m => m.IdentityUserId == identityId);

                var newHosting = info;

                newHosting.Person = personInDb;

                context.HostInfos.Add(newHosting);
            }

            else //Update
            {
                var hostInDb = context.HostInfos.Single(m => m.Id == info.Id);

                hostInDb.StartDateTime = info.StartDateTime;
                hostInDb.EndDateTime = info.EndDateTime;
                hostInDb.Price = info.Price;

            }
            context.SaveChanges();
            TempData["UpdateHost"] = "Updated";

            return RedirectToAction("Index", "Home");
        }
    }
}
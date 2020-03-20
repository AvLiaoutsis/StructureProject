using Microsoft.AspNet.Identity;
using StructureProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StructureProject.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public ContactController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Edit()
        {
            
            var identityId = User.Identity.GetUserId();
           
            //var person = context.Persons.SingleOrDefault(s => s.IdentityUserId == identityId);

            var contact = context.ContactInfos.Where(s => s.Person.IdentityUserId == identityId).SingleOrDefault();

            //if (contact == null)
            //{
            //    return HttpNotFound();
            //}
            if (contact is null)
            {
                contact = new ContactInfo();
            }


            return View(contact);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ContactInfo info)
        {

            if(info.Id == 0)
            {
                var identityId = User.Identity.GetUserId();

                var person = context.Persons.Single(m => m.IdentityUserId == identityId);

                info.Modify(person);

                context.ContactInfos.Add(info);
            }

            else //Update
            {
                var contactInDb = context.ContactInfos.Single(m => m.Id == info.Id);

                contactInDb.Modify(info.PhoneNumber, info.TelNumber, info.Address, info.PostalCode, info.State, info.City, info.Country);

            }
            context.SaveChanges();
            TempData["Contact"] = "Added";


            return RedirectToAction("Index", "Home");
        }
    }
}
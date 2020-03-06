using Microsoft.AspNet.Identity;
using StructureProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StructureProject.Controllers
{
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

                var personInDb = context.Persons.Single(m => m.IdentityUserId == identityId);

                var newContact = info;

                newContact.Person = personInDb;
                

                context.ContactInfos.Add(newContact);
            }

            else //Update
            {
                var contactInDb = context.ContactInfos.Single(m => m.Id == info.Id);

                contactInDb.Address = info.Address;
                contactInDb.City = info.City;
                contactInDb.Country = info.Country;
                contactInDb.State = info.State;
                contactInDb.PhoneNumber = info.PhoneNumber;
                contactInDb.PostalCode = info.PostalCode;
                contactInDb.TelNumber = info.TelNumber;

            }
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
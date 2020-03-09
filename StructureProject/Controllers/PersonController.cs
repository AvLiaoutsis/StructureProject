using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using StructureProject.Models;
using StructureProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using StructureProject.Helpers;

namespace StructureProject.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        // GET: Person

        public PersonController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult OtherUsers()
        {
            return View();
        }

        //public ActionResult AddPet(Person person)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // I added the first two lines of code below. 
        //        var loggedInUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
        //        person.IdentityUserId = loggedInUser.Id;
        //        person.Name = loggedInUser.Name;
        //        person.LastName = loggedInUser.LastName;
        //        person.BirthDate = loggedInUser.BirthDate;

        //        return RedirectToAction("Index");
        //    }

        //    return View();
        //}
        public ActionResult Edit()
        {
            var identityId = User.Identity.GetUserId();

            var person = context.Persons.SingleOrDefault(s => s.IdentityUserId == identityId);

            if (person == null)
            {
                return HttpNotFound();
            }

            var viewModel = new PersonFormViewModel()
            {
                Person = person
            };

            return View("PersonForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Person person, HttpPostedFileBase file)
        {
            // shit happens
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }

            var fileName = ExtraMethods.UploadPhoto(file);
            person.Avatar = fileName;

            var personInDb = context.Persons.Single(m => m.Id == person.Id);

            personInDb.BirthDate = person.BirthDate;
            personInDb.Description = person.Description;
            personInDb.Name = person.Name;
            personInDb.LastName = person.LastName;
            personInDb.Avatar = person.Avatar;



            context.SaveChanges();


            return RedirectToAction("Index", "Home");
        }

        //[Authorize]
        //public ActionResult Edit()
        //{
        //    var identityId = User.Identity.GetUserId();
        //    if (identityId == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    Person person = context.Persons.Where(s => s.IdentityUserId == identityId).SingleOrDefault();

        //    if (person == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(person);
        //}

        //[Authorize]
        //[HttpPost, ActionName("Edit")]
        //[ValidateAntiForgeryToken]
        //public ActionResult EditPost(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var PersonToUpdate = context.Persons.Find(id);

        //    try
        //    {

        //    }
        //    catch (DataException)
        //    {

        //    }

        //    //if (TryUpdateModel(PersonToUpdate, "", new string[] { "Name", "LastName", "BirthDate"}))
        //    //{
        //    //    try
        //    //    {
        //    //        context.SaveChanges();
        //    //        return RedirectToAction("Index");
        //    //    }
        //    //    catch (DataException)
        //    //    {
        //    //        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
        //    //    }
        //    //}
        //    return RedirectToAction("Index");
        //}

        //public ActionResult AddPet(Person person)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // I added the first two lines of code below. 
        //        var loggedInUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
        //        person.IdentityUserId = loggedInUser.Id;
        //        person.Name = loggedInUser.Name;
        //        person.LastName = loggedInUser.LastName;
        //        person.BirthDate = loggedInUser.BirthDate;

        //        return RedirectToAction("Index");
        //    }

        //    return View();
        //}
        //[Authorize]
        //public ActionResult AddPet()
        //{
        //    var identityId = User.Identity.GetUserId();
        //    if (identityId == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Person person = context.Persons.Where(s => s.IdentityUserId == identityId).SingleOrDefault();
        //    if (person == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(person);
        //}

        //[Authorize]
        //[HttpPost, ActionName("AddPet")]
        //[ValidateAntiForgeryToken]
        //public ActionResult AddPetPost(int? id,Pet pet )
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var PersonToUpdate = context.Persons.Find(id);

        //        try
        //        {
        //        //PersonToUpdate.Pet = pet;
        //        var newPet = new Pet()
        //        {
        //            Name = pet.Name,
        //            Kind = pet.Kind,
        //            Owner = PersonToUpdate
        //        };
        //            context.Pets.Add(newPet);
        //            context.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        catch (DataException)
        //        {
        //            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
        //        }


        //    return RedirectToAction("Index");
        //}

        public ActionResult New()
        {
            return View();
        }
        public ActionResult MyProfile()
        {
            var identityId = User.Identity.GetUserId();

            var contact = context.ContactInfos.Where(s => s.Person.IdentityUserId == identityId).SingleOrDefault();
            var hostInfo = context.HostInfos.Where(s => s.Person.IdentityUserId == identityId).SingleOrDefault();

            if (contact is null)
            {
                contact = new ContactInfo();
            }
            if (hostInfo is null)
            {
                hostInfo = new HostInfo();
            }

            var viewmodel = new PersonDetailsViewModel()
            {
                Owner = context.Persons.Where(s => s.IdentityUserId == identityId).SingleOrDefault(),
                Pets = context.Pets.Where(s => s.Owner.IdentityUserId == identityId).ToList(),
                Contact = contact,
                HostInfo = hostInfo


            };
            return View(viewmodel);
        }
        public ActionResult Details(int id)
        {
            var pets = context.Pets
                        .Where(s => s.Owner.Id == id)
                        .ToList();
            var owner = context.Persons
            .Where(s => s.Id == id)
            .SingleOrDefault();

            //var viewModel = new OwnerWithPetViewModel()
            //{
            //    Owner = person,
            //    Pets = pets
            //};
            var contact = context.ContactInfos.Where(s => s.Person.Id == id).SingleOrDefault();
            var hostInfo = context.HostInfos.Where(s => s.Person.Id == id).SingleOrDefault();

            if (contact is null)
            {
                contact = new ContactInfo();
            }

            if (hostInfo is null)
            {
                hostInfo = new HostInfo();
            }

            var viewmodel = new PersonDetailsViewModel()
            {
                Owner = owner,
                Pets = pets,
                Contact = contact,
                HostInfo = hostInfo
            };

            if (viewmodel == null)
            {
                return HttpNotFound();
            }

            return View(viewmodel);
        }

        public ActionResult Contact(int id)
        {
            var contact = context.ContactInfos.Where(s => s.Person.Id == id).SingleOrDefault();


            if (contact == null)
            {
                return HttpNotFound();
            }

            return View(contact);
        }

        public ActionResult Search()
        {
            var PersonsWithContacts = context.ContactInfos
                .Include(s => s.Person)
                .ToList();

            return View(PersonsWithContacts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string searchstring)
        {
            var PersonsWithContactsSameCity = context.ContactInfos
                 .Include(s => s.Person)
                 .Where(l => l.City.Contains(searchstring) ||
                             l.Country.Contains(searchstring) ||
                             l.Address.Contains(searchstring))
                 .ToList();

            return View(PersonsWithContactsSameCity);




        }

    }
}
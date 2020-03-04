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
        public ActionResult Save(Person person)
        {
            // shit happens
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }

            var personInDb = context.Persons.Single(m => m.Id == person.Id);

            personInDb.BirthDate = person.BirthDate;
            personInDb.Description = person.Description;
            personInDb.Name = person.Name;
            personInDb.LastName = person.LastName;



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
            if (contact is null)
            {
                contact = new ContactInfo();
            }

            var viewmodel = new PersonDetailsViewModel()
            {
                Owner = context.Persons.Where(s => s.IdentityUserId == identityId).SingleOrDefault(),
                Pets = context.Pets.Where(s => s.Owner.IdentityUserId == identityId).ToList(),
                Contact = contact

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
            if(contact is null)
            {
                contact = new ContactInfo();
            }

            var viewmodel = new PersonDetailsViewModel()
            {
                Owner = owner,
                Pets = pets,
                Contact = contact
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

    }
}
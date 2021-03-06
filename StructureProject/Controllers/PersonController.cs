﻿using Microsoft.AspNet.Identity;
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

        public PersonController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult SubmitPrice()
        {
            var userIdentity = User.Identity.GetUserId();

            var personId = context.Persons
                .Where(p => p.IdentityUserId == userIdentity).Single().Id;

            var kindprices = context.PriceKinds
                .Include(k=>k.Kind)
                .Where(p => p.PersonId == personId).ToList();

            return View("PriceForm", new PriceKindViewModel(personId, kindprices));
        }
        //public ActionResult SubmitPrice()
        //{
        //    var viewModel = new PriceFormViewModel()
        //    {
        //        //Kinds = context.Kinds.ToList(),
        //    };

        //    return View("PriceForm", viewModel);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult SubmitPrice(PriceFormViewModel viewModel)
        //{
        //    // shit happens
        //    if (!ModelState.IsValid)
        //    {
        //        return HttpNotFound();
        //    }

        //    var userId = User.Identity.GetUserId();

             
            
        //    //var newprice = new PriceKind()
        //    //{
        //    //    KindId = viewModel.KindId,
        //    //    Kind = context.Kinds.SingleOrDefault(s => s.Id == viewModel.KindId),
        //    //    PersonId = context.Persons.Single(s => s.IdentityUserId == userId).Id,
        //    //    Person = context.Persons.SingleOrDefault(s => s.Id == viewModel.PersonId),
        //    //    Price = viewModel.Price
        //    //};

        //    //context.PriceKinds.Add(newprice);
        //    //Trying add prices based pet kind
        //    //I added one price

        //    return RedirectToAction("Index", "Home");
        //}
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

            return View("PersonForm", person);
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

            var personInDb = context.Persons.Single(m => m.Id == person.Id);

            personInDb.Modify(person.Name, person.LastName, person.BirthDate, person.Description);

            if(!(file is null)) 
            {
                personInDb.Modify(ExtraMethods.UploadPhoto(file));
            }

            context.SaveChanges();
            TempData["UpdatePerson"] = "Added";


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
            var pricesKinds = context.PriceKinds
                .Include(k=>k.Kind)
                .Include(k=>k.Person)
                .Where(s => s.Person.IdentityUserId == identityId).ToList();
            var pets = context.Pets
                .Include(s => s.Kind)
                .Where(s => s.Owner.IdentityUserId == identityId).ToList();
            var person = context.Persons.Where(s => s.IdentityUserId == identityId).SingleOrDefault();

            if (contact is null)
            {
                contact = new ContactInfo();
            }
            if (hostInfo is null)
            {
                hostInfo = new HostInfo();
            }

            return View(new PersonDetailsViewModel(person, contact, pets, hostInfo, pricesKinds));
        }
        public ActionResult Details(int id)
        {
            var pets = context.Pets
                        .Include(s=>s.Kind)
                        .Where(s => s.Owner.Id == id)
                        .ToList();
            var owner = context.Persons
            .Where(s => s.Id == id)
            .SingleOrDefault();

            var pricesKinds = context.PriceKinds
            .Include(k => k.Kind)
            .Include(k => k.Person)
            .Where(s => s.Person.Id == id).ToList();

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

            return View(new PersonDetailsViewModel(owner, contact, pets, hostInfo, pricesKinds));
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
            //var PersonsWithContacts = context.ContactInfos
            //    .Include(s => s.Person)
            //    .ToList();

            //return View(PersonsWithContacts);
            return View();
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
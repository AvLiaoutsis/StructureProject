using Microsoft.AspNet.Identity;
using StructureProject.Helpers;
using StructureProject.Models;
using StructureProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace StructureProject.Controllers
{
    [Authorize]

    public class PetController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public PetController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult ShowPets()
        {
            return View();
        }

        public ViewResult New()
        {
            var viewmodel = new PetFormViewModel()
            {
                Pet = new Pet()
            };
            
            return View("PetForm", viewmodel);
        }
        public ViewResult Details(int id)
        {
            var pet = context.Pets
                .Include(v=>v.Owner)
                .SingleOrDefault(v => v.Id == id);

            return View(pet);
        }
        //[Authorize]
        //public ActionResult AddPet()
        //{

        //    var pet = new Pet();
        //    //var pet = new Pet()
        //    //{
        //    //    Owner = context.Persons.Where(s => s.IdentityUserId == identityId).SingleOrDefault()
        //    //};
        //    //Pet pet = context.Pets.Where(s=>s.Owner.IdentityUserId == identityId).SingleOrDefault();        

        //    //if (pet == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    return View(pet);
        //}

        //[Authorize]
        //[HttpPost, ActionName("AddPet")]
        //[ValidateAntiForgeryToken]
        //public ActionResult AddPetPost(Pet pet)
        //{
        //    var identityId = User.Identity.GetUserId();
        //    if (identityId == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    var PersonToUpdate = context.Persons.Where(s => s.IdentityUserId == identityId).SingleOrDefault();

        //    try
        //    {
        //        //PersonToUpdate.Pet = pet;
        //        var newPet = new Pet()
        //        {
        //            Name = pet.Name,
        //            Kind = pet.Kind,
        //            Owner = PersonToUpdate
        //        };
        //        context.Pets.Add(newPet);
        //        context.SaveChanges();
        //        return RedirectToAction("Index", "Person");
        //    }
        //    catch (DataException)
        //    {
        //        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
        //    }


        //    return RedirectToAction("Index","Person");
        //}
        public ActionResult Edit(int id)
        {
            var pet = context.Pets.SingleOrDefault(s => s.Id == id);

            if (pet == null)
            {
                return HttpNotFound();
            }

            var viewModel = new PetFormViewModel()
            {
                Pet = pet
            };


            return View("PetForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Pet pet,HttpPostedFileBase file)
        {
            //// shit happens
            //if (!ModelState.IsValid)
            //{
            //    var viewModel = new PetFormViewModel()
            //    {
            //        Pet = pet
            //    };

            //    return View("PetForm", viewModel);
            //}
            //Add
            if (pet.Id == 0)
            {
                var identityId = User.Identity.GetUserId();
                if (identityId == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var PersonToUpdate = context.Persons.Where(s => s.IdentityUserId == identityId).SingleOrDefault();

                var fileName = ExtraMethods.UploadPhoto(file);
                pet.Avatar = fileName;

                var newPet = new Pet()
                {
                    Name = pet.Name,
                    Kind = pet.Kind,
                    Age =  pet.Age,
                    Owner = PersonToUpdate,
                    Avatar = pet.Avatar
                };
                context.Pets.Add(newPet);
                TempData["PetAdd"] = "Added";


            }
            else //Update
            {
                var petInDb = context.Pets.Single(m => m.Id == pet.Id);

                var fileName = ExtraMethods.UploadPhoto(file);
                pet.Avatar = fileName;

                petInDb.Name = pet.Name;
                petInDb.Kind = pet.Kind;
                petInDb.Age = pet.Age;
                petInDb.Avatar = pet.Avatar;
                TempData["PetUpdate"] = "Updated";


            }
            context.SaveChanges();

            return RedirectToAction("ShowPets");
        }

    }
}
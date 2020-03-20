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
            return View("PetForm", new PetFormViewModel(context.Kinds.ToList()));
        }
        public ViewResult Details(int id)
        {
            var pet = context.Pets
                .Include(v=>v.Owner)
                .Include(v=>v.Kind)
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

            return View("PetForm", new PetFormViewModel(pet.Id, pet.Name, pet.KindId, pet.Age, pet.Avatar, context.Kinds.ToList()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(PetFormViewModel viewModel,HttpPostedFileBase file)
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
            if (viewModel.Id == 0)
            {
                var identityId = User.Identity.GetUserId();

                if (identityId == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var PersonToUpdate = context.Persons.Where(s => s.IdentityUserId == identityId).SingleOrDefault();
                var kindToUpdate = context.Kinds.Single(s => s.Id == viewModel.KindId);

                context.Pets.Add(new Pet(viewModel.Name, viewModel.KindId, kindToUpdate, viewModel.Age, ExtraMethods.UploadPhoto(file), PersonToUpdate));
                
                TempData["PetAdd"] = "Added";


            }
            else //Update
            {
                var petInDb = context.Pets.Single(m => m.Id == viewModel.Id);
                var kindInDb = context.Kinds.Single(s => s.Id == viewModel.KindId);


                petInDb.Modify(viewModel.Name, viewModel.KindId,kindInDb,viewModel.Age);

                if (!(file is null))
                {
                    petInDb.Modify(ExtraMethods.UploadPhoto(file));
                }


                TempData["PetUpdate"] = "Updated";

            }
            context.SaveChanges();

            return RedirectToAction("ShowPets");
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Http;
using StructureProject.DTO;
using AutoMapper;
using System.Net;
using Microsoft.AspNet.Identity;
using StructureProject.Models;

namespace StructureProject.Controllers.API
{
    public class PetsController : ApiController
    {
        private ApplicationDbContext context;

        public PetsController()
        {
            context = new ApplicationDbContext();
        }

        //GET /api/Pets
        public IEnumerable<PetDTO> GetPets()
        {
            var identityId = User.Identity.GetUserId();

            return context.Pets
                .Where(s=>s.Owner.IdentityUserId == identityId)
                .ToList()
                .Select(Mapper.Map<Pet, PetDTO>);
        }

        [HttpDelete]
        public void DeletePet(int id)
        {
            var petDb = context.Pets.SingleOrDefault(v => v.Id == id);

            if (petDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            context.Pets.Remove(petDb);
            context.SaveChanges();
        }

        [HttpPut]
        public void UpdatePet(int id, Pet petDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var petDb = context.Pets.SingleOrDefault(v => v.Id == id);

            if (petDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(petDto, petDb);

            context.SaveChanges();
        }
    }
}
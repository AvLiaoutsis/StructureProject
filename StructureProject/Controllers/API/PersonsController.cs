using StructureProject.Models;
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

namespace StructureProject.Controllers.API
{
    public class PersonsController : ApiController
    {
        private ApplicationDbContext context;

        public PersonsController()
        {
            context = new ApplicationDbContext();
        }

        //POST /api/persons
        [HttpPost]
        public IHttpActionResult CreatePerson(PersonDTO personDto)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var person = Mapper.Map<PersonDTO, Person>(personDto);

            context.Persons.Add(person);
            context.SaveChanges();

            return Ok();

        }

        //GET /api/Persons
        public IEnumerable<PersonDTO> GetPersons()
        {
            var identityId = User.Identity.GetUserId();


            //var loggedPerson = context.Persons.Where(s => s.IdentityUserId == identityId)
            //    .SingleOrDefault();

            return context.Persons
                .Where(s => !(s.IdentityUserId == identityId))
                .ToList()
                .Select(Mapper.Map<Person, PersonDTO>);
                
        }


        //DELETE /api/Persons/id
        [HttpDelete]
        public void DeletePerson(int id)
        {
            var personDb = context.Persons.SingleOrDefault(v => v.Id == id);

            if (personDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            context.Persons.Remove(personDb);
            context.SaveChanges();
        }

        //PUT
        [HttpPut]
        public void UpdatePerson(int id,Person personDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var personDb = context.Persons.SingleOrDefault(v => v.Id == id);

            if(personDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(personDto, personDb);

            context.SaveChanges();
        }


    }
}
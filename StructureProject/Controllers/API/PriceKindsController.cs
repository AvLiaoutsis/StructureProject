using AutoMapper;
using Microsoft.AspNet.Identity;
using StructureProject.DTO;
using StructureProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StructureProject.Controllers.API
{
    public class PriceKindsController : ApiController
    {
        ApplicationDbContext context;

        public PriceKindsController()
        {
            context = new ApplicationDbContext();
        }

        //GET /api/PriceKinds
        public IEnumerable<PriceKindDTO> GetPriceKinds()
        {

            return context.PriceKinds
                .ToList()
                .Select(Mapper.Map<PriceKind, PriceKindDTO>);

        }

        //GET /api/PriceKinds/Id
        //PersonId
        public IEnumerable<PriceKindDTO> GetPriceKinds(int id)
        {

            return context.PriceKinds
                .Where(p=>p.PersonId == id)
                .ToList()
                .Select(Mapper.Map<PriceKind, PriceKindDTO>);

        }
        public IEnumerable<PriceKindDTO> GetPriceKinds(int personid,byte kindid)
        {

            return context.PriceKinds
                .Where(p => p.KindId == kindid && p.PersonId == personid)
                .ToList()
                .Select(Mapper.Map<PriceKind, PriceKindDTO>);

        }
        [HttpDelete]
        public IHttpActionResult Delete(PriceKindDTO priceKindDTO)
        {
            var userId = User.Identity.GetUserId();
            var currentPersonId = context.Persons.Where(p => p.IdentityUserId == userId).SingleOrDefault().Id;

            var currentPriceKind = context.PriceKinds.Single(p => p.KindId == priceKindDTO.KindId && p.PersonId == currentPersonId);

            context.PriceKinds.Remove(currentPriceKind);
            context.SaveChanges();

            return Ok();

        }
        [HttpPost]
        public IHttpActionResult AddPrices(PriceKindDTO priceKindDTO)
        {
            var userId = User.Identity.GetUserId();
            var currentPersonId = context.Persons.Where(p => p.IdentityUserId == userId).SingleOrDefault().Id;

            var currentKindId = priceKindDTO.KindId;
            //Edit
            if(context.PriceKinds.Where(s=>s.PersonId == currentPersonId && s.KindId == currentKindId).Any())
            {
                var currentPriceKind = context.PriceKinds.Where(s => s.PersonId == currentPersonId && s.KindId == currentKindId).Single();
                currentPriceKind.Price = priceKindDTO.Price;
                context.SaveChanges();


            }//New
            else
            {
                var pricekind = new PriceKind
                {
                    Price = priceKindDTO.Price,
                    Person = context.Persons.Where(p => p.IdentityUserId == userId).SingleOrDefault(),
                    KindId = priceKindDTO.KindId
                };

                context.PriceKinds.Add(pricekind);
                context.SaveChanges();
            }


            return Ok();
        }
    }
}
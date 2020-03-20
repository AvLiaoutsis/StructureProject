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
    public class ReservationsController : ApiController
    {
        private ApplicationDbContext context;

        public ReservationsController()
        {
            context = new ApplicationDbContext();
        }

        public IEnumerable<ReservationDTO> GetReservations()
        {
            var identityId = User.Identity.GetUserId();

            return context.Reservations
                 .Where(s => s.Host.IdentityUserId == identityId)
                 .ToList()
                 .Select(Mapper.Map<Reservation, ReservationDTO>);
        }

        [HttpPost]
        public IHttpActionResult Reserve(ReservationDTO reservationDTO)
        {
            var existingReservation = context.Reservations.Single(s => s.Id == reservationDTO.Id);

            existingReservation.Modify(reservationDTO.Accept);

            context.SaveChanges();

            return Ok();
        }
    }
}
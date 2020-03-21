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

            var personwhomadereservation = context.Persons.Single(p=>p.Id == reservationDTO.CustomerId);

            existingReservation.Modify(reservationDTO.Accept);

            var newNotification = existingReservation.GetNotification();

            context.UserNotifications.Add(new UserNotification(personwhomadereservation, newNotification));

            context.SaveChanges();

            return Ok();
        }
    }
}
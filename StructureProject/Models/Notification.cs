using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StructureProject.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public NotificationType Type { get; set; }
        public string PetName { get; set; }

        [Required]
        public Reservation Reservation { get; set; }

        protected Notification()
        {
                
        }
        
        private Notification(NotificationType type,Reservation reservation)
        {
            if(reservation == null)
            {
                throw new ArgumentNullException("reservation");
            }

            Type = type;
            Reservation = reservation;
            DateTime = DateTime.Now;
        }
        public static Notification ReservartionApproved(Reservation reservation)
        {
            return new Notification(NotificationType.ReservationApproved, reservation);
        }
        public static Notification ReservartionCancelled(Reservation reservation)
        {
            return new Notification(NotificationType.ReservationCanceled, reservation);
        }

    }
}
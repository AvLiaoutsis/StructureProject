using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StructureProject.Models
{
    public class HostNotification
    {
        [Key]
        [Column(Order = 1)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int NotificationId { get; set; }

        public Person User { get; set; }
        public Person Host { get; set; }
        public Pet Pet { get; set; }

        public Notification Notification { get; set; }
        public bool IsRead { get; set; }

        protected HostNotification()
        {

        }

        public HostNotification(Person user, Notification notification, Pet pet, Person host)
        {
            if (user == null)
            {
                throw new ArgumentException("user");
            }

            if (notification == null)
            {
                throw new ArgumentException("notification");
            }

            if (pet == null)
            {
                throw new ArgumentException("pet");
            }

            if (host == null)
            {
                throw new ArgumentException("host");
            }
            User = user;
            Notification = notification;
            Pet = pet;
            Host = host;
        }

        public void Read()
        {
            IsRead = true;
        }
    }
}
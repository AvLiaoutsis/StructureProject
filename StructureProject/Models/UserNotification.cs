using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StructureProject.Models
{
    public class UserNotification
    {
        [Key]
        [Column(Order = 1)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int NotificationId { get; set; }

        public Person User { get; set; }
        public Notification Notification { get; set; }
        public bool IsRead { get; set; }

        protected UserNotification()
        {

        }

        public UserNotification(Person user,Notification notification)
        {
            if( user == null)
            {
                throw new ArgumentException("user");
            }

            if (notification == null)
            {
                throw new ArgumentException("notification");
            }

            User = user;
            Notification = notification;
        }
    }
}
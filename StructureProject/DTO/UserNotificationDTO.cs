using StructureProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StructureProject.DTO
{ 
        public class UserNotificationDTO
        {
            public int UserId { get; set; }

            public int NotificationId { get; set; }

            public Person User { get; set; }
            public Person Host { get; set; }
            public Pet Pet { get; set; }

            public Notification Notification { get; set; }
            public bool IsRead { get; set; }

        }
    
}

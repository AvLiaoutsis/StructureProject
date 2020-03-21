using StructureProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StructureProject.DTO
{
    public class NotificationDTO
    {
        public DateTime DateTime { get; set; }
        public NotificationType Type { get; set; }
        public string PetName { get; set; }
        public Reservation Reservation { get; set; }
    }
}
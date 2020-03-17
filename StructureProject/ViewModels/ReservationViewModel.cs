using StructureProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StructureProject.ViewModels
{
    public class ReservationViewModel
    {
        public int HostId { get; set; }
        public DateTime Date { get; set; }
        public int PetId { get; set; }
        public Decimal Price { get; set; }
        public Kind Kind { get; set; }
    }
}
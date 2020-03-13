using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StructureProject.Models
{
    public enum Acceptance
    {
        Waiting,
        Accepted,
        Declined
        
    }
    public class Reservation
    {
        public int Id { get; set; }
        public Person Host { get; set; }
        public Person Customer { get; set; }
        public Pet Pet { get; set; }
        public DateTime Date { get; set; }
        public Acceptance Accept { get; set; }

    }
}
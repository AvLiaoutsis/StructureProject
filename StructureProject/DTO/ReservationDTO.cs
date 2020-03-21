using StructureProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StructureProject.DTO
{
    public class ReservationDTO
    {
        public int Id { get; set; }
        public Person Host { get; set; }
        public int HostId { get; set; }

        public int CustomerId { get; set; }

        public PersonDTO Customer { get; set; }
        public Pet Pet { get; set; }
        public int PetId { get; set; }

        public DateTime Date { get; set; }
        public Acceptance Accept { get; set; }
    }
}
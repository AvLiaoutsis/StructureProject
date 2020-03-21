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
        public PersonDTO Host { get; set; }
        public int CustomerId { get; set; }

        public PersonDTO Customer { get; set; }
        public PetDTO Pet { get; set; }
        public DateTime Date { get; set; }
        public Acceptance Accept { get; set; }
    }
}
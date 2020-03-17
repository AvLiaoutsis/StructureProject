using StructureProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StructureProject.DTO
{
    public class PetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte KindId { get; set; }
        public KindDTO Kind { get; set; }
        public float Age { get; set; }
        public PersonDTO Owner { get; set; }
    }
}
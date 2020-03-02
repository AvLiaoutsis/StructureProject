using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StructureProject.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
        public float Age { get; set; }
        public Person Owner { get; set; }

    }
}
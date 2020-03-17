using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StructureProject.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public byte KindId { get; set; }
        public Kind Kind { get; set; }

        public float Age { get; set; }
        public string Avatar { get; set; }
        public Person Owner { get; set; }

    }
}
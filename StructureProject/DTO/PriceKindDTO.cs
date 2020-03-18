using StructureProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StructureProject.DTO
{
    public class PriceKindDTO
    {
        public int ID { get; set; }
        public int PersonId { get; set; }
        public PersonDTO Person { get; set; }
        [Display(Name = "Kind")]
        public byte KindId { get; set; }
        public KindDTO Kind { get; set; }
        public Decimal Price { get; set; }
    }
}
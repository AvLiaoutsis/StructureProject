using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StructureProject.Models
{
    public class PriceKind
    {
        public int ID { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        [Display(Name = "Kind")]
        public byte KindId { get; set; }
        public Kind Kind { get; set; }
        public Decimal Price { get; set; }
    }
}
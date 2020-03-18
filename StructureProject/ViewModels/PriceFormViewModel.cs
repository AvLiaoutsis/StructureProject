using StructureProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StructureProject.ViewModels
{
    public class PriceFormViewModel
    {
        //public int PersonId { get; set; }
        //public Person Person { get; set; }

        //[Required]
        //[Display(Name = "Kind")]
        //public byte KindId { get; set; }
        //public Kind Kind { get; set; }

        //public IEnumerable<Kind> Kinds { get; set; }
        //public Decimal Price { get; set; }
        public IEnumerable<PriceKind> PriceKinds { get; set; }
        public PriceFormViewModel()
        {
            PriceKinds = new List<PriceKind>();
        }
    }
    
}
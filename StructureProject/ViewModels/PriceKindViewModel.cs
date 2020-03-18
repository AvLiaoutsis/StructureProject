using StructureProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StructureProject.ViewModels
{
    public class PriceKindViewModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        [Display(Name = "Kind")]
        public byte KindId { get; set; }
        public Kind Kind { get; set; }
        public Decimal Price { get; set; }

        public List<PriceKind> KindPriceSet { get; set; }
    }
}
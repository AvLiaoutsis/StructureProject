using StructureProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StructureProject.ViewModels
{
    public class PetCreateViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public float Age { get; set; }

        [Required]
        [Display(Name="Kind")]
        public byte KindId { get; set; }
        public IEnumerable<Kind> Kinds { get; set; }


    }
}
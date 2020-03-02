using StructureProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StructureProject.ViewModels
{
    public class OwnerWithPetViewModel
    {
        public Person Owner { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
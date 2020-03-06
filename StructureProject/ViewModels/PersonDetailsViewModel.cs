using StructureProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StructureProject.ViewModels
{
    public class PersonDetailsViewModel
    {
        public Person Owner { get; set; }
        public ContactInfo Contact { get; set; }
        public List<Pet> Pets { get; set; }
        public HostInfo HostInfo { get; set; }
    }
}
using StructureProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StructureProject.ViewModels
{
    public class SearchViewModel
    {
        public int PersonId { get; set; }
        public List<Person> Persons { get; set; }
        public List<ContactInfo> Contacts { get; set; }
        public List<HostInfo> Hostings { get; set; }


    }
}
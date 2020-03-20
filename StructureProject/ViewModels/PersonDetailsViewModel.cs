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
        public IEnumerable<PriceKind> Prices {get;set;}
        public PersonDetailsViewModel(Person owner, ContactInfo contact, List<Pet> pets, HostInfo hostInfo, IEnumerable<PriceKind> prices)
        {
            Owner = owner;
            Contact = contact;
            Pets = pets;
            HostInfo = hostInfo;
            Prices = prices;
        }
    }
}
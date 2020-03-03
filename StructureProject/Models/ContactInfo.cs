using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StructureProject.Models
{
    public class ContactInfo
    {
        public int Id { get; set; }
        [Display(Name = "Phone Number")]

        public string PhoneNumber { get; set; }
        [Display(Name = "Telephone Number")]

        public string TelNumber { get; set; }
        public string Address { get; set; }
        [Display(Name = "Postal Code")]

        public int? PostalCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Person Person { get; set; }
    }
}
using StructureProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StructureProject.DTO
{
    public class ContantInfoDTO
    {
        public string PhoneNumber { get; set; }
        public string TelNumber { get; set; }
        public string Address { get; set; }
        public int? PostalCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Person Person { get; set; }
    }
}
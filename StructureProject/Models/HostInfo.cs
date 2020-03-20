using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StructureProject.Models
{
    public class HostInfo
    {
        public int Id { get; set; }
        public Person Person { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]

        public DateTime StartDateTime { get;private set; }

        [Display(Name = "End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]

        public DateTime EndDateTime { get;private set; }
        public HostInfo()
        {

        }


        public HostInfo(Person person, DateTime startDateTime, DateTime endDateTime)
        {
            Person = person;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
        }

        public void Modify(DateTime startDateTime, DateTime endDateTime)
        {
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
        }
        public void Modify(Person person)
        {
            Person = person;
        }
    }
}
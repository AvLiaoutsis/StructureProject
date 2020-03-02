using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StructureProject.DTO
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public DateTime? BirthDate { get; set; }

        public string IdentityUserId { get; set; }

        [Display(Name = "Biography")]
        public string Description { get; set; }



    }
}
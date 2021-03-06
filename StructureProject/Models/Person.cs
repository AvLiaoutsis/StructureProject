﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StructureProject.Models
{
    public class Person
    {


        public int Id { get; set; }

        [Display(Name = "First Name")]

        public string Name { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Email { get; set; }

        [Display(Name = "Birth Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]

        public DateTime BirthDate { get; set; }

        [Display(Name ="Biography")]
        public string Description { get; set; }

        public string Avatar { get; set; }

        public string IdentityUserId { get; set; }

        public string FullName
        {
            get
            {
                return LastName + " " + Name;
            }
        }
        public void Modify(string name, string lastName, DateTime birthdate, string description)
        {
            Name = name;
            LastName = lastName;
            BirthDate = birthdate;
            Description = description;
        }
        public void Modify(string avatar)
        {
            Avatar = avatar;
        }


    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StructureProject.Models
{
    public class Mail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; } 
        public string Subject { get; set; }
        public string Message { get; set; }
    }
    public enum Topics
    {
        General,
        Suggestions,
        Support
    }
}
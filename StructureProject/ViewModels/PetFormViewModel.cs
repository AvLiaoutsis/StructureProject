using StructureProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StructureProject.ViewModels
{
    public class PetFormViewModel
    {
        public Pet Pet { get; set; }
        public string Title
        {

            get
            {
                return Pet.Id == 0 ? "New Pet" : "Edit Pet";
            }
        }
    }
}
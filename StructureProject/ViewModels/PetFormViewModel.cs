using StructureProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StructureProject.ViewModels
{
    public class PetFormViewModel
    {


        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        [Display(Name="Kind")]
        public byte KindId { get; set; }
        public Kind Kind { get; set; }

        public float Age { get; set; }
        public string Avatar { get; set; }
        public IEnumerable<Kind> Kinds { get; set; }

        public string Title
        {

            get
            {
                return Id == 0 ? "New Pet" : "Edit Pet";
            }
        }



        public PetFormViewModel(int id, string name, byte kindId,float age, string avatar, IEnumerable<Kind> kinds)
        {
            Id = id;
            Name = name;
            KindId = kindId;
            Age = age;
            Avatar = avatar;
            Kinds = kinds;
        }
        public PetFormViewModel(IEnumerable<Kind> kinds)
        {
            Kinds = kinds;
        }
    }
}
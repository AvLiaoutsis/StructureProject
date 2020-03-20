using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StructureProject.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; private set; }

        [Required]
        public byte KindId { get;private set; }
        public Kind Kind { get; private set; }

        public float Age { get; private set; }
        public string Avatar { get; private set; }
        public Person Owner { get; private set; }

        protected Pet()
        {

        }

        public Pet(string name, byte kindId, Kind kind, float age, string avatar, Person owner)
        {
            Name = name;
            KindId = kindId;
            Kind = kind;
            Age = age;
            Avatar = avatar;
            Owner = owner;
        }
        public void Modify(string name, byte kindId, Kind kind, float age)
        {
            Name = name;
            KindId = kindId;
            Kind = kind;
            Age = age;
        } 
        public void Modify(string avatar)
        {
            Avatar = avatar;
        }
    }
}
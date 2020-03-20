using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StructureProject.Models
{
    public enum Acceptance
    {
        Waiting,
        Accepted,
        Declined
        
    }
    public class Reservation
    {

        public int Id { get; set; }
        public Person Host { get;private set; }
        public Person Customer { get;private set; }
        public Pet Pet { get; private set; }
        public DateTime Date { get; private set; }
        public Acceptance Accept { get; private set; }

        public Reservation(Person host, Person customer, Pet pet, DateTime date, Acceptance status)
        {
            Host = host;
            Customer = customer;
            Pet = pet;
            Date = date;
            Accept = status;
        }
        public void Modify(Acceptance status)
        {
            Accept = status;
        }
    }
}
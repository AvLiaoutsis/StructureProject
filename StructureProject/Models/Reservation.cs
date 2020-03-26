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
        public Person Customer { get; set; }
        public Pet Pet { get; private set; }
        public Decimal Price { get; set; }
        public DateTime Date { get; private set; }
        public Acceptance Accept { get; private set; }
    
        public Reservation(Person host, Person customer, Pet pet, DateTime date,decimal price, Acceptance status)
        {
            Host = host;
            Customer = customer;
            Pet = pet;
            Date = date;
            Price = price;
            Accept = status;
        }
        public Reservation()
        {

        }
        public void Modify(Acceptance status)
        {
            Accept = status;
           
            if(status == Acceptance.Accepted)
            {
                var notification = Notification.ReservartionApproved(this);  

            }
            else if(status == Acceptance.Declined)
            {
                var notification = Notification.ReservartionCancelled(this);

            }
        }
        public Notification GetNotification()
        {
            Notification notification;
            if (Accept == Acceptance.Accepted)
            {
                 notification = Notification.ReservartionApproved(this);

            }
            else if(Accept == Acceptance.Declined)
            {
                 notification = Notification.ReservartionCancelled(this);

            }
            else
            {
                notification = Notification.ReservationWaiting(this);
            }
            return notification;

        }
    }
}
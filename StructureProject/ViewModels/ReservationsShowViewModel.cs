using StructureProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StructureProject.ViewModels
{
    public class ReservationsShowViewModel
    {

        public List<Reservation> MyReservations { get; set; }
        public List<Reservation> ReservationsWithHostMe { get; set; }

        public ReservationsShowViewModel(List<Reservation> myReservations, List<Reservation> reservationsWithHostMe)
        {
            MyReservations = myReservations;
            ReservationsWithHostMe = reservationsWithHostMe;
        }
    }
}
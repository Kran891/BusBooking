using BusBooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.Models
{
    public class ReservationdetailsModel
    {
        public DateTime ReservationDate { get; set; }
        public string? Gender { get; set; }
        public int Age { get; set; }
        public int busid { get; set; }
        public int seatnumber { get; set; }
    }
}

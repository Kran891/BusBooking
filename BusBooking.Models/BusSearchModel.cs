using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.Models
{
    public class BusSearchModel
    {
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public decimal Fair { get; set; }
        public string? BusNumber { get; set; }
        public string? TravelsName { get; set; }
        public string? SeatType { get; set; }
        public DateTime OriginTime { get; set; }
        public DateTime TravelDate { get; set; }

    }
}

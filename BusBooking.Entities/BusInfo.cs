using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.Entities
{
    public class BusInfo
    {
        [Key]
        public int Id { get; set; }
        public string? BusNumber { get; set; }
        public string? Routes { get; set; }
        public SeatType seatType { get; set; }
        public enum SeatType
        {
            Luxury,
            Express
        }
    }
}

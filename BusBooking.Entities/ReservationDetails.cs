using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.Entities
{
    public class ReservationDetails
    {
        public int Id { get; set; }
        public string? Gender { get; set; }
        public int Age { get; set; }
        public virtual Invoice? invoice { get; set; }
        public int seatnumber { get; set; }
    }
}

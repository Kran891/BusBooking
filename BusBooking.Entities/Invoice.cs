using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.Entities
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public virtual BusInfo busInfo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}

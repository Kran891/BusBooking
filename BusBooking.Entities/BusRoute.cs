using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.Entities
{
    public class BusRoute
    {
        public int Id { get; set; }
        public virtual BusInfo? BusInfo { get; set; }
        public virtual CityName? Origin { get; set; }
        public virtual CityName? Destination { get; set; }
        [Column(TypeName = "decimal(18, 6)")]
        public decimal? Fair { get; set; }
        public DateTime OrginTime { get; set; }

    }
}

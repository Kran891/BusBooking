using BusBooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.Models
{
    public class BusInfoModel
    {
        public BusInfo? BusInfo { get; set; }
        public List<BusRoute>? busRoutes { get; set; }
    }
}

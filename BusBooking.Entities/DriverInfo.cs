

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.Entities
{
    public class DriverInfo: IdentityUser
    {
        public string? LicenceNumber { get; set; }
        public virtual BusInfo? busInfo { get; set; }

    }
}

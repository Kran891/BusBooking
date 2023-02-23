
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.Entities
{
    public class BusDbContext:IdentityDbContext<DriverInfo>
    {
        public BusDbContext(DbContextOptions<BusDbContext> options) : base(options) { }
        public DbSet<BusInfo> Buses { get; set; }
        public DbSet<CityName> Cities { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ReservationDetails> Reservations { get; set; }
        public DbSet<BusRoute> busRoutes { get; set; }

    }
}

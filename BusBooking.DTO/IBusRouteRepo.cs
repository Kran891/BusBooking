using BusBooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.DTO
{
    public interface IBusRouteRepo
    {
        Task<BusRoute> AddBusRoute(BusRoute busRoute);
        Task<int> DeleteBusRoute (BusRoute busRoute);
        Task<List<string>> GetBusRoute(int id);
    }
}

using BusBooking.Entities;
using BusBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.DTO
{
    public interface IBusInfoRepos
    {
        Task<BusInfoModel> AddBus(BusInfoModel busInfoModel);
        Task<BusInfo> UpdateBus(BusInfo busInfo);
        Task<int> DeleteBus(int id);
        Task<List<string>> GetAllCities();
        
    }
}

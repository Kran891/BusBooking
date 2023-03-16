using BusBooking.Entities;
using BusBooking.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.DTO
{
    public class BusInfoRepo : IBusInfoRepos
    {
        private readonly BusDbContext dbContext;
        private readonly IBusRouteRepo busRouteRepo;

        public BusInfoRepo(BusDbContext dbContext,IBusRouteRepo busRouteRepo)
        {
            this.dbContext = dbContext;
            this.busRouteRepo = busRouteRepo;
        }
        public async Task<BusInfoModel> AddBus(BusInfoModel busInfoModel)
        {
           await dbContext.Buses.AddAsync(busInfoModel.BusInfo);
            await dbContext.SaveChangesAsync();
            foreach(BusRoute busRoute in busInfoModel.busRoutes)
            {
                busRoute.BusInfo = busInfoModel.BusInfo;
                await busRouteRepo.AddBusRoute(busRoute);
            }
            
            return busInfoModel;
        }

        public async Task<int> DeleteBus(int id)
        {
            BusInfo? bus = await dbContext.Buses.FirstOrDefaultAsync<BusInfo>(x=>x.Id==id);

             dbContext.Buses.Remove(bus);
             await dbContext.SaveChangesAsync();
            return 1;
        }

        public async Task<List<string>> GetAllCities()
        {
            return await (from c in dbContext.Cities select c.Name).ToListAsync();
        }

        public async Task<BusInfo> UpdateBus(BusInfo busInfo)
        {
            dbContext.Buses.Update(busInfo);
            await dbContext.SaveChangesAsync();
            return busInfo;
        }
    }
}

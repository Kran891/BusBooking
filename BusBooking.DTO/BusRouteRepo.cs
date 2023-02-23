using BusBooking.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.DTO
{
    public class BusRouteRepo : IBusRouteRepo
    {
        private readonly BusDbContext dbContext;

        public BusRouteRepo(BusDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<BusRoute> AddBusRoute(BusRoute busRoute)
        {
            CityName cityName = await dbContext.Cities.FirstOrDefaultAsync<CityName>(x => x.Name.ToLower() == busRoute.Origin.Name.ToLower());
            if(cityName == null)
            {
                await dbContext.Cities.AddAsync(busRoute.Origin);
               
            }
            else
            {
                busRoute.Origin = cityName;
            }
            CityName cityName1= await dbContext.Cities.FirstOrDefaultAsync<CityName>(x => x.Name.ToLower() == busRoute.Destination.Name.ToLower());
            if (cityName1 == null)
            {
                await dbContext.Cities.AddAsync(busRoute.Destination);
                
            }
            else
            {
                busRoute.Destination=cityName1;
            }
            await dbContext.SaveChangesAsync();
            await dbContext.busRoutes.AddAsync(busRoute);
            await dbContext.SaveChangesAsync();
            return busRoute;
        }

        public Task<int> DeleteBusRoute(BusRoute busRoute)
        {
            throw new NotImplementedException();
        }
    }
}

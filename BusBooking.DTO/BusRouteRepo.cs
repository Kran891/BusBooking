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
       public async Task<List<string>> GetBusRoute(int id)
        {
            List<string> list = await (from r in dbContext.busRoutes
                                       where r.BusInfo.Id == id
                                       orderby r.OrginTime.TimeOfDay 
                                       select r.Origin.Name
                                           ).Distinct().ToListAsync();
            string des= await (from r in dbContext.busRoutes
                               where r.BusInfo.Id == id
                               orderby r.OrginTime.TimeOfDay descending
                               select r.Destination.Name 
                                           ).FirstOrDefaultAsync();
            list.Add(des);
            return list;
        }
        public Task<int> DeleteBusRoute(BusRoute busRoute)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BusSearchModel>> SearchBuses(BusSearchModel busSearchModel)
        {
            List<BusSearchModel> busSearchModels;
            if(busSearchModel.TravelDate!=DateTime.Today)
            busSearchModels= await
                  (from r in dbContext.busRoutes
                   join b in dbContext.Buses on r.BusInfo.Id equals b.Id
                   where r.Origin.Name.ToLower() == busSearchModel.Origin.ToLower()
                   && r.Destination.Name.ToLower() == busSearchModel.Destination.ToLower()
                   orderby r.OrginTime.TimeOfDay
                   select new BusSearchModel
                   {
                       BusNumber=b.BusNumber,
                       SeatType=b.seatType.ToString(),
                       OriginTime=r.OrginTime,
                       Origin=busSearchModel.Origin,
                       Destination=busSearchModel.Destination,
                       Fair=(decimal) r.Fair,
                       TravelsName=b.Routes
                   }
                   ).ToListAsync();
            else
                busSearchModels = await
      (from r in dbContext.busRoutes
       join b in dbContext.Buses on r.BusInfo.Id equals b.Id
       where r.Origin.Name.ToLower() == busSearchModel.Origin.ToLower()
       && r.Destination.Name.ToLower() == busSearchModel.Destination.ToLower()
       && DateTime.Now.Date+r.OrginTime.AddHours(1).TimeOfDay >= DateTime.Now
       orderby r.OrginTime.TimeOfDay

       select new BusSearchModel
       {
           BusNumber = b.BusNumber,
           SeatType = b.seatType.ToString(),
           OriginTime = r.OrginTime,
           Origin = busSearchModel.Origin,
           Destination = busSearchModel.Destination,
           Fair = (decimal)r.Fair,
           TravelsName = b.Routes
       }
       ).ToListAsync();
            return busSearchModels;
        }
    }
}

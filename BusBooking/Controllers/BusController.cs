using BusBooking.DTO;
using BusBooking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BusBooking.Controllers
{
    public class BusController : Controller
    {
        private readonly IBusInfoRepos busInfoRepos;
        private readonly IBusRouteRepo busRouteRepo;

        public BusController(IBusInfoRepos busInfoRepos,IBusRouteRepo busRouteRepo)
        {
            this.busInfoRepos = busInfoRepos;
            this.busRouteRepo = busRouteRepo;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("bus/addbus")]
        public async Task<IActionResult> AddBus([FromBody] BusInfoModel busInfoModel)
        {
           return Json( await busInfoRepos.AddBus(busInfoModel));
        }
        [Route("bus/getbusroute/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetBusRoute(int id)
        {
            return Json(await busRouteRepo.GetBusRoute(id));
        }
        [HttpPost]
        [Route("bus/searchbus")]
       
        public async Task<IActionResult> SearchBuses([FromBody] BusSearchModel busSearchModel)
        {
            return Json(await busRouteRepo.SearchBuses(busSearchModel));
        }
        [HttpGet]
        [Route("bus/getallcities")]
        public async Task<IActionResult> getAllCities()
        {
            return Json(await busInfoRepos.GetAllCities());
        }
    }
}

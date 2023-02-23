using BusBooking.DTO;
using BusBooking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BusBooking.Controllers
{
    public class BusController : Controller
    {
        private readonly IBusInfoRepos busInfoRepos;

        public BusController(IBusInfoRepos busInfoRepos)
        {
            this.busInfoRepos = busInfoRepos;
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
    }
}

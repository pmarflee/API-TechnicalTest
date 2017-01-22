using HotelAndLocationData.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HotelAndLocationData.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataService _dataService;

        public HomeController(IDataService dataService)
        {
            _dataService = dataService;
        }

        // GET: Home
        [HttpGet]
        public async Task<ViewResult> Index(string id)
        {
            var data = await _dataService.GetHotelAndLocationData(id);

            return View(data);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProgramlamaProje.Repository.Abstract;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebProgramlamaProje.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IFlightService? _flightService;

        public DashboardController(IFlightService flightService)
        {
            _flightService = flightService;
        }


        // GET: /<controller>/
        public async  Task<IActionResult> Index()
        {
            var result = await _flightService.GetAllAsync();

            return View(result);
        }

        public async Task<IActionResult> ReserveSeat(Guid Id)
        {
            var result = await _flightService.GetFlightWithTicket(Id);



            return View(result);
        }
    }
}


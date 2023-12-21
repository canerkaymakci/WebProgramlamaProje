using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebProgramlamaProje.Models.Domain;
using WebProgramlamaProje.Repository.Abstract;
using WebProgramlamaProje.Models.Dto.Admin;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebProgramlamaProje.Controllers
{
    public class AdminController : Controller
    {
        private readonly IFlightService? _flightService;

        public AdminController(IFlightService? flightService)
        {
            _flightService = flightService;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var result = await _flightService.GetAllAsync();

            return View(result);
        }

        public IActionResult CreateFlight()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFlight(Flight model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _flightService.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        public async  Task<IActionResult> FlightDetails(Guid Id)
        {
            var result = await _flightService.GetByIdAsync(Id);

            return View(result);
        }

        public async Task<IActionResult> AddTicketType(Guid Id)
        {
            TicketTypeCreateRequest model = new TicketTypeCreateRequest() { FlightId = Id };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddTicketType(TicketTypeCreateRequest model)
        {
            

            return View(model);
        }
    }
}


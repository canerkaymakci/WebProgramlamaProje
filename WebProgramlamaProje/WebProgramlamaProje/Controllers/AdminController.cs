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
        private readonly ITicketTypeService? _ticketTypeService;

        public AdminController(IFlightService? flightService, ITicketTypeService? ticketTypeService)
        {
            _flightService = flightService;
            _ticketTypeService = ticketTypeService;
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
            var result = await _flightService.GetFlightWithTicketType(Id);
            

            return View(result);
        }

        public async Task<IActionResult> AddTicketType(Guid Id)
        {
            TicketType model = new TicketType() { FlightId = Id };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddTicketType(TicketType model)
        {

            var result = await _ticketTypeService.CreateAsync(model);
            return RedirectToAction(nameof(FlightDetails), new {Id = model.FlightId});
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTicketType(Guid Id)
        {
            var result = await _ticketTypeService.GetByIdAsync(Id);
            await _ticketTypeService.DeleteAsync(Id);
            return RedirectToAction(nameof(FlightDetails), new { Id = result.FlightId });
        }

        public async Task<IActionResult> UpdateTicketType(Guid Id)
        {

            var result = await _ticketTypeService.GetByIdAsync(Id);

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTicketType(TicketType model)
        {

            var result = await _ticketTypeService.UpdateAsync(model);
            return RedirectToAction(nameof(FlightDetails), new { Id = model.FlightId });
        }


    }
}


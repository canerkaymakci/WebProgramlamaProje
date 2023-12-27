using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProgramlamaProje.Models.Domain;
using WebProgramlamaProje.Repository.Abstract;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebProgramlamaProje.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IFlightService? _flightService;
        private readonly ITicketService? _ticketService;

        public DashboardController(IFlightService flightService, ITicketService ticketService)
        {
            _flightService = flightService;
            _ticketService = ticketService;
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

        [HttpPost]
        public async Task<IActionResult> ReserveSeat(string FlightId, string TicketTypeId, string[] seatNo)
        {
            List<Ticket> tickets = new List<Ticket>();

            for(int i=0;i<seatNo.Count();i++)
            {
                Ticket ticket = new Ticket()
                {

                    FlightId = Guid.Parse(FlightId),
                    TicketTypeId = Guid.Parse(TicketTypeId),
                    SeatNo = int.Parse(seatNo[i]),
                    UserName = User.Identity.Name
                };
                tickets.Add(ticket);
            }

            var result = await _ticketService.CreateRangeAsync(tickets);


            return Json(new
            {
                status = result
            });
        }
    }
}


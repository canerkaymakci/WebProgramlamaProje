using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using WebProgramlamaProje.Models.Domain;
using WebProgramlamaProje.Repository.Abstract;


namespace WebProgramlamaProje.Controllers
{
    public class DashboardController : BaseController
    {
        private readonly ILogger<DashboardController> _logger;

        private readonly IStringLocalizer<DashboardController> _localizer;

        private readonly IFlightService? _flightService;
        private readonly ITicketService? _ticketService;

        public DashboardController(IFlightService flightService, ITicketService ticketService, IStringLocalizer<BaseController> baseLocalizer,
        IStringLocalizer<DashboardController> localizer,
        IHttpContextAccessor httpContextAccessor) : base(baseLocalizer, httpContextAccessor)
        {
            _flightService = flightService;
            _ticketService = ticketService;
            var selectedCulture = httpContextAccessor.HttpContext.Request.Cookies["SelectedCulture"];

          
            var cultureInfo = selectedCulture != null ? new CultureInfo(selectedCulture) : CultureInfo.CurrentCulture;

            //System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
            //System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;

            ////httpContextAccessor.HttpContext.Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
            ////httpContextAccessor.HttpContext.Response.Headers.Add("Pragma", "no-cache");
            ////httpContextAccessor.HttpContext.Response.Headers.Add("Expires", "0");

            //ViewData["CurrentCulture"] = cultureInfo.Name;

            _localizer = localizer;
        }


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

        [HttpPost]
        public IActionResult ChangeCulture(string culture)
        {
            if (!string.IsNullOrEmpty(culture))
            {
                var cultureInfo = new CultureInfo(culture);
                System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
                System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;

                Response.Cookies.Append("SelectedCulture", culture);
            }

            return RedirectToAction("Index");
        }
    }
}


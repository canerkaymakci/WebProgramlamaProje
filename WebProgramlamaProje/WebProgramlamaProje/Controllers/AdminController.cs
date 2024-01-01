using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebProgramlamaProje.Models.Domain;
using WebProgramlamaProje.Repository.Abstract;
using WebProgramlamaProje.Models.Dto.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using System.Globalization;


namespace WebProgramlamaProje.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : BaseController
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IStringLocalizer<AdminController> _localizer;

        private readonly IFlightService? _flightService;
        private readonly ITicketTypeService? _ticketTypeService;

        public AdminController(IFlightService? flightService, ITicketTypeService? ticketTypeService, IStringLocalizer<BaseController> baseLocalizer,
        IStringLocalizer<AdminController> localizer,
        IHttpContextAccessor httpContextAccessor) : base(baseLocalizer, httpContextAccessor)
        {
            _flightService = flightService;
            _ticketTypeService = ticketTypeService;

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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebProgramlamaProjeAPI.Dto;
using WebProgramlamaProjeAPI.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebProgramlamaProjeAPI.Controllers
{

    [ApiController]
    [Route("Ticket")]
    public class TicketController : Controller
    {
        private readonly ITicketService? _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost("GetTickets")]
        public async Task<IActionResult> GetTickets([FromBody]GetTicketRequest model)
        {
            var result = await _ticketService.GetUserTickets(model.UserName);
            return Json(result);
        }

        
    }
}

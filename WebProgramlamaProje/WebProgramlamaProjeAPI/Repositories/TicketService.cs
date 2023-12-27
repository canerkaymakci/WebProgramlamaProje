using System;
using Microsoft.EntityFrameworkCore;
using WebProgramlamaProjeAPI.Domain;

namespace WebProgramlamaProjeAPI.Repositories
{
	public class TicketService: ITicketService
	{

		private readonly ApplicationDbContext _context;

		public TicketService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<Ticket>> GetUserTickets(string userName)
		{
			var result = await _context.Ticket.Include(i=>i.Flight).Include(i=>i.TicketType).Where(i => i.UserName == userName).ToListAsync();
			return result;
		}
	}
}


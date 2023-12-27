using System;
using WebProgramlamaProje.Models.Domain;
using WebProgramlamaProje.Repository.Abstract;

namespace WebProgramlamaProje.Repository.Implementation
{
	public class TicketService: BaseRepository<Ticket, ApplicationDbContext>, ITicketService
	{
		private readonly ApplicationDbContext _context;

		public TicketService(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}


		public async Task<bool> CreateRangeAsync(IEnumerable<Ticket> tickets)
		{
			bool status = true;

			try
			{
                await _context.AddRangeAsync(tickets);
                await _context.SaveChangesAsync();
            }
			catch (Exception ex)
			{
				status = false;
			}

			return status;
		}

	}
}


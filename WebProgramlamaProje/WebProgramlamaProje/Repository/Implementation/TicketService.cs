using System;
using WebProgramlamaProje.Models.Domain;
using WebProgramlamaProje.Repository.Abstract;

namespace WebProgramlamaProje.Repository.Implementation
{
	public class TicketService: BaseRepository<Ticket, ApplicationDbContext>, ITicketService
	{
		public TicketService(ApplicationDbContext context) : base(context)
		{

		}
	}
}


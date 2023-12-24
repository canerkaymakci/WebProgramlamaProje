using System;
using WebProgramlamaProje.Models.Domain;
using WebProgramlamaProje.Repository.Abstract;

namespace WebProgramlamaProje.Repository.Implementation
{
	public class TicketTypeService: BaseRepository<TicketType, ApplicationDbContext>, ITicketTypeService
	{
		public TicketTypeService(ApplicationDbContext context) : base(context)
		{
		}
	}
}


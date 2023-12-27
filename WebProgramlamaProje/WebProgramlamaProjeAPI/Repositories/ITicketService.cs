using System;
using WebProgramlamaProjeAPI.Domain;

namespace WebProgramlamaProjeAPI.Repositories
{
	public interface ITicketService
	{
        Task<List<Ticket>> GetUserTickets(string userName);

    }
}


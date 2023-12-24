using System;
using WebProgramlamaProje.Models.Domain;

namespace WebProgramlamaProje.Repository.Abstract
{
    public interface IFlightService : IBaseRepository<Flight>
    {
        Task<Flight> GetFlightWithTicketType(Guid Id);
        Task<Flight> GetFlightWithTicket(Guid Id);

    }
}


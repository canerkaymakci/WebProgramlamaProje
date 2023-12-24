using System;
using Microsoft.EntityFrameworkCore;
using WebProgramlamaProje.Models.Domain;
using WebProgramlamaProje.Repository.Abstract;

namespace WebProgramlamaProje.Repository.Implementation
{
    public class FlightService : BaseRepository<Flight, ApplicationDbContext>, IFlightService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public FlightService(ApplicationDbContext context) : base(context)
        {
            _applicationDbContext = context;
        }

        public async Task<Flight> GetFlightWithTicketType(Guid Id)
        {
            return await _applicationDbContext.Flight.Include(f => f.TicketTypes).FirstOrDefaultAsync(f => f.Id == Id);
        }

        public async Task<Flight> GetFlightWithTicket(Guid Id)
        {
            return await _applicationDbContext.Flight.Include(f => f.Tickets).Include(f=>f.TicketTypes).FirstOrDefaultAsync(f => f.Id == Id);
        }

    }
}


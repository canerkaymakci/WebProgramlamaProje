using System;
using WebProgramlamaProje.Models.Domain;
using WebProgramlamaProje.Repository.Abstract;

namespace WebProgramlamaProje.Repository.Implementation
{
    public class FlightService : BaseRepository<Flight, ApplicationDbContext>, IFlightService
    {
        public FlightService(ApplicationDbContext context) : base(context)
        {
        }
    }
}


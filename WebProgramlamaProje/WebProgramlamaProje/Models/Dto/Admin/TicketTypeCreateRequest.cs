using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebProgramlamaProje.Models.Domain;

namespace WebProgramlamaProje.Models.Dto.Admin
{
	public class TicketTypeCreateRequest
	{
        public TicketTypeCreateRequest()
        {

        }

        public Guid FlightId { get; set; }
        [Required]
        public string? Name { get; set; }
        public List<Ticket>? Tickets { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string? Currency { get; set; }

    }
}


using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProgramlamaProje.Models.Domain
{

	[Table("Flight", Schema ="dbo")]
	public class Flight: BaseEntity
	{
		public Flight()
		{
			Tickets = new HashSet<Ticket>();
			TicketTypes = new HashSet<TicketType>();
		}

		public string? From { get; set; }
		public string? To { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
		public string? Description { get; set; }
		public int TotalSeatCount { get; set; }

		public ICollection<Ticket>? Tickets { get; set; }
		public ICollection<TicketType>? TicketTypes { get; set; }



	}
}


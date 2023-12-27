using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebProgramlamaProjeAPI.Domain
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
		public DateTime Date { get; set; }
		public string? Description { get; set; }
		public int TotalSeatCount { get; set; }


		[JsonIgnore]
		public ICollection<Ticket>? Tickets { get; set; }
		[JsonIgnore]
		public ICollection<TicketType>? TicketTypes { get; set; }



	}
}


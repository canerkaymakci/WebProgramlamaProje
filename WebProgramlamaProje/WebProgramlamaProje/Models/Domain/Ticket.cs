using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProgramlamaProje.Models.Domain
{
    [Table("Ticket", Schema = "dbo")]
    public class Ticket: BaseEntity
	{
		[ForeignKey("TicketType")]
		public Guid TicketTypeId { get; set; }
		[ForeignKey("Flight")]
		public Guid FlightId { get; set; }
		public int SeatNo { get; set; }
		public Flight? Flight { get; set; }
		public TicketType? TicketType { get; set; }
	


	}
}


using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProgramlamaProje.Models.Domain
{
    [Table("TicketType", Schema = "dbo")]
    public class TicketType: BaseEntity
	{
        public TicketType()
        {
			Tickets = new HashSet<Ticket>();
        }


		[ForeignKey("Flight")]
        public Guid FlightId { get; set; }
		[Required]
		public string Name { get; set; }
		public string Properties { get; set; }
		public ICollection<Ticket> Tickets { get; set; }
		[Required]
		public decimal Price { get; set; }
		[Required]
		public string Currency { get; set; }
		public Flight Flight { get; set; }
		
	}
}


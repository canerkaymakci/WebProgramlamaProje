using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebProgramlamaProjeAPI.Domain
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
		[Required]
		public decimal Price { get; set; }
		[Required]
		public string Currency { get; set; }

		[JsonIgnore]
		public Flight Flight { get; set; }
		[JsonIgnore]
		public ICollection<Ticket> Tickets { get; set; }
		
	}
}


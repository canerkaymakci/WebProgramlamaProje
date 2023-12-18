using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProgramlamaProje.Models.Domain
{
    [Table("TicketTypeProperty", Schema = "dbo")]
    public class TicketTypeProperty: BaseEntity
	{
		public Guid TicketTypeId { get; set; }
		public string Property { get; set; }
		public TicketType TicketType { get; set; }

	}
}


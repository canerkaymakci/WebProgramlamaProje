using System;
namespace WebProgramlamaProje.Models
{
	public interface IBaseEntity
	{
		public Guid Id { get; set; }
		public string? CreaterUser { get; set; }
		public DateTime CreatedDate { get; set; }
        public string? LastModifierUser { get; set; }
        public DateTime LastModifiedDate { get; set; }

    }
}


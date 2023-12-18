using System;
using System.ComponentModel.DataAnnotations;
namespace WebProgramlamaProje.Models
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string? CreaterUser { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public string? LastModifierUser { get; set; }
        [Required]
        public DateTime LastModifiedDate { get; set; }
    }
}


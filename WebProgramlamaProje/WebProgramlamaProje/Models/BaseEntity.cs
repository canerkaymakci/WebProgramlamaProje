using System;
using System.ComponentModel.DataAnnotations;
namespace WebProgramlamaProje.Models
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}


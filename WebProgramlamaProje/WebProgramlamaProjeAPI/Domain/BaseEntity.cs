using System;
using System.ComponentModel.DataAnnotations;
namespace WebProgramlamaProjeAPI.Domain
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}


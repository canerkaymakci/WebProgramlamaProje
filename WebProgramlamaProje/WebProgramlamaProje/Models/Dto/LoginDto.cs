using System;
using System.ComponentModel.DataAnnotations;

namespace WebProgramlamaProje.Models.Dto
{
	public class LoginDto
	{

        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}


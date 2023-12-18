using System;
using Microsoft.AspNetCore.Identity;

namespace WebProgramlamaProje.Models.Domain
{
	public class ApplicationUser: IdentityUser
	{

		public string Name { get; set; }
	}
}


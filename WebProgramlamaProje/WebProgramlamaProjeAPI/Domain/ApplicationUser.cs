using System;
using Microsoft.AspNetCore.Identity;

namespace WebProgramlamaProjeAPI.Domain
{
	public class ApplicationUser: IdentityUser
	{
		public string Name { get; set; }
	}
}


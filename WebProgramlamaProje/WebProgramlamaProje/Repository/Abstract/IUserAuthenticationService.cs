using System;
using WebProgramlamaProje.Models.Dto;

namespace WebProgramlamaProje.Repository.Abstract
{
	public interface IUserAuthenticationService
	{
		Task<StatusDto> LoginAsync(LoginDto model);
        Task<StatusDto> RegistrationAsync(RegistrationDto model);
		Task LogoutAsync();
    }
}


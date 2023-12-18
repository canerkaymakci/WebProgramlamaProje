using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using WebProgramlamaProje.Models.Domain;
using WebProgramlamaProje.Models.Dto;
using WebProgramlamaProje.Repository.Abstract;

namespace WebProgramlamaProje.Repository.Implementation
{
	public class UserAuthenticationService: IUserAuthenticationService
	{
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserAuthenticationService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<StatusDto> LoginAsync(LoginDto model)
        {
            var status = new StatusDto();
            var user = await _userManager.FindByNameAsync(model.Username);
            if(user==null)
            {
                status.StatusCode = 0;
                status.Message = "Hatalı Kullanıcı Adı";
                return status;
            }

            if(!await _userManager.CheckPasswordAsync(user,model.Password))
            {
                status.StatusCode = 0;
                status.Message = "Hatalı Şifre";
                return status;
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, false,true);

            if(signInResult.Succeeded)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim> { new Claim(ClaimTypes.Name,user.UserName)};
                foreach(var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                status.StatusCode = 1;
                status.Message = "Giriş Başarılı";
                return status;
            }
            else if(signInResult.IsLockedOut)
            {
                status.StatusCode = 0;
                status.Message = "Hesap Kilitlendi";
                return status;
            }
            else
            {
                status.StatusCode = 0;
                status.Message = "Giriş Sırasında Hata";
                return status;
            }
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<StatusDto> RegistrationAsync(RegistrationDto model)
        {
            var status = new StatusDto();
            var userExist = await _userManager.FindByNameAsync(model.Username);
            if(userExist!=null)
            {
                status.StatusCode = 0;
                status.Message = "Kullanıcı Zaten Mevcut";
                return status;
            }

            ApplicationUser user = new ApplicationUser
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                Name = model.FirstName + " " + model.LastName,
                Email = model.Email,
                UserName = model.Username,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user,model.Password);

            if(!result.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "Kullanıcı Oluşturma Sırasında Hata Oluştu";
                return status;
            }

            if(!await _roleManager.RoleExistsAsync(model.Role))
            {
                await _roleManager.CreateAsync(new IdentityRole(model.Role));
            }

            await _userManager.AddToRoleAsync(user, model.Role);

            status.StatusCode = 1;
            status.Message = "Kayıt Başarıyla Oluşturuldu";
            return status;

        }
    }
}


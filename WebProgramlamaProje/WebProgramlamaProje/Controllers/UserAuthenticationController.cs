using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProgramlamaProje.Models.Dto;
using WebProgramlamaProje.Repository.Abstract;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebProgramlamaProje.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private readonly IUserAuthenticationService _userAuthenticationService;

        public UserAuthenticationController(IUserAuthenticationService userAuthenticationService)
        {
            _userAuthenticationService = userAuthenticationService;
        }

        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _userAuthenticationService.LoginAsync(model);

            if(result.StatusCode==1)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                TempData["AlertMessage"] = result.Message;
                return RedirectToAction(nameof(Login));
            }
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationDto model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            model.Role = "User";

            var result = await _userAuthenticationService.RegistrationAsync(model);

            if(result.StatusCode == 1)
            {
                return RedirectToAction(nameof(Registration));
            }
            else
            {
                TempData["AlertMessage"] = result.Message;
                return View(model);
            }

        }

        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await _userAuthenticationService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}


using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;



namespace WebProgramlamaProje.Controllers
{
    public class BaseController : Controller
    {
        private readonly IViewLocalizer _viewLocalizer;

        private readonly IStringLocalizer<BaseController> _stringLocalizer;

        public BaseController(IStringLocalizer<BaseController> stringLocalizer, IHttpContextAccessor httpContextAccessor)
        {

            var selectedCulture = httpContextAccessor.HttpContext.Request.Cookies["SelectedCulture"];

            var cultureInfo = selectedCulture != null ? new CultureInfo(selectedCulture) : CultureInfo.CurrentCulture;

            System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;

            //httpContextAccessor.HttpContext.Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
            //httpContextAccessor.HttpContext.Response.Headers.Add("Pragma", "no-cache");
            //httpContextAccessor.HttpContext.Response.Headers.Add("Expires", "0");

            ViewData["CurrentCulture"] = cultureInfo.Name;

       
            _stringLocalizer = stringLocalizer;

        }
    }
}


using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using RestSharp;
using WebProgramlamaProje.Models;
using WebProgramlamaProje.Models.Domain;

namespace WebProgramlamaProje.Controllers;

public class HomeController : BaseController
{
    private readonly ILogger<HomeController> _logger;

    private readonly IStringLocalizer<HomeController> _localizer;

    public HomeController(IStringLocalizer<BaseController> baseLocalizer,
        IStringLocalizer<HomeController> localizer,
        IHttpContextAccessor httpContextAccessor) :base(baseLocalizer, httpContextAccessor)
    {
        var selectedCulture = httpContextAccessor.HttpContext.Request.Cookies["SelectedCulture"];

        var cultureInfo = selectedCulture != null ? new CultureInfo(selectedCulture) : CultureInfo.CurrentCulture;

        //System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
        //System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;

        ////httpContextAccessor.HttpContext.Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
        ////httpContextAccessor.HttpContext.Response.Headers.Add("Pragma", "no-cache");
        ////httpContextAccessor.HttpContext.Response.Headers.Add("Expires", "0");

        //ViewData["CurrentCulture"] = cultureInfo.Name;

        _localizer = localizer;
    }

    

    
    public async Task<IActionResult> Index()
    {
        var x = _localizer["activeTickets"];

        var client = new RestClient("https://localhost:7172");

        var request = new RestRequest("Ticket/GetTickets", Method.Post);


        request.AddJsonBody(new
        {
            UserName = User.Identity.Name
        });

        try
        {
            var response = await client.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = response.Content;

                var mappingResult = JsonConvert.DeserializeObject<List<Ticket>>(result);

                return View(mappingResult);
            }
            else
            {
                return StatusCode((int)response.StatusCode, response.StatusDescription);
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return View();

    }

    [HttpPost]
    public IActionResult ChangeCulture(string culture)
    {
        if (!string.IsNullOrEmpty(culture))
        {
            var cultureInfo = new CultureInfo(culture);
            System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;

            Response.Cookies.Append("SelectedCulture", culture);
        }

        return RedirectToAction("Index");
    }



    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    ///TODO Localizations, Frontend, SeedData Users
}


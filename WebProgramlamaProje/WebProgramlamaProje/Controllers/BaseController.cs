using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebProgramlamaProje.Controllers
{
    public class BaseController : Controller
    {
        private readonly IViewLocalizer _viewLocalizer;

        private readonly IStringLocalizer<BaseController> _stringLocalizer;

        public BaseController(IStringLocalizer<BaseController> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;

        }
    }
}


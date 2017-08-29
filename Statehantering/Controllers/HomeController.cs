using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Statehantering.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Statehantering.Controllers
{

    [Route("Settings")]
    public class HomeController : Controller
    {
        const string message = "tempMessage";

        IMemoryCache cache;

        public HomeController(IMemoryCache cache)
        {
            this.cache = cache;
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Index(CreateVM createVM)
        {
            if (!ModelState.IsValid)
            {
                return View(createVM);
            }

            TempData[message] = $"{createVM.Name}´s värden har sparats!";
            HttpContext.Session.SetString(message, createVM.Name);
            cache.Set(message, createVM.Email);
            return RedirectToAction(nameof(Display));
        }

        [Route("Display")]
        public IActionResult Display()
        {
            return View(new DisplayVM {Message = message, CacheMessage = cache.Get<string>(message), SessionMessage = HttpContext.Session.GetString(message)});
        }
    }
}

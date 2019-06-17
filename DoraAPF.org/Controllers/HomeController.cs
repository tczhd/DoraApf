using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoraAPF.org.Models;
using DoraAPF.org.Code.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DoraAPF.org.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVisitorService _visitorService;
        private IHttpContextAccessor _accessor;

        public HomeController(IVisitorService visitorService, IHttpContextAccessor accessor)
        {
            _visitorService = visitorService;
            _accessor = accessor;
        }
        public IActionResult Index()
        {
            var ip = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            var userAgent = Request.Headers["User-Agent"];
            var browserInfo = "";
            if (userAgent.Any()) {
                browserInfo = userAgent.First();
                if (browserInfo.Length > 50)
                {
                    browserInfo = browserInfo.Substring(0, 50);
                }
            }
            
            _visitorService.SaveVisitor(ip, browserInfo);

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "About Dora animal fundation protection.";

            return View();
        }

        public IActionResult Story()
        {
            ViewData["Message"] = "Dora animal fundation protection Story.";

            return View();
        }

        public IActionResult Team()
        {
            ViewData["Message"] = "Dora animal fundation protection team.";

            return View();
        }

        public IActionResult Activities()
        {
            ViewData["Message"] = "Dora animal fundation protection activity.";

            return View();
        }

        public IActionResult News()
        {
            ViewData["Message"] = "Dora animal fundation protection news.";

            return View();
        }

        public IActionResult Letters()
        {
            ViewData["Message"] = "Dora animal fundation protection letters.";

            return View();
        }

        public IActionResult Donate()
        {
            ViewData["Message"] = "Dora animal fundation protection Donation.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
    }
}

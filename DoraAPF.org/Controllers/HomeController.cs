using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoraAPF.org.Models;

namespace DoraAPF.org.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
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

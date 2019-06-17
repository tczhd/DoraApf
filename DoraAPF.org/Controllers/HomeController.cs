using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoraAPF.org.Models;
using DoraAPF.org.Facade.Interfaces;
using Microsoft.AspNetCore.Http;
using DoraAPF.org.Facade.Interfaces.Payment;
using DoraAPF.org.Models.Payment.Helcim;

namespace DoraAPF.org.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVisitorService _visitorService;
        private IHttpContextAccessor _accessor;
        private readonly IThirdPartyPaymentService _helcimPaymentService;

        public HomeController(IVisitorService visitorService, IHttpContextAccessor accessor, IThirdPartyPaymentService helcimPaymentService)
        {
            _visitorService = visitorService;
            _accessor = accessor;
            _helcimPaymentService = helcimPaymentService;
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

            //test();

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

        private void test()
        {
            var request = new HelcimBasicRequestModel()
            {
                AccountId = "2500026611",
                ApiToken = "4x6xjkens5fr6eMa28m24mdD9",
                OrderNumber = "Dora-" + DateTime.Now.ToString("yyyyMMddhhmmss"),
                TransactionType = "purchase",
                TerminalId = "70028",
                Test = true,
                Amount = 5,
                CardToken = "defcbf159f5434f7bbd6a3",
                CardF4L4 = "54545454",
                Comments = "Card on file payment",
                CreditCard = new HelcimCreditCardRequestModel()
                {
                    CardHolderName = "Jane Smith",
                    cardNumber = "5454545454545454",
                    cardExpiry = "1020",
                    cardCVV = "100",
                    cardHolderAddress = "123 Road Street",
                    cardHolderPostalCode = "90212"
                }
            };

            var result = _helcimPaymentService.ProcessPayment(request);
        }
    }
}

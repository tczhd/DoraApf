using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoraAPF.org.Facade.Interfaces.WebPages;
using DoraAPF.org.ViewModels.WebPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoraAPF.org.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class ContentController : Controller
    {
        private readonly IWebPageService _webPageService;

        public ContentController( IWebPageService webPageService)
        {
            _webPageService = webPageService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = _webPageService.GetWebContent(4);

            return View((WebPageViewModel)model);
        }
    }
}

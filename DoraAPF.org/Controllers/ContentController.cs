using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoraAPF.org.Facade.Interfaces.WebPages;
using DoraAPF.org.ViewModels.WebPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoraAPF.org.Controllers
{
    [Authorize]
    public class ContentController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
           private readonly IWebPageService _webPageService;

        public ContentController( IWebPageService webPageService
            , SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _webPageService = webPageService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        private WebPageViewModel GetContent(int webPagetTypeId)
        {
            if (_userManager.IsInRoleAsync(_userManager.Users.First(p => p.Email.ToLower() == User.Identity.Name.ToLower()), "ADMIN").Result)
            {
                var model = _webPageService.GetWebContent(webPagetTypeId);

                return model;
            }

            return null;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewData["Message"] = "Home Page.";

            var content = GetContent(1);
            if (content != null)
            {
                return View(content);
            }

            return Redirect("/Identity/Account/AccessDenied");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "About Dora animal fundation protection.";

            return View();
        }

        public IActionResult Story()
        {
            ViewData["Message"] = "Dora animal fundation protection Story.";

            var content = GetContent(4);
            if (content != null)
            {
                return View(content);
            }

            return Redirect("/Identity/Account/AccessDenied");
        }
  
        public IActionResult Team()
        {
            ViewData["Message"] = "Dora animal fundation protection team.";

            var content = GetContent(3);
            if (content != null)
            {
                return View(content);
            }

            return Redirect("/Identity/Account/AccessDenied");
        }
     
        public IActionResult Activities()
        {
            ViewData["Message"] = "Dora animal fundation protection activity.";

            var content = GetContent(6);
            if (content != null)
            {
                return View(content);
            }

            return Redirect("/Identity/Account/AccessDenied");
        }
       
        public IActionResult News()
        {
            ViewData["Message"] = "Dora animal fundation protection news.";

            var content = GetContent(5);
            if (content != null)
            {
                return View(content);
            }

            return Redirect("/Identity/Account/AccessDenied");
        }
    }
}

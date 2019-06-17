using DoraAPF.org.Facade.Interfaces;
using DoraAPF.org.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoraAPF.org.ViewComponents
{
    [ViewComponent(Name = "Visitors")]
    public class VisitorsViewComponent : ViewComponent
    {
        private readonly IVisitorService _visitorService;
        public VisitorsViewComponent(IVisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        public IViewComponentResult Invoke(string userName)
        {
            var count = _visitorService.GetVisitors();
            var data = new VisitorsViewComponentViewModel
            {
                VisitorsCount = count
            };
            return View(data);
        }
    }
}

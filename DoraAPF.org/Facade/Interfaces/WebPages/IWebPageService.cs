using DoraAPF.org.Models.WebPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoraAPF.org.Facade.Interfaces.WebPages
{
    public interface IWebPageService
    {
        WebPageModel GetWebContent(int webPageTypeId);
    }
}

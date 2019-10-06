using DoraAPF.org.Data.Entities;
using DoraAPF.org.Facade.Interfaces.Repository;
using DoraAPF.org.Facade.Interfaces.WebPages;
using DoraAPF.org.Facade.Specifications.WebPages;
using DoraAPF.org.Models.WebPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoraAPF.org.Facade.Services.WebPages
{
    public class WebPageService : IWebPageService
    {
        private readonly IRepository<WebPage> _webPageRepository;
        public WebPageService(IRepository<WebPage> webPageRepository)
        {
            _webPageRepository = webPageRepository;
        }
        public WebPageModel GetWebContent(int webPageTypeId)
        {
            var webPageSpecification = new WebPageSpecification();
            webPageSpecification.AddWebPageTypeId(webPageTypeId);
            var content = _webPageRepository.GetSingleBySpec(webPageSpecification);

            if (content != null)
            {
                return content;
            }

            return null;
        }

        public bool SubmitWebContent(int webPageTypeId, string htmlContent)
        {
            var webPageSpecification = new WebPageSpecification();
            webPageSpecification.AddWebPageTypeId(webPageTypeId);
            var content = _webPageRepository.GetSingleBySpec(webPageSpecification);

            if (content != null)
            {
                content.HtmlContent = htmlContent;
                _webPageRepository.Update(content);
                return true;
            }

            return false;
        }
    }
}

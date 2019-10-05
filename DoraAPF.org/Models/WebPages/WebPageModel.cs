using DoraAPF.org.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoraAPF.org.Models.WebPages
{
    public class WebPageModel
    {
        public int Id { get; set; }
        public int WebPageTypeId { get; set; }
        public string Name { get; set; }
        public string HtmlContent { get; set; }

        public static implicit operator WebPageModel(WebPage source)
        {
            return new WebPageModel
            {
                HtmlContent = source.HtmlContent,
                Id = source.Id,
                Name = source.Name,
                WebPageTypeId = source.WebPageTypeId
            };
        }
    }
}

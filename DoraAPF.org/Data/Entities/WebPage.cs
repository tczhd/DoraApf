using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoraAPF.org.Data.Entities
{
    public class WebPage : BaseEntity
    {
        public int WebPageTypeId { get; set; }
        public string Name { get; set; }
        public string HtmlContent { get; set; }
    }
}

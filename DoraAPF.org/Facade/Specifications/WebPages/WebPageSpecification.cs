using DoraAPF.org.Data.Entities;
using DoraAPF.org.Facade.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoraAPF.org.Facade.Specifications.WebPages
{
    public class WebPageSpecification : BaseSpecification<WebPage>
    {
        public WebPageSpecification() : base()
        {
        }

        public void AddWebPageTypeId(int webPageTypeId)
        {
            AddCriteria(q => q.WebPageTypeId == webPageTypeId);
        }
    }
}

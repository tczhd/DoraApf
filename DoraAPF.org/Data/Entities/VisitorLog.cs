using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoraAPF.org.Data.Entities
{
    public class VisitorLog : BaseEntity
    {
        public DateTime VisitedOn { get; set; }
        public string LocationIP { get; set; }
        public string BrowserName { get; set; }

        public VisitorLog()
        {
            VisitedOn = DateTime.Now;
        }
    }
}

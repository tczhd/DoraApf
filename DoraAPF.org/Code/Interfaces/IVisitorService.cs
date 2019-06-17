using DoraAPF.org.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoraAPF.org.Code.Interfaces
{
    public interface IVisitorService
    {
        Result SaveVisitor(string locationIp, string browserName);
        int GetVisitors();
    }
}

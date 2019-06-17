using System.Threading.Tasks;
using DoraAPF.org.Facade.Interfaces.Repository;
using DoraAPF.org.Data.Entities;
using DoraAPF.org.Facade.Interfaces;
using DoraAPF.org.Models;


namespace DoraAPF.org.Facade.Services
{
    public class VisitorService : IVisitorService
    {
        private readonly IRepository<VisitorLog> _visitorLogRepository;
        public VisitorService(IRepository<VisitorLog> visitorLogRepository)
        {
            _visitorLogRepository = visitorLogRepository;
        }

        public int GetVisitors()
        {
            var count =  _visitorLogRepository.Count();

            return count;
        }

        public Result SaveVisitor( string locationIp, string browserName)
        {
            var visitorLog = new VisitorLog() {LocationIP =locationIp, BrowserName= browserName };

            var data = _visitorLogRepository.Add(visitorLog);

            var result =  new Result { Success = true, Message = "Success. " };

            return result;
        }

    }
}

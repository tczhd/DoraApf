using DoraAPF.org.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoraAPF.org.Facade.Interfaces.Payment
{
    public interface IThirdPartyPaymentService
    {
        Result ProcessPayment(BasicRequestModel requestModel);
        Result ProcessVoid(BasicRequestModel requestModel);
        Result ProcessRefund(BasicRequestModel requestModel);
    }
}

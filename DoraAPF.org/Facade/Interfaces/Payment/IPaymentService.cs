using DoraAPF.org.Models;
using DoraAPF.org.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoraAPF.org.Facade.Interfaces.Payment
{
    public interface IPaymentService
    {
        PaymentResultModel DoPayment(PaymentModel paymentModel);
    }
}

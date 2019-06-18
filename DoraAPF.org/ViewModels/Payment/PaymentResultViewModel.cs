using DoraAPF.org.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoraAPF.org.ViewModels.Payment
{
    public class PaymentResultViewModel :Result
    {
        public string AuthCode { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoraAPF.org.Models.Payment.Helcim
{
    public class HelcimCreditCardRequestModel
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string CardExpiry { get; set; }
        public string CardCVV { get; set; }
        public string CardHolderAddress { get; set; }
        public string CardHolderPostalCode { get; set; }
    }
}

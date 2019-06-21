using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoraAPF.org.Models.Payment
{
    public class PaymentResultModel: Result
    {
        public int PaymentId { get; set; }
        public bool Approved { get; set; }
        public PaymentType PaymentType { get; set; }
        public string AuthCode { get; set; }
        public string TransactionId { get; set; }
        public Currency Currency { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string CardHolderName { get; set; }
        public string EncryptCardNumber { get; set; }
    }
}
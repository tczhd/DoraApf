using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoraAPF.org.Data.Entities
{
    public class Payment : BaseEntity
    {
        public int BillingId { get; set; }
        public decimal AmountPaid { get; set; }
        public string TransactionId { get; set; }
        public string AuthCode { get; set; }
        public int PaymentType { get; set; }
        public DateTime PaymentDate { get; set; }
        public int CurrencyId { get; set; }
        public string CardF4L4 { get; set; }
        public string CardHolderName { get; set; }
        public string CardToken { get; set; }
        public bool Active { get; set; }
        public virtual BillingInfo BillingInfo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoraAPF.org.Models.Payment
{
    public class PaymentModel
    {
        public string Title { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
 
        public string Address1 { get; set; }
        public string Address2 { get; set; }
    
        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string PostalCode { get; set; }
  
        public string PaymentAmount { get; set; }
   
        public string CardHolderName { get; set; }

        public string CardNumber { get; set; }

        public string CardExpiry { get; set; }

        public string CardCVV { get; set; }

    }
}

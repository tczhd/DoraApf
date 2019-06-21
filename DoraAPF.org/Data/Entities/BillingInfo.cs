using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoraAPF.org.Data.Entities
{
    public class BillingInfo: BaseEntity
    {
        public BillingInfo()
        {
            Payment = new HashSet<Payment>();
        }
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
        public string UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}

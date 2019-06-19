using System.ComponentModel.DataAnnotations;

namespace DoraAPF.org.ViewModels.Payment
{
    public class PaymentViewModel
    {
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Address1")]
        public string Address1 { get; set; }
        [Display(Name = "Address2")]
        public string Address2 { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "Country")]
        public string County { get; set; }
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        [Display(Name = "Donation Amount")]
        public string PaymentAmount { get; set; }
        [Display(Name = "Card Holder Name")]
        public string CardHolderName { get; set; }
        [Display(Name = "Card Number ")]
        public string CardNumber { get; set; }
        [Display(Name = "Expiration Date")]
        public string CardExpiry { get; set; }
        [Display(Name = "CVV")]
        public string CardCVV { get; set; }
        [Display(Name = "Card Holder Address")]
        public string CardHolderAddress { get; set; }
        [Display(Name = "Card Holder Postal Code")]
        public string CardHolderPostalCode { get; set; }
    }
}

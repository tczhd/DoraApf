using System.ComponentModel.DataAnnotations;

namespace DoraAPF.org.ViewModels.Payment
{
    public class PaymentViewModel
    {
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

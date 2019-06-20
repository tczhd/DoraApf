using System.ComponentModel.DataAnnotations;

namespace DoraAPF.org.ViewModels.Payment
{
    public class PaymentViewModel
    {
 
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Address1")]
        public string Address1 { get; set; }
        [Display(Name = "Address2")]
        public string Address2 { get; set; }
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required]
        [Display(Name = "State")]
        public string State { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string County { get; set; }
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        [Required]
        [Display(Name = "Donation Amount")]
        public string PaymentAmount { get; set; }
        [Required]
        [Display(Name = "Card Holder Name")]
        public string CardHolderName { get; set; }
        [Required]
        [Display(Name = "Card Number ")]
        public string CardNumber { get; set; }
        [Required]
        [Display(Name = "Expiration Date")]
        public string CardExpiry { get; set; }
        [Required]
        [Display(Name = "CVV")]
        public string CardCVV { get; set; }
    }
}

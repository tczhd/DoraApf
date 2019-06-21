using DoraAPF.org.Models.Payment;
using DoraAPF.org.ViewModels.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
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
        public string Country { get; set; }
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

        public GenericListViewModel GenericList { get; set; }

        public PaymentViewModel()
        {
            GenericList = new GenericListViewModel();
        }

        public static implicit operator PaymentModel(PaymentViewModel source)
        {
            return new PaymentModel
            {
                Address1 = source.Address1,
                Address2 = source.Address2,
                CardCVV = source.CardCVV,
                CardExpiry = source.CardExpiry,
                CardHolderName = source.CardHolderName,
                CardNumber = source.CardNumber,
                City = source.City,
                Country = source.Country,
                Email = source.Email,
                FirstName = source.FirstName,
                LastName = source.LastName,
                PaymentAmount = source.PaymentAmount,
                Phone = source.Phone,
                PostalCode = source.PostalCode,
                State = source.State,
                Title = source.Title
            };
        }
    }
}

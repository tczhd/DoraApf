using DoraAPF.org.Facade.Interfaces.Payment;
using DoraAPF.org.Models;
using DoraAPF.org.Models.Payment;
using DoraAPF.org.Models.Payment.Helcim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoraAPF.org.Data.Entities;
using DoraAPF.org.Facade.Interfaces.Repository;

namespace DoraAPF.org.Facade.Services.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly IThirdPartyPaymentService _helcimPaymentService;
        private readonly IRepository<BillingInfo> _billingRepository;
        private readonly IRepository<Payment> _paymentRepository;
        public PaymentService(IThirdPartyPaymentService helcimPaymentService, IRepository<BillingInfo> billingRepository, IRepository<Payment> paymentRepository)
        {
            _helcimPaymentService = helcimPaymentService;
            _billingRepository = billingRepository;
            _paymentRepository = paymentRepository;
        }

        public PaymentResultModel DoPayment(PaymentModel paymentModel)
        {
            var result = new PaymentResultModel();

            try
            {
                var createDate = DateTime.UtcNow;

                var billingInfo = new BillingInfo()
                {
                    FirstName = paymentModel.FirstName,
                    Email = paymentModel.Email,
                    CreatedOn = createDate,
                    Country = paymentModel.Country,
                    Active = false,
                    Address1 = paymentModel.Address1,
                    Address2 = paymentModel.Address2,
                    City = paymentModel.City,
                    LastName = paymentModel.LastName,
                    Phone = paymentModel.Phone,
                    PostalCode = paymentModel.PostalCode,
                    State = paymentModel.State,
                    Title = paymentModel.Title,
                    Payment = new List<Payment> {
                      
                   }
                };

                var payment = new Payment
                {
                    Active = false,
                    TransactionId = string.Empty,
                    AuthCode = string.Empty,
                    AmountPaid = decimal.Parse(paymentModel.PaymentAmount),
                    CardHolderName = paymentModel.CardHolderName,
                    CardF4L4 = paymentModel.CardNumber.Substring(0, 4) + paymentModel.CardNumber.Substring(paymentModel.CardNumber.Length - 4, 4),
                    CurrencyId = (int)Currency.CAD,
                    PaymentDate = createDate,
                    PaymentType = (int)PaymentType.Purchase
                };

                billingInfo.Payment.Add(payment);

                var data = _billingRepository.Add(billingInfo);

                var request = new HelcimBasicRequestModel()
                {
                    OrderNumber = "Dora-" + DateTime.Now.ToString("yyyyMMddhhmmss"),
                    Amount = decimal.Parse(paymentModel.PaymentAmount),
                    CreditCard = new HelcimCreditCardRequestModel()
                    {
                        CardHolderName = paymentModel.CardHolderName,
                        CardNumber = paymentModel.CardNumber,
                        CardExpiry = paymentModel.CardExpiry,
                        CardCVV = paymentModel.CardCVV,
                        CardHolderAddress = paymentModel.Address1,
                        CardHolderPostalCode = paymentModel.PostalCode
                    }
                };

                result = (PaymentResultModel)_helcimPaymentService.ProcessPayment(request);

                if (result.Success && result.Approved)
                {
                    billingInfo.Active = true;
                    payment.Active = true;
                    payment.TransactionId = result.TransactionId;
                    payment.AuthCode = result.AuthCode;

                    _billingRepository.Update(billingInfo);

                    result.PaymentId = payment.Id;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}

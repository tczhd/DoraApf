using DoraAPF.org.Facade.Interfaces.Payment;
using DoraAPF.org.Models;
using DoraAPF.org.Models.Payment.Helcim;
using System.Text;
using System.Xml;
using System.Net;
using System.Collections.Specialized;
using Microsoft.Extensions.Options;
using System.Xml.Serialization;
using System.IO;
using DoraAPF.org.Models.Payment;

namespace DoraAPF.org.Facade.Services.Payments
{
    public class HelcimPaymentService : IThirdPartyPaymentService
    {
        private const string LIVE_URL = "https://secure.myhelcim.com/api/";

        public HelcimPaymentService(IOptions<HelcimAccount> optionsAccessor)
        {
            _helcimAccount = optionsAccessor.Value;
        }

        public HelcimAccount _helcimAccount { get; }

        private XmlDocument BasicRequest(NameValueCollection values)
        {
            using (var client = new WebClient())
            {
                // EXECUTE REQUEST
                var response = client.UploadValues(LIVE_URL, values);

                // BUILD RESPONSE STRING
                var responseString = Encoding.Default.GetString(response);

                // BUILD XML DOCUMENT FROM RESPONSE
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(responseString);

                // CHECK RESPONSE
                if (doc != null)
                {
                    return doc;
                }

                return null;
            }
        }

        private NameValueCollection GetBasicData(HelcimBasicRequestModel data)
        {
            var values = new NameValueCollection();
            //values["accountId"] = data.AccountId;
            //values["apiToken"] = data.ApiToken;
            values["accountId"] = _helcimAccount.AccountId;
            values["apiToken"] = _helcimAccount.ApiToken;

            // Set to test
            values["test"] = "1";

            return values;
        }

        public Result ProcessPayment(BasicRequestModel requestModel)
        {
            Result result = new Result();

            var paymentData = (HelcimBasicRequestModel)requestModel;

            var values = GetBasicData(paymentData);
            values["transactionType"] = "purchase";
            values["terminalId"] = paymentData.TerminalId;
            //values["test"] = paymentData.Test ? "1" : "0";
            values["amount"] = paymentData.Amount.ToString("0.00");

            if (paymentData.CreditCard != null)
            {
                var creditCard = (HelcimCreditCardRequestModel)paymentData.CreditCard;
                values["cardHolderName"] = creditCard.CardHolderName;
                values["cardNumber"] = creditCard.CardNumber;
                values["cardExpiry"] = creditCard.CardExpiry;
                values["cardCVV"] = creditCard.CardCVV;
                values["cardHolderAddress"] = creditCard.CardHolderAddress;
                values["cardHolderPostalCode"] = creditCard.CardHolderPostalCode;
            }
            else
            {
                values["cardToken"] = paymentData.CardToken;
                values["cardF4L4"] = paymentData.CardF4L4;
                values["comments"] = paymentData.Comments;
            }

            var xmlDocument = BasicRequest(values);
            if (xmlDocument != null)
            {
                var helcimResult  = GetHelcimResult(xmlDocument);
                var paymentResult  = (PaymentResultModel)helcimResult;
                paymentResult.PaymentType = PaymentType.Purchase;
                paymentResult.Currency = paymentData.Currency;
                result = paymentResult;

                if (helcimResult.Response == "1" && helcimResult.ResponseMessage == "APPROVED")
                {
                    paymentResult.Approved = true;
                    result.Success = true;
                    result.Message = "Process payment success. ";
                }
                else {
                    result.Message = "Process payment failed ";
                }
            }
            else
            {
                result.Message = "Process payment failed ";
            }

            return result;
        }

        public Result ProcessVoid(BasicRequestModel requestModel)
        {
            var result = new Result();

            var paymentData = (HelcimBasicRequestModel)requestModel;

            var values = GetBasicData(paymentData);
            values["transactionType"] = "void";

            values["transactionId"] = paymentData.TransactionId;

            var data = BasicRequest(values);
            if (data != null)
            {
                result.Success = true;
                result.Message = "Process void success. ";
                result.Data = data;
            }
            else
            {
                result.Message = "Process void failed. ";
            }

            return result;
        }

        public Result ProcessRefund(BasicRequestModel requestModel)
        {
            var result = new Result
            {
                Message = "Process refund failed. "
            };

            var paymentData = (HelcimBasicRequestModel)requestModel;

            var values = GetBasicData(paymentData);
            values["transactionType"] = "refund";
            values["terminalId"] = paymentData.TerminalId;
            values["test"] = paymentData.Test ? "1" : "0";
            values["amount"] = paymentData.Amount.ToString("0.00");

            if (paymentData.CreditCard != null)
            {
                var creditCard = (HelcimCreditCardRequestModel)paymentData.CreditCard;
                values["cardHolderName"] = creditCard.CardHolderName;
                values["cardNumber"] = creditCard.CardNumber;
                values["cardExpiry"] = creditCard.CardExpiry;
                values["cardCVV"] = creditCard.CardCVV;

                var data = BasicRequest(values);
                if (data != null)
                {
                    result.Success = true;
                    result.Message = "Process refund success. ";
                    result.Data = data;
                }
            }

            return result;
        }

        private HelcimResponseModel GetHelcimResult(XmlDocument xmlDocument)
        {
            var serializer = new XmlSerializer(typeof(HelcimResponseModel), new XmlRootAttribute("message"));
            var stringReader = new StringReader(xmlDocument.InnerXml);
            var result = (HelcimResponseModel)serializer.Deserialize(stringReader);

            return result;
        }
    }
}

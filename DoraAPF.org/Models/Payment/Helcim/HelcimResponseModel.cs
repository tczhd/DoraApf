using System;
using System.Globalization;
using System.Xml.Serialization;

namespace DoraAPF.org.Models.Payment.Helcim
{
    public class HelcimResponseModel
    {
        [XmlElement("response")]
        public string Response { get; set; }
        [XmlElement("responseMessage")]
        public string ResponseMessage { get; set; }
        [XmlElement("notice")]
        public string Notice { get; set; }
        [XmlElement("transaction")]
        public HelcimTransactionResponseModel transaction { get; set; }


        public static implicit operator PaymentResultModel(HelcimResponseModel source)
        {
            var provider = CultureInfo.InvariantCulture;
            string format = "yyyy-MM-dd HH:mm:ss";

            return new PaymentResultModel
            {
                AuthCode = source.transaction.ApprovalCode,
                CardHolderName = source.transaction.CardHolderName,
                TransactionId = source.transaction.TransactionId,
                PaymentAmount = decimal.Parse(source.transaction.Amount),
                PaymentDate = DateTime.ParseExact($"{source.transaction.Date} {source.transaction.Time}", format, provider),
                EncryptCardNumber = source.transaction.CardNumber
            };
        }
    }
}
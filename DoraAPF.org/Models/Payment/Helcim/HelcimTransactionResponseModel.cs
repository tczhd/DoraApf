using System.Xml.Serialization;

namespace DoraAPF.org.Models.Payment.Helcim
{
    public class HelcimTransactionResponseModel
    {
        [XmlElement("transactionId")]
        public string TransactionId { get; set; }
        [XmlElement("type")]
        public string Type { get; set; }
        [XmlElement("date")]
        public string Date { get; set; }
        [XmlElement("time")]
        public string Time { get; set; }
        [XmlElement("cardHolderName")]
        public string CardHolderName { get; set; }
        [XmlElement("amount")]
        public string Amount { get; set; }
        [XmlElement("currency")]
        public string Currency { get; set; }
        [XmlElement("cardNumber")]
        public string CardNumber { get; set; }
        [XmlElement("approvalCode")]
        public string ApprovalCode { get; set; }
    }
}

using System.Runtime.Serialization;

namespace DoraAPF.org.Models.WebPages
{
    [DataContract(Name = "web_page_request")]
    public class WebPageRequestModel
    {
        [DataMember(Name = "web_page_type_id")]
        public int WebPageTypeId { get; set; }
        [DataMember(Name = "html_content")]
        public string HtmlContent { get; set; }
    }
}
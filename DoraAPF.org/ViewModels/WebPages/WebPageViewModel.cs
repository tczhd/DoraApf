using DoraAPF.org.Models.WebPages;
using System.ComponentModel.DataAnnotations;

namespace DoraAPF.org.ViewModels.WebPages
{
    public class WebPageViewModel
    {
        [Display(Name = "WebPage Id")]
        public int Id { get; set; }
        [Display(Name = "WebPage Type Id")]
        public int WebPageTypeId { get; set; }
        [Display(Name = "WebPage Name")]
        public string Name { get; set; }
        [Display(Name = "WebPage Html Content")]
        public string HtmlContent { get; set; }

        public static implicit operator WebPageViewModel(WebPageModel source)
        {
            return new WebPageViewModel
            {
                HtmlContent = source.HtmlContent,
                Id = source.Id,
                Name = source.Name,
                WebPageTypeId = source.WebPageTypeId
            };
        }
    }
}

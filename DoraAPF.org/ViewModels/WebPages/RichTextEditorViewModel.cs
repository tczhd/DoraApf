using System.ComponentModel.DataAnnotations;

namespace DoraAPF.org.ViewModels.WebPages
{
    public class RichTextEditorViewModel
    {
        //[AllowHtml]
        [Display(Name = "Message")]
        public string Message { get; set; }
    }
}

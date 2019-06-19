using System.ComponentModel;

namespace DoraAPF.org.Models
{
    public enum Title
    {
        [Description("Mr. ")]
        Mr = 1,
        [Description("Mrs. ")]
        Mrs = 2,
        [Description("MS. ")]
        Ms = 3,
        [Description("Miss. ")]
        Miss = 4
    }
}

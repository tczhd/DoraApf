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

    public enum PaymentType
    {
        [Description("Purchase")]
        Purchase = 1,
        [Description("Void")]
        Void = 2,
        [Description("Refund")]
        Refund = 3
    }

    public enum Currency
    {
        [Description("USD")]
        USD = 1,
        [Description("CAD")]
        CAD = 2
    }
}

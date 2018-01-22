using System.ComponentModel;

namespace TaskSystem.BL.Models
{
    public enum PaymentTypeEnum
    {
        [Description("Visa")] Visa = 1,
        [Description("Mastercard")] Mastercard = 2,
        [Description("Paypal")] Paypal = 3,
        [Description("Cache")] Cache = 4
    }
}
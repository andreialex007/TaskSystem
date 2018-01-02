using System.ComponentModel;

namespace TaskSystem.BL.Models
{
    public enum StatusEnum
    {
        [Description("Draft")] Draft = 1,
        [Description("In Progress")] InProgress = 2,
        [Description("On Hold")] OnHold = 3,
        [Description("Done")] Done = 4,
        [Description("Voided")] Voided = 5,
    }
}
using System.ComponentModel;

namespace TaskSystem.BL.Models
{
    public enum PriorityEnum
    {
        [Description("Low")] Low = 1,
        [Description("Normal")] Normal = 2,
        [Description("High")] High = 3
    }
}
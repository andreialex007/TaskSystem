using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TaskSystem.BL.Models
{
    public enum RoleEnum
    {
        [Description("Supervisor")]
        Supervisor = 1,
        [Description("Technician")]
        Technician = 2
    }
}

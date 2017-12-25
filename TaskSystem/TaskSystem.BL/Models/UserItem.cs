using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TaskSystem.BL.Extensions;
using TaskSystem.BL.Utils;

namespace TaskSystem.BL.Models
{
    public class UserItem : ViewModelBase
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public string Password { get; set; }

        [Required]
        public int Role { get; set; }

        public string RoleName => Role == 0 ? string.Empty : Role.CastTo<RoleEnum>().DescriptionAttr();

        public Dictionary<int, string> AvaliableRoles => EnumUtil.ToDictionary<RoleEnum>();
    }
}
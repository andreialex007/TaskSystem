using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TaskSystem.BL.Extensions;
using TaskSystem.BL.Utils;

namespace TaskSystem.BL.Models
{
    public class WorkTaskItem : ViewModelBase
    {
        public WorkTaskItem()
        {
            Priority = PriorityEnum.Normal.CastTo<int>();
            Status = StatusEnum.Draft.CastTo<int>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select status")]
        public int Status { get; set; }
        public string StatusName => this.Status.CastTo<StatusEnum>().DescriptionAttr();

        [Range(1, int.MaxValue, ErrorMessage = "Please select priority")]
        public int Priority { get; set; }
        public string PriorityName => this.Status.CastTo<PriorityEnum>().DescriptionAttr();

        public Dictionary<int, string> AvaliablePriorities => EnumUtil.ToDictionary<PriorityEnum>();

        public Dictionary<int, string> AvaliableStatuses => EnumUtil.ToDictionary<StatusEnum>();

        [Required]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "User")]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "CustomerUser")]
        public int? CustomerUserId { get; set; }
    }
}

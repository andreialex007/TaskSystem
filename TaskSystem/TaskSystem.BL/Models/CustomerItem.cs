using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TaskSystem.DL.Entities.Customers;

namespace TaskSystem.BL.Models
{
    public class CustomerItem : ViewModelBase
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Notes { get; set; }

        public List<CustomerUserItem> Users { get; set; } = new List<CustomerUserItem>();
    }
}

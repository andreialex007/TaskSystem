using System;
using System.Collections.Generic;
using System.Text;

namespace TaskSystem.BL.Models
{
    public class CustomerItem : ViewModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }
    }
}

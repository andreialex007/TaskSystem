using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TaskSystem.DL.Entities.Customers;

namespace TaskSystem.BL.Models
{
    public class AutocompleteItem : ViewModelBase
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}

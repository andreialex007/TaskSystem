﻿namespace TaskSystem.BL.Models
{
    public class CustomerUserItem : ViewModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int CustomerId { get; set; }
    }
}
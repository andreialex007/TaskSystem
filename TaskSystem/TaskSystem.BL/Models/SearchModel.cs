using System;
using System.Collections.Generic;
using System.Text;

namespace TaskSystem.BL.Models
{
    public class SearchModel<T> 
    {
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<T> data { get; set; }
    }
}

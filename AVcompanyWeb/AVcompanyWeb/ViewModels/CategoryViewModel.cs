using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AVcompanyWeb.ViewModels
{
    public class CategoryViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string abbreviation { get; set; }
        //public Nullable<int> quantity { get; set; }
    }
}
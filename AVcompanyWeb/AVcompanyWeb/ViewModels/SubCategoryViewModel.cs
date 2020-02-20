using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AVcompanyWeb.ViewModels
{
    public class SubCategoryViewModel
    {
        public int id { get; set; }
        public Nullable<int> categoryId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Nullable<bool> isActive { get; set; }
    }
}
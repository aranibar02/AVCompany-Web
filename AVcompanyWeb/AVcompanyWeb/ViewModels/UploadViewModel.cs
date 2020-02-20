using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AVcompanyWeb.ViewModels
{
    public class UploadViewModel
    {
        public int id { get; set; }
        public Nullable<int> productId { get; set; }
        public string name { get; set; }
        public string locationPath { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string srcImage { get; set; }

    }
}
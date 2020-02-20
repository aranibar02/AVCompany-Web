using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AVcompanyWeb.ViewModels
{
    public class MessageViewModel
    {
        public string heading { set; get; }
        public string text { get; set; }
        public string position { get; set; }
        public string loaderBg { get; set; }
        public string icon { get; set; }
        public int hideAfter { get; set; }
        public int stack { get; set; }
    }
}
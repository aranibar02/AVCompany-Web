//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AVcompanyWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PriceProduct
    {
        public int id { get; set; }
        public Nullable<int> productId { get; set; }
        public Nullable<int> priceTypeId { get; set; }
        public Nullable<double> priceWithoutIGV { get; set; }
        public Nullable<double> priceWithIGV { get; set; }
        public Nullable<bool> isActive { get; set; }
    
        public virtual PriceType PriceType { get; set; }
        public virtual Product Product { get; set; }
    }
}
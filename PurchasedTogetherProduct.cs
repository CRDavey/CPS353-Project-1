//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OneStopGaming
{
    using System;
    using System.Collections.Generic;
    
    public partial class PurchasedTogetherProduct
    {
        public int ID { get; set; }
        public int Product1 { get; set; }
        public int Product2 { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Product Product3 { get; set; }
    }
}
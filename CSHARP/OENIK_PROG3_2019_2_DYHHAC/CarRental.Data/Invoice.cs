//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarRental.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Invoice
    {
        public int invoiceID { get; set; }
        public int rentID { get; set; }
        public Nullable<int> total { get; set; }
        public int completed { get; set; }
        public System.DateTime time { get; set; }
    
        public virtual Rent Rent { get; set; }
    }
}
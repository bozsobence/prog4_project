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
    
    public partial class licenses
    {
        public string licenseID { get; set; }
        public int userID { get; set; }
        public string category { get; set; }
        public System.DateTime startDate { get; set; }
        public System.DateTime expiryDate { get; set; }
        public Nullable<int> penaltyPoints { get; set; }
    
        public virtual users users { get; set; }
    }
}

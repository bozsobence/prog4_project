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
    
    public partial class rents
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public rents()
        {
            this.complaints = new HashSet<complaints>();
            this.invoices = new HashSet<invoices>();
        }
    
        public int rentID { get; set; }
        public int userID { get; set; }
        public string carID { get; set; }
        public System.DateTime starttime { get; set; }
        public Nullable<System.DateTime> endtime { get; set; }
        public Nullable<int> distance { get; set; }
    
        public virtual cars cars { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<complaints> complaints { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<invoices> invoices { get; set; }
        public virtual users users { get; set; }
    }
}

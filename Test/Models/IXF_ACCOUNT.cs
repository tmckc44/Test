//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class IXF_ACCOUNT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IXF_ACCOUNT()
        {
            this.IXF_TRANSACTION = new HashSet<IXF_TRANSACTION>();
        }
    
        public int ID { get; set; }
        public string AccountNumber { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IXF_TRANSACTION> IXF_TRANSACTION { get; set; }
        public virtual IXF_TRANSACTION_TYPE IXF_TRANSACTION_TYPE { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kondominium_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class uploadfileh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public uploadfileh()
        {
            this.uploadfiled = new HashSet<uploadfiled>();
        }
    
        public int UploadFileHId { get; set; }
        public string FileName { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public string UserId { get; set; }
        public Nullable<int> Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<uploadfiled> uploadfiled { get; set; }
    }
}

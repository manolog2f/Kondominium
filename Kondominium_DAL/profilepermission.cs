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
    
    public partial class profilepermission
    {
        public string ProfileId { get; set; }
        public int ProfilePermissionId { get; set; }
        public int Active { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string CreateByUserId { get; set; }
        public string ModifiedByUserId { get; set; }
        public Nullable<int> Search { get; set; }
        public Nullable<int> Save { get; set; }
        public Nullable<int> Edit { get; set; }
        public Nullable<int> New { get; set; }
        public Nullable<int> Delete { get; set; }
    }
}

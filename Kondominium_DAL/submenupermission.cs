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
    
    public partial class submenupermission
    {
        public int SubMenuPermissionId { get; set; }
        public int SubMenuId { get; set; }
        public string ProfileId { get; set; }
        public int Enabled { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime ModifieDate { get; set; }
        public string CreateByUserId { get; set; }
        public string ModifiedByUserId { get; set; }
    
        public virtual profile profile { get; set; }
        public virtual submenu submenu { get; set; }
    }
}

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
    
    public partial class field
    {
        public string FieldId { get; set; }
        public string ObjectId { get; set; }
        public string FieldName { get; set; }
        public int Obligatory { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> ModifDate { get; set; }
        public string CreateByUserId { get; set; }
        public string ModifiedByUserId { get; set; }
    }
}

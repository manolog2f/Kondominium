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
    
    public partial class propiedadesdocs
    {
        public int PropiedadesDocId { get; set; }
        public int PropiedadId { get; set; }
        public string DocumentType { get; set; }
        public string UrlDocument { get; set; }
        public byte[] Document { get; set; }
        public Nullable<System.DateTime> FechaDeCreacion { get; set; }
        public Nullable<System.DateTime> FechaDeModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
    
        public virtual propiedades propiedades { get; set; }
    }
}

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
    
    public partial class clientepropiedaddocs
    {
        public int ClientePropiedadDocsId { get; set; }
        public int ClienteId { get; set; }
        public int PropiedadId { get; set; }
        public string TipoCliente { get; set; }
        public string DocumentType { get; set; }
        public string UrlDocument { get; set; }
        public byte[] Document { get; set; }
        public Nullable<System.DateTime> FechaDeCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<bool> Eliminado { get; set; }
    
        public virtual clientepropiedad clientepropiedad { get; set; }
    }
}

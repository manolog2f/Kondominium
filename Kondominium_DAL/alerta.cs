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
    
    public partial class alerta
    {
        public int AlertaId { get; set; }
        public int AlertaTipoId { get; set; }
        public string AlertaTitulo { get; set; }
        public string UserId { get; set; }
        public string Mensaje { get; set; }
        public System.DateTime FechaAlerta { get; set; }
        public bool Leido { get; set; }
        public Nullable<System.DateTime> FechaLectura { get; set; }
        public string ActionUrl { get; set; }
    
        public virtual user user { get; set; }
        public virtual alertatipo alertatipo { get; set; }
    }
}

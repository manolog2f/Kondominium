//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
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

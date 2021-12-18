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
    
    public partial class clientepropiedad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public clientepropiedad()
        {
            this.clientepropiedaddocs = new HashSet<clientepropiedaddocs>();
        }
    
        public int ClienteId { get; set; }
        public int PropiedadId { get; set; }
        public string TipoCliente { get; set; }
        public string Justificacion { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<System.DateTime> FechaDeCreacion { get; set; }
        public Nullable<System.DateTime> FechaDeModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
    
        public virtual clientes clientes { get; set; }
        public virtual propiedades propiedades { get; set; }
        public virtual clientepropiedaddetalle clientepropiedaddetalle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<clientepropiedaddocs> clientepropiedaddocs { get; set; }
    }
}
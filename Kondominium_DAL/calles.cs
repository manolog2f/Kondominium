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
    
    public partial class calles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public calles()
        {
            this.propiedades = new HashSet<propiedades>();
        }
    
        public string CalleId { get; set; }
        public string CalleDescripcion { get; set; }
        public Nullable<System.DateTime> FechaDeCreacion { get; set; }
        public System.DateTime FechaDeModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
        public bool Eliminado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<propiedades> propiedades { get; set; }
    }
}
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
    
    public partial class aranceles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public aranceles()
        {
            this.propiedades = new HashSet<propiedades>();
        }
    
        public int ArancelId { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public Nullable<bool> Activo { get; set; }
        public System.DateTime FechaDeCreacion { get; set; }
        public System.DateTime FechaDeModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
        public bool Eliminado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<propiedades> propiedades { get; set; }
    }
}

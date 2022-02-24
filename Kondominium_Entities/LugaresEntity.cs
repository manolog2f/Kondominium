using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kondominium_Entities
{
    public class LugaresEntity
    {
        [DisplayName("Id de Lugar")]
        public int LugarId { get; set; }
        [DisplayName("Nombre del lugar")]
        [Required]
        [MinLength(1)]
        [StringLength(100, ErrorMessage = "El nombre no debe exceder los 100 caracteres")]
        public string Nombre { get; set; }
        [StringLength(250, ErrorMessage = "La descripcion puede tener un maximo de 250 caracteres")]
        public string Descripcion { get; set; }
        public Nullable<System.DateTime> FechaDeCreacion { get; set; }
        public Nullable<System.DateTime> FechaDeModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
        public bool Eliminado { get; set; }
    }
}

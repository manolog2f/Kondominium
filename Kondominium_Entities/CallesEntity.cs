using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kondominium_Entities
{
    public class CallesEntity
    {

        [DisplayName("Id de Calle")]
        public string CalleId { get; set; }
        [DisplayName("Calle Descripcion")]
        [StringLength(45, ErrorMessage = "La descripción no debe exceder de 45 caracteres")]
        public string CalleDescripcion { get; set; }
        [DisplayName("Fecha de creación")]
        public Nullable<System.DateTime> FechaDeCreacion { get; set; }
        [DisplayName("Fecha de Modificación")]
        public System.DateTime FechaDeModificacion { get; set; }
        [DisplayName("Creado por")]
        public string CreadoPor { get; set; }
        [DisplayName("Modificado por")]
        public string ModificadoPor { get; set; }
        public bool Eliminado { get; set; }


    }
}

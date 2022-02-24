using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kondominium_Entities
{
    public class AvenidasEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Id de Avenida")]
        [Required]
        [MinLength(1)]
        [StringLength(5, ErrorMessage = "El Id no debe exceder de 5 caracteres")]
        public string AvenidaId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Avenida Descripcion")]
        [StringLength(45, ErrorMessage = "La descripción no debe exceder de 45 caracteres")]
        [Required]
        public string AvenidaDescripcion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Fecha de Creación")]
        public Nullable<System.DateTime> FechaDeCreacion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Fecha de Modificación")]
        public System.DateTime FechaDeModificacion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Creado por")]
        public string CreadoPor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Modificado por")]
        public string ModificadoPor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Eliminado { get; set; }

    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities
{
   public class PaseoEntity
    {
        [DisplayName("Id de Paseo")]
        [MaxLength(5, ErrorMessage = "Maximo de {1} Caracteres permitidos")]
        public string PaseoId { get; set; }
        /// <summary>
        /// Descripcion del Paseo
        /// </summary>
        [DisplayName("Descripción")]
        [StringLength(45, ErrorMessage = "La descripción no debe exceder de 45 caracteres")]
        public string PaseoDescripcion { get; set; }
        /// <summary>
        /// Fecha de creacion
        /// </summary>
        [DisplayName("Fecha de Creación")]
        public System.DateTime FechaDeCreacion { get; set; }
        /// <summary>
        /// Fecha de Modificacion
        /// </summary>
        [DisplayName("Fecha de Modificación")]
        public System.DateTime FechaDeModificacion { get; set; }
        /// <summary>
        /// Registro creado por
        /// </summary>
        [DisplayName("Creado Por")]
        public string CreadoPor { get; set; }
        /// <summary>
        /// Registro Modificado por
        /// </summary>
        [DisplayName("Modificado Por")]
        public string ModificadoPor { get; set; }

        public bool Eliminado { get; set; }
    }
}

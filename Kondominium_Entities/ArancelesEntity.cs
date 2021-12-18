using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities
{
    /// <summary>
    /// Entidad referente al Arancel
    /// </summary>

    public class ArancelesEntity
    {

        /// <summary>
        /// Id de Arancel
        /// </summary>
        [DisplayName("Id de Arancel")]
        public int ArancelId { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        [DisplayName("Descripcion")]
        [StringLength(50, ErrorMessage = "La descripción no debe exceder de 50 caracteres")]
        public string Descripcion { get; set; }
        /// <summary>
        /// Id del Arancel
        /// </summary>
        [DisplayName("Monto")]
        [RegularExpression(@"^(((\d{1,3})(,\d{3})*)|(\d+))(.\d+)?$", ErrorMessage = "Solo debe ingresar numeros")]
        [Range(0, Int32.MaxValue)]
        public decimal Monto { get; set; }
        /// <summary>
        /// Activo
        /// </summary>
        [DisplayName("Activo")]
        public Boolean Activo { get; set; }
        /// <summary>
        /// Fecha de Creacion
        /// </summary>
        [DisplayName("Fecha de Creación")]
        public System.DateTime FechaDeCreacion { get; set; }
        /// <summary>
        /// Fecha de Modificaion
        /// </summary>
        [DisplayName("Fecha de Modificación")]
        public System.DateTime FechaDeModificacion { get; set; }
        /// <summary>
        /// Creado por
        /// </summary>
        [DisplayName("Creado por")]
        public string CreadoPor { get; set; }
        /// <summary>
        /// Modificado por
        /// </summary>
        [DisplayName("Modificado por")]
        public string ModificadoPor { get; set; }
        /// <summary>
        /// Eliminado
        /// </summary>
        [DisplayName("Eliminado")]
        public bool Eliminado { get; set; }
    }
}
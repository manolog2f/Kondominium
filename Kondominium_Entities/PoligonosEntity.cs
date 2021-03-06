using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kondominium_Entities
{
    /// <summary>
    /// Entidad referente al Poligono
    /// </summary>
    public class PoligonosEntity
    {
        /// <summary>
        /// Poligono Id - 
        /// </summary>
        [DisplayName("Id de Poligono")]
        [MaxLength(6, ErrorMessage = "Maximo de {1} Caracteres permitidos")]
        public string PoligonoId { get; set; }
        /// <summary>
        /// Descripcion del Poligono
        /// </summary>
        [DisplayName("Descripción")]
        [StringLength(45, ErrorMessage = "La descripción no debe exceder de 45 caracteres")]
        public string PoligonoDescripcion { get; set; }

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

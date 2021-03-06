using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kondominium_Entities
{

    public class AlamedaEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [StringLength(5, ErrorMessage = "El id no puede exceder los 5 caracteres")]
        [DisplayName("Id de Alameda")]
        [Required]
        public string AlamedaId { get; set; }
        [StringLength(45, ErrorMessage = "Debe digitar una descripcion")]
        [DisplayName("Alameda Descripcion")]
        [Required]
        public string AlamedaDescripcion { get; set; }

       
        public Nullable<System.DateTime> FechaDeCreacion { get; set; }
        public System.DateTime FechaDeModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
        public bool Eliminado { get; set; }
    }
}


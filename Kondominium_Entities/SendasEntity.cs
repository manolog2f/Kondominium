using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities
{
    public class SendasEntity
    {

        [DisplayName("Id de Senda")]
        public string SendaId { get; set; }
        [DisplayName("Descripcion de Senda")]
        [StringLength(45, ErrorMessage = "La descripción no debe exceder de 45 caracteres")]
        public string SendaDescripcion { get; set; }
        [DisplayName("Fecha de Creación")]
        public Nullable<System.DateTime> FechaDeCreacion { get; set; }
        [DisplayName("Fecha de Modificación")]
        public System.DateTime FechaDeModificacion { get; set; }
        [DisplayName("Creado Por")]
        public string CreadoPor { get; set; }
        [DisplayName("Modificado Por")]
        public string ModificadoPor { get; set; }
        public bool Eliminado { get; set; }

        
    }
}

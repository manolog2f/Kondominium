using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities
{
   public class ClientePropiedadDetalleEntity
    {

            public int ClienteId { get; set; }
            public int PropiedadId { get; set; }
            public string TipoCliente { get; set; }
            [DataType(DataType.Date)]
            [DisplayName("Fecha de Inicio"), Required(ErrorMessage = "Debe ingresar la fecha de inicio del contrato.")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
            public Nullable<System.DateTime> FechaInicio { get; set; }
            [DataType(DataType.Date)]
            [DisplayName("Fecha de Finalziacion"), Required(ErrorMessage = "Debe ingresar la fecha de fin del contrato.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> FechaFin { get; set; }
            public bool Autorrenovable { get; set; }
            public bool InquilinoResponsable { get; set; }
            public string Observacion { get; set; }
            public string Parentesco { get; set; }
            public Nullable<System.DateTime> FechaDeCreacion { get; set; }
            public Nullable<System.DateTime> FechaDeModificacion { get; set; }
            public string CreadoPor { get; set; }
            public string ModificadoPor { get; set; }
        }
}

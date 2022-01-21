using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kondominium_Entities
{
    public class CuentasGeneradasEntity
    {
        [DisplayName("Periodo")]
        public string PeriodoGenerado { get; set; }

        public string Justificacion { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Fecha de Facturacion"), Required(ErrorMessage = "Debe ingresar la fecha correspondiente.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> FechaDeGeneracion { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Fecha de Vencimiento"), Required(ErrorMessage = "Debe ingresar la fecha correspondiente.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> FechaDeVencimiento { get; set; }

        public Nullable<System.DateTime> FechaDeCreacion { get; set; }
        public Nullable<System.DateTime> FechaDeModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPo { get; set; }
    }
}

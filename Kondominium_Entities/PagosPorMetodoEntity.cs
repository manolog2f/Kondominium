using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities
{
    public class PagosPorMetodoEntity
    {
        [DisplayName("Metodo de Pago")]
        public string MetodoDePago { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [DisplayName("Fecha")]
        public DateTime? Fecha { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        [DisplayName("Monto Total")]
        public decimal Monto { get; set; }
    }
}
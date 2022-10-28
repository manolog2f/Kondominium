using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities
{
    public class DashClientesMorosos
    {
        [DisplayName("Condomino Id")]
        public int ClienteId { get; set; }

        [DisplayName("Nombre Completo")]
        public string FullName { get; set; }

        [DisplayName("Propiedad Id")]
        public int PropiedadId { get; set; }

        [DisplayName("Propiedad")]
        public string VPropiedad { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        [DisplayName("Saldo")]
        public decimal SaldoActual { get; set; }
    }
}
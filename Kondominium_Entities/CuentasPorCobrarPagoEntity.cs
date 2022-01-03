using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities
{
    public class CuentasPorCobrarPagoEntity
    {
            public int CuentasPorCobrarPagoId { get; set; }
            public string VaucherNumber { get; set; }
            public Nullable<int> ClienteId { get; set; }
            public string MetodoPago { get; set; }
            public string ReferenciaPago { get; set; }
            public string Observacion { get; set; }
            public Nullable<System.DateTime> FechaDeCreacion { get; set; }
            public Nullable<System.DateTime> FechaDeModificacion { get; set; }
            public string CreadoPor { get; set; }
            public string ModificadoPor { get; set; }
        public decimal Monto { get; set; }
    }
}

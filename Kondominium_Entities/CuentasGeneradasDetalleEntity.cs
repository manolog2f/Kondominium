using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities
{
 public class CuentasGeneradasDetalleEntity
    {
        public string PeriodoGenerado { get; set; }
        public int PropiedadId { get; set; }
        public int ClienteId { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<System.DateTime> FechaDeVencimiento { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<System.DateTime> FechaDeCreacion { get; set; }
        public Nullable<System.DateTime> FechaDeModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities
{
    public class CuentasGeneradasEntity
    {
        public string PeriodoGenerado { get; set; }
        public string Justificacion { get; set; }
        public Nullable<System.DateTime> FechaDeGeneracion { get; set; }
        public Nullable<System.DateTime> FechaDeVencimiento { get; set; }
        public Nullable<System.DateTime> FechaDeCreacion { get; set; }
        public Nullable<System.DateTime> FechaDeModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPo { get; set; }
    }
}

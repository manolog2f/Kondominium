using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities
{
    public class ConfigCobrosMensualDetEntity
    {
        public int IdConfig { get; set; }
        public int ProductoId { get; set; }
        public string ProductoDescripcion { get; set; }
        public Nullable<decimal> Monto { get; set; }
        public Nullable<System.DateTime> FechaDeCreacion { get; set; }
        public Nullable<System.DateTime> FechaDeModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
    }
}

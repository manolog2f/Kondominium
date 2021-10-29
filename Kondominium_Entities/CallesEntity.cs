using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities
{
    public  class CallesEntity
    {
        

        public string CalleId { get; set; }
        public string CalleDescripcion { get; set; }
        public Nullable<System.DateTime> FechaDeCreacion { get; set; }
        public System.DateTime FechaDeModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
        public bool Eliminado { get; set; }

        
    }
}

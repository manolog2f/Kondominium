using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities
{
  public  class ConfigCobrosMensualEntity
    {
        public int IdConfig { get; set; }
        [Range(1, 30)]
        public Nullable<int> DiaDeGeneracion { get; set; }
        [Range(1, 30)]
        public Nullable<int> DiaVencimiento { get; set; }
        public Nullable<System.DateTime> FechaDeCreacion { get; set; }
        public Nullable<System.DateTime> FechaDeModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
    }
}

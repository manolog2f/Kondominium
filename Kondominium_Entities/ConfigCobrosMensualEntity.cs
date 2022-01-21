using System;
using System.ComponentModel.DataAnnotations;

namespace Kondominium_Entities
{
    public class ConfigCobrosMensualEntity
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

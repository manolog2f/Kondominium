using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kondominium_Entities
{
    public class ConfigCobrosMensualDetEntity
    {
        public int IdDetalleConf { get; set; }
        public int IdConfig { get; set; }
        public int ProductoId { get; set; }
        public string ProductoDescripcion { get; set; }
        public Nullable<decimal> Monto { get; set; }
        public Nullable<System.DateTime> FechaDeCreacion { get; set; }
        public Nullable<System.DateTime> FechaDeModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }

        /// <summary>
        /// Tamaño de la propiedad en varas cuadradas
        /// </summary>
        [DisplayName("Tamaño de la propiedad V2")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal MTamañoV2 { get; set; }
    }
}
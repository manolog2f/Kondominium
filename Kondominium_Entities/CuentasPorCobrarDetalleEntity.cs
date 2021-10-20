using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Kondominium_Entities
{
    public class CuentasPorCobrarDetalleEntity
    {
        /// <summary>
        /// Numero de Vaucher
        /// </summary>
        [DisplayName("Numero de Vaucher")]
        public string VaucherNumber { get; set; }
        /// <summary>
        /// Id detalle
        /// </summary>
        [DisplayName("Id detalle")]
        public int DetalleId { get; set; }
        /// <summary>
        /// Producto Id
        /// </summary>
        [DisplayName("Producto Id")]
        public int ProductoId { get; set; }
        /// <summary>
        /// Descripcion de detalle
        /// </summary>
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        /// <summary>
        /// Monto detalle
        /// </summary>
        [DisplayName("Monto")]
        public decimal Monto { get; set; }
        /// <summary>
        /// Fecha de Creacion
        /// </summary>
        [DisplayName("Fecha de creación")]
        public System.DateTime FechaDeCreacion { get; set; }
        /// <summary>
        /// Fecha de Modificación
        /// </summary>
        [DisplayName("Fecha de Modificación")]
        public System.DateTime FechaDeModificacion { get; set; }
        /// <summary>
        /// Creado por
        /// </summary>
        [DisplayName("Creado por")]
        public string CreadoPor { get; set; }
        /// <summary>
        /// Modificado por
        /// </summary>
        [DisplayName("Modificado por")]
        public string ModificadoPor { get; set; }

        public bool Eliminado { get; set; }
    }
}

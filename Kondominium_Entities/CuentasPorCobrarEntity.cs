using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Kondominium_Entities
{
    public class CuentasPorCobrarEntity

    {
        /// <summary>
        /// Numero de Vaucher
        /// </summary>
        [DisplayName("Numero de Vaucher")]
        public string VaucherNumber { get; set; }
        /// <summary>
        /// Id de Cliente
        /// </summary>
        [DisplayName("Id de Cliente")]
        public int ClienteId { get; set; }
        /// <summary>
        /// Cuentas por Cobrar
        /// </summary>
        [DisplayName("Cuentas por Cobrar")]
        public int TipoCxC { get; set; }
        /// <summary>
        /// Fecha de Emision
        /// </summary>
        [DisplayName("Fecha de Emision")]
        public System.DateTime FechaDeEmision { get; set; }
        /// <summary>
        /// Fecha de Vencimiento
        /// </summary>
        [DisplayName("Fecha de Vencimiento")]
        public System.DateTime FechaDeVencimiento { get; set; }
        /// <summary>
        /// Periodo de Facturado
        /// </summary>
        [DisplayName("Periodo de Facturado")]
        public string PeriodoFacturado { get; set; }
        /// <summary>
        ///  Total
        /// </summary>
        [DisplayName("Total")]
        public decimal Total { get; set; }
        /// <summary>
        /// NPE
        /// </summary>
        [DisplayName("NPE")]
        public string NPE { get; set; }
        /// <summary>
        /// BRCode
        /// </summary>
        [DisplayName("BRCode")]
        public string BRCode { get; set; }
        /// <summary>
        /// Fecha de Creacion
        /// </summary>
        [DisplayName("Fecha de Creación")]
        public System.DateTime FechaDeCreacion { get; set; }
        /// <summary>
        /// Fecha de Modificacion
        /// </summary>
        [DisplayName("Fecha de Modificación")]
        public System.DateTime FechaDeModificacion { get; set; }
        /// <summary>
        /// Registro creado por
        /// </summary>
        [DisplayName("Creado por")]
        public string CreadoPor { get; set; }
        /// <summary>
        /// Registro modificado por
        /// </summary>
        [DisplayName("Modificado por")]
        public string ModificadoPor { get; set; }

    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kondominium_Entities
{
    public class CuentasPorCobrarEntity

    {
        /// <summary>
        /// Numero de Vaucher
        /// </summary>
        [DisplayName("Numero de transaccion")]
        public string VaucherNumber { get; set; }
        /// <summary>
        /// Id de Cliente
        /// </summary>
        [DisplayName("Condómino")]
        public int ClienteId { get; set; }
        /// <summary>
        /// Cuentas por Cobrar
        /// </summary>
        [DisplayName("Cuentas por Cobrar")]
        public string TipoCxC { get; set; }
        /// <summary>
        /// Fecha de Emision
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayName("Fecha de Emision"), Required(ErrorMessage = "Debe ingresar la fecha correspondiente.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime FechaDeEmision { get; set; }
        /// <summary>
        /// Fecha de Vencimiento
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayName("Fecha de Vencimiento"), Required(ErrorMessage = "Debe ingresar la fecha correspondiente.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime FechaDeVencimiento { get; set; }
        /// <summary>
        /// Periodo de Facturado
        /// </summary>
        [DisplayName("Periodo Facturado")]
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

        public bool Eliminado { get; set; }
        /// <summary>
        /// Id de PRopiedad
        /// </summary>
        [DisplayName("Id de Propiedad")]
        public int PropiedadId { get; set; }
        /// <summary>
        /// 1 Creado\r\n2 Impreso\r\n3 Contabilizado\r\n4 Anulado
        /// </summary>
        public int Estado { get; set; }



        /// <summary>
        /// Condomino Full Name
        /// </summary>
        [DisplayName("Nombre Condomino")]
        public string FullNameCondomino { get; set; }

        /// <summary>
        /// Letra de la casa ** Opcional
        /// </summary>
        [DisplayName("Letra de la casa")]
        public string CasaLetra { get; set; }

        private string vpropiedadCasa;
        /// <summary>
        /// Propiedad
        /// </summary>
        [DisplayName("Propiedad")]
        public string VPropiedad   // property
        {
            get { return PoligonoId + '-' + Casa.ToString() + CasaLetra; }
            set { vpropiedadCasa = PoligonoId + '-' + Casa.ToString() + CasaLetra; }
        }

        /// <summary>
        /// Casa
        /// </summary>
        [DisplayName("Casa")]
        public int Casa { get; set; }
        /// <summary>
        /// Id de Polígono
        /// </summary>
        [DisplayName("Id de Polígono")]
        public string PoligonoId { get; set; }

    }
}

using System;
using System.ComponentModel;

namespace Kondominium_Entities
{
    public class CuentasPorCobrarPagoEntity
    {
        /// <summary>
        /// Condomino Full Name
        /// </summary>
        [DisplayName("Id")]
        public int CuentasPorCobrarPagoId { get; set; }
        /// <summary>
        /// Numero de Vaucher
        /// </summary>
        [DisplayName("Numero de transaccion")]
        public string VaucherNumber { get; set; }


        /// <summary>
        /// Condomino Full Name
        /// </summary>
        [DisplayName("Condomino")]
        public Nullable<int> ClienteId { get; set; }
        public string MetodoPago { get; set; }
        public string ReferenciaPago { get; set; }
        public string Observacion { get; set; }
        public Nullable<System.DateTime> FechaDeCreacion { get; set; }
        public Nullable<System.DateTime> FechaDeModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }

        public decimal Monto { get; set; }
        public Nullable<int> PropiedadId { get; set; }

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

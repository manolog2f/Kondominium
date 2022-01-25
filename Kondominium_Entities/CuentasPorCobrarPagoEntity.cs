using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kondominium_Entities
{
    public class CuentasPorCobrarPagoEntity
    {
        [DisplayName("Id de Pago")]
        public int CuentasPorCobrarPagoId { get; set; }
        [DisplayName("Voucher")]
        public string VaucherNumber { get; set; }
        [DisplayName("Cliente")]
        public Nullable<int> ClienteId { get; set; }
        [DisplayName("Metodo de pago")]
        public string MetodoPago { get; set; }
        [DisplayName("Referencia de pago")]
        public string ReferenciaPago { get; set; }
        public string Observacion { get; set; }
        public Nullable<System.DateTime> FechaDeCreacion { get; set; }
        public Nullable<System.DateTime> FechaDeModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
        [DisplayName("Monto")]
        public decimal Monto { get; set; }
        [DisplayName("Propiedad")]
        public Nullable<int> PropiedadId { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Fecha de Pago"), Required(ErrorMessage = "Debe ingresar la fecha correspondiente.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> FechadePago { get; set; }
        [DisplayName("Propiedad")]
        public string VPropiedad { get; set; }
        [DisplayName("Nombre")]
        public string ClientFullName { get; set; }
        public Nullable<int> Estado { get; set; }
    }
}

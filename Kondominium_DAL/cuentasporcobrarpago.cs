//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kondominium_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class cuentasporcobrarpago
    {
        public int CuentasPorCobrarPagoId { get; set; }
        public string VaucherNumber { get; set; }
        public Nullable<int> ClienteId { get; set; }
        public string MetodoPago { get; set; }
        public string ReferenciaPago { get; set; }
        public string Observacion { get; set; }
        public Nullable<System.DateTime> FechaDeCreacion { get; set; }
        public Nullable<System.DateTime> FechaDeModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
        public decimal Monto { get; set; }
    }
}

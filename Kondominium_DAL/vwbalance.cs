//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kondominium_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class vwbalance
    {
        public string VaucherNumber { get; set; }
        public Nullable<int> ClienteId { get; set; }
        public string TipoCxC { get; set; }
        public Nullable<System.DateTime> FechaDeEmision { get; set; }
        public Nullable<System.DateTime> FechaDeVencimiento { get; set; }
        public string PeriodoFacturado { get; set; }
        public decimal TotRecibo { get; set; }
        public decimal TotPago { get; set; }
        public string Estado { get; set; }
        public Nullable<int> PropiedadId { get; set; }
    }
}

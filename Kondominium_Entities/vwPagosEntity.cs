using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities
{
  public class vwPagosEntity
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
            public Nullable<int> PropiedadId { get; set; }
            public Nullable<System.DateTime> FechadePago { get; set; }
            public Nullable<int> Estado { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string TelefonoMovil { get; set; }
            public string TelefonoFijo { get; set; }
            public string PropiedadDescripcion { get; set; }
            public Nullable<int> Casa { get; set; }
            public string PoligonoId { get; set; }
            public Nullable<int> ArancelId { get; set; }
            public string Senda { get; set; }
            public string Calle { get; set; }
            public string Avenida { get; set; }
            public string CasaLetra { get; set; }
            public string propiedadF { get; set; }
        
    }
}

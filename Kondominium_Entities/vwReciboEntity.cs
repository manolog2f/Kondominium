using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities
{
   public class vwReciboEntity
    {
       
            public string VaucherNumber { get; set; }
            public int ClienteId { get; set; }
            public string TipoCxC { get; set; }
            public System.DateTime FechaDeEmision { get; set; }
            public System.DateTime FechaDeVencimiento { get; set; }
            public string PeriodoFacturado { get; set; }
            public decimal Total { get; set; }
            public string NPE { get; set; }
            public string BRCode { get; set; }
            public System.DateTime FechaDeCreacion { get; set; }
            public System.DateTime FechaDeModificacion { get; set; }
            public string CreadoPor { get; set; }
            public string ModificadoPor { get; set; }
            public bool Eliminado { get; set; }
            public Nullable<int> Estado { get; set; }
            public Nullable<decimal> Pagado { get; set; }
            public int PropiedadId { get; set; }
            public int DetalleId { get; set; }
            public int ProductoId { get; set; }
            public string ProductoDescripcion { get; set; }
            public decimal Monto { get; set; }
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string TelefonoMovil { get; set; }
            public string TelefonoFijo { get; set; }
            public string Documento1 { get; set; }
            public string Documento2 { get; set; }
            public string Documento3 { get; set; }
            public string Documento4 { get; set; }
            public string PropiedadDescripcion { get; set; }
            public int Casa { get; set; }
            public string PoligonoId { get; set; }
            public Nullable<int> ArancelId { get; set; }
            public string Senda { get; set; }
            public string Calle { get; set; }
            public string Avenida { get; set; }
            public string CasaLetra { get; set; }
            public string Name_exp_40 { get; set; }

    }
}

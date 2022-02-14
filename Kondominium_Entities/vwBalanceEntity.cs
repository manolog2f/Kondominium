using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities
{
  public  class vwBalanceEntity
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


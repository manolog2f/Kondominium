using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities
{
   public class ContratosEntity
    {
        
            public int ContratoId { get; set; }
            public int ClienteId { get; set; }
            public int PropiedadId { get; set; }
            public string TipoCliente { get; set; }
            public Nullable<System.DateTime> FechaInicio { get; set; }
            public Nullable<System.DateTime> FechaFin { get; set; }
            public Nullable<int> DiaMesaFacturar { get; set; }
            public string Categoria { get; set; }
            public string Frecuencia { get; set; }
            public Nullable<decimal> Total { get; set; }
            public Nullable<bool> Activo { get; set; }
            public Nullable<System.DateTime> FechaDeCreacion { get; set; }
            public Nullable<System.DateTime> FechaDeModificacion { get; set; }
            public string CreadoPor { get; set; }
            public string ModificadoPor { get; set; }
        }
}

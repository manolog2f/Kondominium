using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities
{
   public class ClientePropiedadDetalleEntity
    {

            public int ClienteId { get; set; }
            public int PropiedadId { get; set; }
            public string TipoCliente { get; set; }
            public Nullable<System.DateTime> FechaInicio { get; set; }
            public Nullable<System.DateTime> FechaFin { get; set; }
            public Nullable<bool> Autorrenovable { get; set; }
            public Nullable<bool> InquilinoResponsable { get; set; }
            public string Observacion { get; set; }
            public string Parentesco { get; set; }
            public Nullable<System.DateTime> FechaDeCreacion { get; set; }
            public Nullable<System.DateTime> FechaDeModificacion { get; set; }
            public string CreadoPor { get; set; }
            public string ModificadoPor { get; set; }
        }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities
{
    public class ClientePropiedadDocsEntity
    {
        public int ClientePropiedadDocsId { get; set; }
        public int ClienteId { get; set; }
        public int PropiedadId { get; set; }
        public string TipoCliente { get; set; }
        public string DocumentType { get; set; }
        public string UrlDocument { get; set; }
        public byte[] Document { get; set; }
        public Nullable<System.DateTime> FechaDeCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<bool> Eliminado { get; set; }
    }
}

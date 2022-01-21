using System;

namespace Kondominium_Entities
{
    public class ClienteDocsEntity
    {
        public int ClienteDocId { get; set; }
        public int ClienteId { get; set; }
        public string DocumentType { get; set; }
        public string UrlDocument { get; set; }
        public byte[] Document { get; set; }
        public Nullable<System.DateTime> FechaDeCreacion { get; set; }
        public Nullable<System.DateTime> FechaDeModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
    }
}

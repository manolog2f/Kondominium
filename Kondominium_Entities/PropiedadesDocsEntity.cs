using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities
{
   public class PropiedadesDocsEntity
    {
        
            public int PropiedadesDocId { get; set; }
            public int PropiedadId { get; set; }
            public string DocumentType { get; set; }
            public string UrlDocument { get; set; }
            public byte[] Document { get; set; }
            public Nullable<System.DateTime> FechaDeCreacion { get; set; }
            public Nullable<System.DateTime> FechaDeModificacion { get; set; }
            public string CreadoPor { get; set; }
            public string ModificadoPor { get; set; }

        
        
    }
}

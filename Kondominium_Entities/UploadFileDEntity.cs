using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities
{
    public class UploadFileDEntity
    {
        public int UploadFileHId { get; set; }
        public int UploadFileDId { get; set; }
        public string Tipo { get; set; }
        public string Linea { get; set; }
        public string Hora { get; set; }
        public string Fecha { get; set; }
        public string CodigoInterno { get; set; }
        public string Monto { get; set; }
        public string BarraNPE { get; set; }
        public string Banco { get; set; }
        public string FilaTexto { get; set; }
        public string VaucherNumber { get; set; }
        public Nullable<int> Estatus { get; set; }
        public string Mensaje { get; set; }
        public Nullable<System.DateTime> FechaProceso { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities
{
    public class TareasEntity
    {
        public int TareaId { get; set; }
        public Nullable<int> Prioridad { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public Nullable<System.DateTime> FechaDeEjecucion { get; set; }
        public Nullable<int> Estatus { get; set; }
        public string UsuarioAsignado { get; set; }
        public Nullable<System.DateTime> FechaDeModificacion { get; set; }
        public Nullable<System.DateTime> FechaDeCreacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
    }
}

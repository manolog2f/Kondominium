using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [DataType(DataType.Date)]
        [DisplayName("Fecha de Ejecucion"), Required(ErrorMessage = "Debe ingresar la fecha de la tarea.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> FechaDeEjecucion { get; set; }
        public Nullable<int> Estatus { get; set; }
        public string UsuarioAsignado { get; set; }
        public Nullable<System.DateTime> FechaDeModificacion { get; set; }
        public Nullable<System.DateTime> FechaDeCreacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
        public bool Eliminado { get; set; }
    }

    public enum EstatusTarea
    {
        Programada = 1,
        Finalizada = 2,
        Cancelada = 3
        //0 = Activa\n1 = Trabajando\n2 = Finalizada\n
        // 1 Programada, 2 Finalizada, 3 Cancelada
    }

    public enum PrioridadTarea
    {
        Alta = 1,
        Media = 2,
        Normal = 3
        //0 = Activa\n1 = Trabajando\n2 = Finalizada\n
        // 1 Programada, 2 Finalizada, 3 Cancelada
    }
}

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> FechaDeEjecucion { get; set; }
        public Nullable<int> Estatus { get; set; }
        public string UsuarioAsignado { get; set; }
        public Nullable<System.DateTime> FechaDeModificacion { get; set; }
        public Nullable<System.DateTime> FechaDeCreacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
        public bool Eliminado { get; set; }
    }

}

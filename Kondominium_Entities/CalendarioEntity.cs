using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kondominium_Entities
{
    public class CalendarioEntity
    {
        public int CalendarioId { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Fecha"), Required(ErrorMessage = "Debe ingresar la fecha correspondiente.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> Fecha { get; set; }
        [DataType(DataType.Time)]
        [DisplayName("HoraInicio"), Required(ErrorMessage = "Debe ingresar la hora de inicio del evento.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public TimeSpan? HoraInicio { get; set; }
        [DataType(DataType.Time)]
        [DisplayName("HoraFin"), Required(ErrorMessage = "Debe ingresar la hora de fin del evento.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public TimeSpan? HoraFin { get; set; }
        public Nullable<int> LugarId { get; set; }
        public Nullable<int> ClienteId { get; set; }
        public Nullable<int> PropiedadId { get; set; }
        public string TituloEvento { get; set; }
        public string DescripcionEvento { get; set; }
        public Nullable<System.DateTime> FechaDeCreacion { get; set; }
        public Nullable<System.DateTime> FechaDeModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
        public bool Eliminado { get; set; }
        public string ClienteNombre { get; set; }
        public string VPropiedad { get; set; }

        public string VLugar { get; set; }
    }
}

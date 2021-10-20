using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Kondominium_Entities
{
    public class PoligonosEntitys
    {
        /// <summary>
        /// Id de Polígono
        /// </summary>
        [DisplayName("Id de Polígono")]
        public string PoligonoId { get; set; }
        /// <summary>
        /// Descripcion de Poligono
        /// </summary>
        [DisplayName("Descripción de Polígono")]
        public string PoligonoDescripcion { get; set; }
        /// <summary>
        /// Fecha de Creacion
        /// </summary>
        [DisplayName("Fecha de Creación")]
        public Nullable<System.DateTime> FechaDeCreacion { get; set; }
        /// <summary>
        /// Fecha de Modificacion
        /// </summary>
        [DisplayName("Fecha de Modificación")]
        public System.DateTime FechaDeModificacion { get; set; }
        /// <summary>
        /// Creado por
        /// </summary>
        [DisplayName("Creado por")]
        public string CreadoPor { get; set; }
        /// <summary>
        /// Modificado por
        /// </summary>
        [DisplayName("Modificado por")]
        public string ModificadoPor { get; set; }

        public bool Eliminado { get; set; }

    }
}

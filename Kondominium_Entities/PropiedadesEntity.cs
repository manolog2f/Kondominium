using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Kondominium_Entities
{
    public class PropiedadesEntity
    {
        /// <summary>
        /// Id de Propiedad
        /// </summary>
        [DisplayName("Id de Propiedad")]
        public int PropiedadId { get; set; }
        /// <summary>
        /// Tipo de Propiedad
        /// </summary>
        [DisplayName("Tipo de Propiedad")]
        public Nullable<int> TipoDePropiedad { get; set; }
        /// <summary>
        /// Tipo de Propiedad Descripcion
        /// </summary>
        [DisplayName("Tipo de Propiedad Descripcion")]
        public string TipoDePropiedadDesc { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        /// <summary>
        /// Casa
        /// </summary>
        [DisplayName("Casa")]
        public string Casa { get; set; }
        /// <summary>
        /// Id de Polígono
        /// </summary>
        [DisplayName("Id de Polígono")]
        public string PoligonoId { get; set; }

        /// <summary>
        /// Id de Polígono
        /// </summary>
        [DisplayName("Descripcion de Polígono")]
        public string PoligonoDescripcion { get; set; }


        /// <summary>
        /// Id de Arancel
        /// </summary>
        [DisplayName("Id de Arancel")]
        public Nullable<int> ArancelId { get; set; }

        /// <summary>
        /// Id de Arancel
        /// </summary>
        [DisplayName("Descripcion de Arancel")]
        public string ArancelDescripcion { get; set; }


        /// <summary>
        /// Fecha de Creación
        /// </summary>
        [DisplayName("Fecha de Creación")]
        public System.DateTime FechaDeCreacion { get; set; }
        /// <summary>
        /// Fecha de Modificación
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

    public enum TipoPropideadEnum
    {
        Lote = 0,
        Casa = 1,
        Otros = 3

    }
}

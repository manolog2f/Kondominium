using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        /// Tipo de Propiedad
        /// </summary>
        [DisplayName("Tipo de Propiedad Descripcion")]
        public string TipoDePropiedadDesc { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        [DisplayName("Descripción")]
        [StringLength(200, ErrorMessage = "La descripción no debe exceder de 200 caracteres")]
        public string Descripcion { get; set; }
        /// <summary>
        /// Casa
        /// </summary>
        [DisplayName("Casa")]
        public int Casa { get; set; }
        /// <summary>
        /// Id de Polígono
        /// </summary>
        [DisplayName("Id de Polígono")]
        public string PoligonoId { get; set; }

        /// <summary>
        /// Descripcion del  Polígono
        /// </summary>
        [DisplayName("Descripion de Polígono")]
        public string PoligonoDescripcion { get; set; }

        /// <summary>
        /// Id de Arancel
        /// </summary>
        [DisplayName("Id de Arancel")]
        public Nullable<int> ArancelId { get; set; }

        /// <summary>
        /// Descripcion del arancel
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


        /// <summary>
        /// Senda id
        /// </summary>
        [DisplayName("Id de Senda")]
        public string Senda { get; set; }

        /// <summary>
        /// Descripcion de la Senda
        /// </summary>
        [DisplayName("Descripion de Senda")]
        public string SendaDescripcion { get; set; }

        /// <summary>
        /// Calle id
        /// </summary>
        [DisplayName("Id de calle")]
        public string Calle { get; set; }

        /// <summary>
        /// Descripcion de la Calle
        /// </summary>
        [DisplayName("Descripion de Calle")]
        public string CalleDescripcion { get; set; }

        /// <summary>
        /// Avenida id
        /// </summary>
        [DisplayName("Id de Avenida")]
        public string Avenida { get; set; }

        /// <summary>
        /// Descripcion de la Avenida
        /// </summary>
        [DisplayName("Descripion de Avenida")]
        public string AvenidaDescripcion { get; set; }


        /// <summary>
        /// Letra de la casa ** Opcional
        /// </summary>
        [DisplayName("Letra de la casa")]
        public string CasaLetra { get; set; }

        private string vpropiedadCasa;
        public string VPropiedad   // property
        {
            get { return PoligonoId + '-' + Casa.ToString() + CasaLetra; }
            set { vpropiedadCasa = PoligonoId + '-' + Casa.ToString() + CasaLetra; }
        }
    }

}

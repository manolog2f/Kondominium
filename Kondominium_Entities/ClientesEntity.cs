using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace Kondominium_Entities
{
    public  class ClientesEntity
    {
        /// <summary>
        /// Id clientes
        /// </summary>
        [DisplayName("Clientes Id")]
        public int ClienteId { get; set; }
        /// <summary>
        /// Nombres
        /// </summary>
        [DisplayName("Nombres")]
        public string Nombres { get; set; }
        /// <summary>
        /// Apellidos
        /// </summary>
        [DisplayName("Apellidos")]
        public string Apellidos { get; set; }
        /// <summary>
        /// Dui
        /// </summary>
        [DisplayName("DUI")]
        public string Documento1 { get; set; }
        /// <summary>
        /// NIT
        /// </summary>
        [DisplayName("NIT")]
        public string Documento2 { get; set; }
        /// <summary>
        /// RNC
        /// </summary>
        [DisplayName("RNC")]
        public string Documento3 { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [DisplayName("Email")]
        public string Email { get; set; }
        /// <summary>
        /// Tipo de Cliente
        /// </summary>
        [DisplayName("Tipo de Cliente")]
        public string TipoCliente { get; set; }
        /// <summary>
        /// Telefono Movil
        /// </summary>
        [DisplayName("Teléfono Móvil")]
        public string TelefonoMovil { get; set; }
        /// <summary>
        /// Telefono Fijo
        /// </summary>
        [DisplayName("Teléfono Fijo")]
        public string TelefonoFijo { get; set; }
        /// <summary>
        /// Fecha de Creacion
        /// </summary>
        [DisplayName("Fecha de Creación")]
        public System.DateTime FechaDeCreacion { get; set; }
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

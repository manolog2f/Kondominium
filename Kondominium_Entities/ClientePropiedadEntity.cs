using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities
{
   public class ClientePropiedadEntity
    {
        /// <summary>
        /// Id de cliente
        /// </summary>
        [DisplayName("Condómino Id")]
        public int ClienteId { get; set; }
        /// <summary>
        /// Id de Propiedad
        /// </summary>
        [DisplayName("Propiedad Id")]
        public int PropiedadId { get; set; }
        /// <summary>
        /// Tipo de CLiente
        /// </summary>
        [DisplayName("Tipo de Condómino")]
        public string TipoCliente { get; set; }
        /// <summary>
        /// Tipo de CLiente Enum
        /// </summary>
        public TipoClientes TclienteEnum { get; set; }
        /// <summary>
        /// Justificacion
        /// </summary>
        [DisplayName("Justificación")]
        public string Justificacion { get; set; }
        /// <summary>
        /// Fecha de Creacion
        /// </summary>
        public Nullable<System.DateTime> FechaDeCreacion { get; set; }
        /// <summary>
        /// Fecha de Modificacion
        /// </summary>
        public Nullable<System.DateTime> FechaDeModificacion { get; set; }
        /// <summary>
        /// Creado por
        /// </summary>
        public string CreadoPor { get; set; }
        /// <summary>
        /// Modifica
        /// </summary>
        public string ModificadoPor { get; set; }
        /// <summary>
        /// Cliente  
        /// </summary>
        public ClientesEntity Cliente { get; set; }
        /// <summary>
        /// Propieadd Entity
        /// </summary>
        public PropiedadesEntity Propiedad { get; set; }

        }
}

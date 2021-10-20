using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Kondominium_Entities
{
    public class ProductosEntity
    {
        /// <summary>
        /// Id de Producto
        /// </summary>
        [DisplayName("Id de Producto")]
        public int Productoid { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        /// <summary>
        /// Fecha de creación
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

    }
}

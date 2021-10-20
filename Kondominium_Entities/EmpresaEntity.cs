using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Kondominium_Entities
{
    public class EmpresaEntity
    {
        /// <summary>
        /// Id de Empresa
        /// </summary>
        [DisplayName("Id de Empresa")]
        public int EmpresaId { get; set; }
        /// <summary>
        /// Nombre de Empresa
        /// </summary>
        [DisplayName("Nombre de Empresa")]
        public string EmpresaNombre { get; set; }
        /// <summary>
        /// DUI
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
        /// Direccion
        /// </summary>
        [DisplayName("Dirección")]
        public string Direccion { get; set; }
        /// <summary>
        /// Logo
        /// </summary>
        [DisplayName("Logo")]
        public byte[] Logo { get; set; }
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
}

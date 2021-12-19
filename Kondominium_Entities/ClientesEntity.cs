using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kondominium_Entities
{
    public class ClientesEntity
    {
        /// <summary>
        /// Id clientes
        /// </summary>
        [DisplayName("Condómino Id")]
        public int ClienteId { get; set; }
        /// <summary>
        /// Nombres
        /// </summary>
        [DisplayName("Nombres")]
        [StringLength(45, ErrorMessage = "El nombre no puede ser mayor de 45 caracteres.")]
        [Required]
        public string Nombres { get; set; }
        /// <summary>
        /// Apellidos
        /// </summary>
        [DisplayName("Apellidos")]
        [StringLength(45, ErrorMessage = "El apellido no puede ser mayor de 45 caracteres.")]
        [Required]
        public string Apellidos { get; set; }
        /// <summary>
        /// Dui
        /// </summary>
        [DisplayName("DUI")]
        [StringLength(25, ErrorMessage = "El documento no puede exceder los 25 caracteres")]
        [RegularExpression(@"^\d{8}-?\d{1}$", ErrorMessage = "Por favor ingrese un DUI  correcto")]
        public string Documento1 { get; set; }
        /// <summary>
        /// NIT
        /// </summary>
        [DisplayName("NIT")]
        [StringLength(25, ErrorMessage = "El documento no puede exceder los 25 caracteres")]
        [RegularExpression(@"^\d{4}-?\d{6}-?\d{3}-?\d$", ErrorMessage = "Por favor ingrese un NIT  correcto")]
        public string Documento2 { get; set; }
        /// <summary>
        /// RNC
        /// </summary>
        [StringLength(25, ErrorMessage = "El documento no puede exceder los 25 caracteres")]
        [DisplayName("RNC")]
        public string Documento3 { get; set; }

        /// <summary>
        /// Pasaporte
        /// </summary>
        [StringLength(25, ErrorMessage = "El documento no puede exceder los 25 caracteres")]
        [DisplayName("Pasaporte")]
        public string Documento4 { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [DisplayName("Email")]
        [StringLength(150, ErrorMessage = "El Email no puede exceder los 150 caracteres")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Por favor ingrese un correo electronico correcto")]
        public string Email { get; set; }
        /// <summary>
        /// Tipo de Cliente
        /// </summary>
        [DisplayName("Tipo de Condómino")]
        public string TipoCliente { get; set; }
        /// <summary>
        /// Telefono Movil
        /// </summary>
        [DisplayName("Teléfono Móvil")]
        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{4}[\s.-]?\d{4}$", ErrorMessage = "Por favor ingrese un telefono en el formato (000) 0000-0000")]
        public string TelefonoMovil { get; set; }
        /// <summary>
        /// Telefono Fijo
        /// </summary>
        [DisplayName("Teléfono Fijo")]
        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{4}[\s.-]?\d{4}$", ErrorMessage = "Por favor ingrese un telefono en el formato (000) 0000-0000")]
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

        private string vfullName;
        public string VFullName   // property
        {
            get { return Nombres + ' ' + Apellidos; }
            set { vfullName = Nombres + ' ' + Apellidos; }
        }
    }

    public enum TipoClientes
    {
        Propietario = 0,
        Inquilino = 1,
        Otro = 2
    }

    public enum TipoDocumento
    {
        DUI = 0,
        NIT = 1,
        Pasaporte = 2,
        Contrato = 3,
        Recibo = 4,
        Otro = 5
    }

    public enum Parentescos
    {
        Padre = 1,
        Madre = 2,
        Hijo = 3,
        Hija = 4,
        Suegra = 5,
        Suegro = 6,
        Yerno = 7,
        Nuera = 8,
        Abuelo = 9,
        Abuela = 10,
        Nieto = 11,
        Nieta = 12,
        Hermano = 13,
        Hermana = 14,
        Cuñado = 15,
        Cuñada = 16,
        Tio = 17,
        Tia = 18,
        Sobrino = 19,
        Sobrina = 20,
        Esposo = 21,
        Esposa = 22,
        Amigo = 23,
        Otro = 24


    }

}

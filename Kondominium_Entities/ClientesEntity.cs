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
        public string TelefonoMovil { get; set; }

        /// <summary>
        /// Telefono Fijo
        ///  //[RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{4}[\s.-]?\d{4}$", ErrorMessage = "Por favor ingrese un telefono en el formato (000) 0000-0000")]
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

        private string vfullName;

        public string VFullName   // property
        {
            get { return Nombres + ' ' + Apellidos; }
            set { vfullName = Nombres + ' ' + Apellidos; }
        }

        /// <summary>
        /// Pais para la mascara del Numero de Telefono
        /// </summary>
        [DisplayName("Pais Telefono")]
        public string Pais { get; set; }
    }
}
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
        [DisplayName("Clientes Id")]
        public int ClienteId { get; set; }

        [DisplayName("Nombres")]
        public string Nombres { get; set; }

        [DisplayName("Apellidos")]
        public string Apellidos { get; set; }

        [DisplayName("Dui")]
        public string Documento1 { get; set; }

        [DisplayName("NIT")]
        public string Documento2 { get; set; }

        [DisplayName("RNC")]
        public string Documento3 { get; set; }
        public string Email { get; set; }
        public string TipoCliente { get; set; }
        public string TelefonoMovil { get; set; }
        public string TelefonoFijo { get; set; }
        public System.DateTime FechaDeCreacion { get; set; }
        public System.DateTime FechaDeModificacion { get; set; }
        public string CreadoPor { get; set; }
        public string ModificadoPor { get; set; }
    }
}

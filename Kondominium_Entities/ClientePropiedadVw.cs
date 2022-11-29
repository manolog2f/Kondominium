using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities
{
    public class ClientePropiedadVw
    {
        [DisplayName("Condómino Id")]
        public int ClienteId { get; set; }
        [DisplayName("Propiedad Id")]
        public int PropiedadId { get; set; }

        [DisplayName("Tipo de Cliente")]
        public string TipoCliente { get; set; }


        public string TipoClienteDesc
        {
            get
            {
                var tc = (TipoClientes)Enum.ToObject(typeof(TipoClientes), (int.Parse(TipoCliente))) ;

                tc.ToString();

                return tc.ToString();
            }

            set {

                var tc = (TipoClientes)Enum.ToObject(typeof(TipoClientes), (int.Parse(TipoCliente)));

              

                TipoClienteDesc = tc.ToString(); }
        }

        [DisplayName("Nombres")]
        public string Nombres { get; set; }
        [DisplayName("Apellidos")]
        public string Apellidos { get; set; }
        [DisplayName("Nombre Completo")]
        public string FullName         
        {
            get { return Nombres + ' ' + Apellidos; }
            set { FullName = Nombres + ' ' + Apellidos; }
        }
        [DisplayName("Propiedad")]
        public string VPropiedad
        {
            get { return PoligonoId + '-' + Casa + CasaLetra; }
            set { VPropiedad = PoligonoId + '-' + Casa + CasaLetra; }
        }

        [DisplayName("Poligono Id")]
        public string PoligonoId { get; set; }
        [DisplayName("Casa")]
        public string Casa { get; set;  }
        [DisplayName("Casa Letra")]
        public string CasaLetra { get; set; }
    }
}

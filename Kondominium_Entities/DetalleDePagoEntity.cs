using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities
{
    public class DetalleDePagoEntity
    {
        public int CuentasPorCobrarPagoId { get; set; }
        public string VaucherNumber { get; set; }
        [DisplayName("Nombre Completo")]
        public string Residente { get; set; }

        public int Casa { get; set; }
        public string CasaLetra { get; set; }
        public int PropiedadId { get; set; }

        public string PoligonoId { get; set; }
        public string PeriodoFacturado { get; set; }
        public decimal TarjetaCredito { get; set; }
        public decimal Transferencia { get; set; }
        public decimal Cheque { get; set; }
        public decimal Efectivo { get; set; }
        public decimal NPE { get; set; }
        public decimal BAR { get; set; }
        public decimal OTRO { get; set; }
        public string ReferenciaPago { get; set; }
        public decimal Monto { get; set; }
        public int Estado { get; set; }
        public decimal MttoGeneral { get; set; }
        public decimal MttoAguaRiego { get; set; }
        public decimal Otros { get; set; }
    }
}
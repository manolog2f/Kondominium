using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities
{
    public class vwBalanceEntity
    {
        public string VaucherNumber { get; set; }
        public Nullable<int> ClienteId { get; set; }
        public string TipoCxC { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public Nullable<System.DateTime> FechaDeEmision { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public Nullable<System.DateTime> FechaDeVencimiento { get; set; }

        public string PeriodoFacturado { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal TotRecibo { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal TotPago { get; set; }

        public string Estado { get; set; }
        public Nullable<int> PropiedadId { get; set; }

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
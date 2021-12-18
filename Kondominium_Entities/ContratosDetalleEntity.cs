using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities
{
   public class ContratosDetalleEntity
    {      
            public int ContratoId { get; set; }
            public int ProductoId { get; set; }
            public Nullable<decimal> Monto { get; set; }
   }
}

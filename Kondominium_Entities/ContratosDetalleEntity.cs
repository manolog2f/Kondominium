using System;

namespace Kondominium_Entities
{
    public class ContratosDetalleEntity
    {
        public int ContratoId { get; set; }
        public int ProductoId { get; set; }
        public Nullable<decimal> Monto { get; set; }
    }
}

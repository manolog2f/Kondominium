using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_BL
{
   public class BalanceDatos
    {
        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public List<vwBalanceEntity> ByCliente(int clienteId)
        {
            var query = context.vwbalance.Where(x => x.ClienteId == clienteId).Select( x => new vwBalanceEntity 
            {
                VaucherNumber = x.VaucherNumber,
                ClienteId = x.ClienteId,
                TipoCxC = x.TipoCxC,
                FechaDeEmision = x.FechaDeEmision,
                FechaDeVencimiento = x.FechaDeVencimiento,
                PeriodoFacturado = x.PeriodoFacturado,
                TotRecibo = x.TotRecibo,
                TotPago = x.TotPago,
                Estado = x.Estado,
                PropiedadId = x.PropiedadId

            }).ToList();

            return query;
        }
        public List<vwBalanceEntity> ByPropiedad(int propiedadId)
        {
            var query = context.vwbalance.Where(x => x.PropiedadId == propiedadId).Select(x => new vwBalanceEntity
            {
                VaucherNumber = x.VaucherNumber,
                ClienteId = x.ClienteId,
                TipoCxC = x.TipoCxC,
                FechaDeEmision = x.FechaDeEmision,
                FechaDeVencimiento = x.FechaDeVencimiento,
                PeriodoFacturado = x.PeriodoFacturado,
                TotRecibo = x.TotRecibo,
                TotPago = x.TotPago,
                Estado = x.Estado,
                PropiedadId = x.PropiedadId

            }).ToList();

            return query;
        }
    }
}

using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_BL
{
    public class ReportData
    {
        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public List<vwReciboEntity> Recibo(string VaucherNumber)
        {
            var recibos = context.vwrecibo.Where(x => x.VaucherNumber == VaucherNumber).Select(x => new vwReciboEntity
            {
                VaucherNumber = x.VaucherNumber,
                ClienteId = x.ClienteId,
                TipoCxC = x.TipoCxC,
                FechaDeEmision = x.FechaDeEmision,
                FechaDeVencimiento = x.FechaDeVencimiento,
                PeriodoFacturado = x.PeriodoFacturado,
                Total = x.Total,
                NPE = x.NPE,
                BRCode = x.BRCode,
                FechaDeCreacion = x.FechaDeCreacion,
                FechaDeModificacion = x.FechaDeModificacion,
                CreadoPor = x.CreadoPor,
                ModificadoPor = x.ModificadoPor,
                Eliminado = x.Eliminado,
                Estado = x.Estado,
                Pagado = x.Pagado,
                PropiedadId = x.PropiedadId,
                DetalleId = x.DetalleId,
                ProductoId = x.ProductoId,
                ProductoDescripcion = x.ProductoDescripcion,
                Monto = x.Monto,
                Nombres = x.Nombres,
                Apellidos = x.Apellidos,
                FullName = x.FullName,
                Email = x.Email,
                TelefonoMovil = x.TelefonoMovil,
                TelefonoFijo = x.TelefonoFijo,
                Documento1 = x.Documento1,
                Documento2 = x.Documento2,
                Documento3 = x.Documento3,
                Documento4 = x.Documento4,
                PropiedadDescripcion = x.PropiedadDescripcion,
                Casa = x.Casa,
                PoligonoId = x.PoligonoId,
                ArancelId = x.ArancelId,
                Senda = x.Senda,
                Calle = x.Calle,
                Avenida = x.Avenida,
                CasaLetra = x.CasaLetra,
                Name_exp_40 = x.Name_exp_40,

            }).ToList();

            return recibos;

        }

        public List<vwPagosEntity> Pagos(string VaucherNumber)
        {
            var pagos = context.vwpagos.Where(x => x.VaucherNumber == VaucherNumber).Select(x => new vwPagosEntity {

                CuentasPorCobrarPagoId = x.CuentasPorCobrarPagoId   ,
                VaucherNumber = x.VaucherNumber                     ,
                ClienteId = x.ClienteId                             ,
                MetodoPago = x.MetodoPago                           ,
                ReferenciaPago = x.ReferenciaPago                   ,
                Observacion = x.Observacion                         ,
                FechaDeCreacion = x.FechaDeCreacion                 ,
                FechaDeModificacion = x.FechaDeModificacion         ,
                CreadoPor = x.CreadoPor                             ,
                ModificadoPor = x.ModificadoPor                     ,
                Monto = x.Monto                                     ,
                PropiedadId = x.PropiedadId                         ,
                FechadePago = x.FechadePago                         ,
                Estado = x.Estado                                   ,
                FullName = x.FullName                               ,
                Email = x.Email                                     ,
                TelefonoMovil = x.TelefonoMovil                     ,
                TelefonoFijo = x.TelefonoFijo                       ,
                PropiedadDescripcion = x.PropiedadDescripcion       ,
                Casa = x.Casa                                       ,
                PoligonoId = x.PoligonoId                           ,
                ArancelId = x.ArancelId                             ,
                Senda = x.Senda                                     ,
                Calle = x.Calle                                     ,
                Avenida = x.Avenida                                 ,
                CasaLetra = x.CasaLetra                             ,
                propiedadF = x.propiedadF
            }).ToList();


            return pagos;        
        }

        public DataTable ReciboDataTable(string VaucherNumber)
        {

            var dTabla = new DataTable();

            using (var _context = new Kondominium_DAL.KEntities())
            {
                dTabla = ZoomTechUtils.ZMTDriveDataTable.ToDataTable(_context.vwrecibo.Where(x => x.VaucherNumber == VaucherNumber).ToList());
            }

            return dTabla;
        }
    }
}

using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_BL
{
    public class BalanceDatos
    {
        private Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();

        public List<vwBalanceEntity> ByCliente(int clienteId)
        {
            var query = from x in context.vwbalance
                        join p in context.propiedades on x.PropiedadId equals p.PropiedadId
                        join c in context.clientes on x.ClienteId equals c.ClienteId
                        where x.ClienteId == clienteId
                        select new vwBalanceEntity
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
                            PropiedadId = x.PropiedadId,

                            Cliente = (new ClientesEntity
                            {
                                Apellidos = c.Apellidos,
                                ClienteId = c.ClienteId,
                                Nombres = c.Nombres,
                                Documento1 = c.Documento1,
                                Documento2 = c.Documento2,
                                Documento3 = c.Documento3,
                                Email = c.Email,
                                TelefonoFijo = c.TelefonoFijo,
                                TelefonoMovil = c.TelefonoMovil,
                                Eliminado = c.Eliminado,
                            }
                           ),
                            Propiedad = (new PropiedadesEntity
                            {
                                PropiedadId = p.PropiedadId,
                                TipoDePropiedad = p.TipoDePropiedad,
                                Descripcion = p.Descripcion,
                                Casa = p.Casa,
                                PoligonoId = p.PoligonoId,
                                ArancelId = p.ArancelId,
                                Eliminado = p.Eliminado,

                                TipoDePropiedadDesc = ((TipodePropiedades)p.TipoDePropiedad).ToString(),

                                ArancelDescripcion = p.aranceles.Descripcion,
                                PoligonoDescripcion = p.poligonos.PoligonoDescripcion,
                                AvenidaDescripcion = p.avenida1.AvenidaDescripcion,
                                CalleDescripcion = p.calles.CalleDescripcion,
                                SendaDescripcion = p.sendas.SendaDescripcion,
                                Calle = p.Calle,
                                Avenida = p.Avenida,
                                Senda = p.Senda,
                                Alameda = p.Alameda,
                                AlamedaDescripcion = p.alameda1.AlamedaDescripcion,
                                CasaLetra = p.CasaLetra,
                                PaseoDescripcion = p.paseo.PaseoDescripcion,
                                PaseoId = p.PaseoId,
                            })
                        };

            return query.ToList();
        }

        public List<vwBalanceEntity> ByPropiedad(int propiedadId)
        {
            var query = from x in context.vwbalance
                        join p in context.propiedades on x.PropiedadId equals p.PropiedadId
                        join c in context.clientes on x.ClienteId equals c.ClienteId
                        where x.PropiedadId == propiedadId
                        select new vwBalanceEntity
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
                            PropiedadId = x.PropiedadId,

                            Cliente = (new ClientesEntity
                            {
                                Apellidos = c.Apellidos,
                                ClienteId = c.ClienteId,
                                Nombres = c.Nombres,
                                Documento1 = c.Documento1,
                                Documento2 = c.Documento2,
                                Documento3 = c.Documento3,
                                Email = c.Email,
                                TelefonoFijo = c.TelefonoFijo,
                                TelefonoMovil = c.TelefonoMovil,
                                Eliminado = c.Eliminado,
                            }
                           ),
                            Propiedad = (new PropiedadesEntity
                            {
                                PropiedadId = p.PropiedadId,
                                TipoDePropiedad = p.TipoDePropiedad,
                                Descripcion = p.Descripcion,
                                Casa = p.Casa,
                                PoligonoId = p.PoligonoId,
                                ArancelId = p.ArancelId,
                                Eliminado = p.Eliminado,

                                TipoDePropiedadDesc = ((TipodePropiedades)p.TipoDePropiedad).ToString(),

                                ArancelDescripcion = p.aranceles.Descripcion,
                                PoligonoDescripcion = p.poligonos.PoligonoDescripcion,
                                AvenidaDescripcion = p.avenida1.AvenidaDescripcion,
                                CalleDescripcion = p.calles.CalleDescripcion,
                                SendaDescripcion = p.sendas.SendaDescripcion,
                                Calle = p.Calle,
                                Avenida = p.Avenida,
                                Senda = p.Senda,
                                Alameda = p.Alameda,
                                AlamedaDescripcion = p.alameda1.AlamedaDescripcion,
                                CasaLetra = p.CasaLetra,
                                PaseoDescripcion = p.paseo.PaseoDescripcion,
                                PaseoId = p.PaseoId,
                            })
                        };

            return query.ToList();
        }

        public List<DashClientesMorosos> ClientesMorosos(int Top)
        {
            var query = context.vwbalance.GroupBy(x => x.ClienteId).Select(x => new DashClientesMorosos
            {
                ClienteId = (int)x.FirstOrDefault().ClienteId,
                PropiedadId = (int)x.FirstOrDefault().PropiedadId,
                SaldoActual = x.Sum(s => s.TotRecibo) - x.Sum(s => s.TotPago)
            }).ToList();

            query = query.Where(x => x.SaldoActual > 0).OrderByDescending(x => x.SaldoActual).Take(Top).ToList();

            var q2 = from a in query
                     join c in context.clientes on a.ClienteId equals c.ClienteId
                     select new DashClientesMorosos
                     {
                         ClienteId = a.ClienteId,
                         FullName = c.Nombres + c.Apellidos,
                         PropiedadId = a.PropiedadId,
                         SaldoActual = a.SaldoActual
                     };

            return q2.ToList();
        }

        public List<DashClientesMorosos> ClientesMorosos()
        {
            var query = context.vwbalance.GroupBy(x => x.ClienteId).Select(x => new DashClientesMorosos
            {
                ClienteId = (int)x.FirstOrDefault().ClienteId,
                PropiedadId = (int)x.FirstOrDefault().PropiedadId,
                SaldoActual = x.Sum(s => s.TotRecibo) - x.Sum(s => s.TotPago)
            }).ToList();

            query = query.Where(x => x.SaldoActual > 0).OrderByDescending(x => x.SaldoActual).ToList();

            var q2 = from a in query
                     join c in context.clientes on a.ClienteId equals c.ClienteId
                     select new DashClientesMorosos
                     {
                         ClienteId = a.ClienteId,
                         FullName = c.Nombres + c.Apellidos,
                         PropiedadId = a.PropiedadId,
                         SaldoActual = a.SaldoActual
                     };

            return q2.ToList();
        }

        public List<DashClientesMorosos> PropiedadesMorosos(int Top)
        {
            var query = context.vwbalance.GroupBy(x => x.PropiedadId).Select(x => new DashClientesMorosos
            {
                ClienteId = (int)x.FirstOrDefault().ClienteId,
                PropiedadId = (int)x.FirstOrDefault().PropiedadId,
                SaldoActual = x.Sum(s => s.TotRecibo) - x.Sum(s => s.TotPago)
            }).ToList();

            query = query.Where(x => x.SaldoActual > 0).OrderByDescending(x => x.SaldoActual).Take(Top).ToList();

            var q2 = from a in query
                     join c in context.propiedades on a.PropiedadId equals c.PropiedadId
                     select new DashClientesMorosos
                     {
                         ClienteId = a.ClienteId,
                         VPropiedad = c.PoligonoId + '-' + c.Casa.ToString() + c.CasaLetra,
                         PropiedadId = a.PropiedadId,
                         SaldoActual = a.SaldoActual
                     };

            return q2.ToList();
        }

        public List<PagosPorMetodoEntity> PagosPorFecha(DateTime Desde, DateTime Hasta)
        {
            Hasta = Hasta.AddDays(1);

            var query = context.vwpagos2.Where(x => x.FechadePago >= Desde && x.FechadePago <= Hasta).GroupBy(x => new { x.MetodoPago, x.FechadePago }).Select(x => new PagosPorMetodoEntity
            {
                MetodoDePago = x.Key.MetodoPago,
                Fecha = x.Key.FechadePago,
                Monto = x.Sum(s => s.Monto)
            }).ToList();

            return query;
        }
    }
}
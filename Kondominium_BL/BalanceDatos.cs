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
            var query = from x in context.vwbalance
                        join p in context.propiedades on x.PropiedadId equals p.PropiedadId
                        join c in context.clientes on x.ClienteId equals c.ClienteId                
                        where  x.ClienteId == clienteId
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
    }
}

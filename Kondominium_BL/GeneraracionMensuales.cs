using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kondominium_Entities;
namespace Kondominium_BL
{
    public class GeneraracionMensuales
    {
        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public (Kondominium_Entities.Resultado, CuentasGeneradasEntity) GenerarRecibosMensuales(int mes, int año, DateTime FechaGeneracion, DateTime FechaVencimiento, string PeriodoFacturado, string usuario)
        {
            //var FechaGeneracion = new DateTime();
            //var FechaVencimiento = new DateTime();
            int mesVencimiento = mes;
            var configHeader = context.configcobrosmensual.FirstOrDefault();
            var configDet = context.configcobrosmensauldet.ToList();

            //FechaGeneracion = DateTime.Parse(string.Concat(año.ToString(), "-", mes.ToString(), "-", configHeader.DiaDeGeneracion.ToString()));

            //if (configHeader.DiaVencimiento >= configHeader.DiaDeGeneracion)
            //{
            //    mesVencimiento = mes;
            //}
            //else
            //{
            //    if (mes == 12)
            //        mesVencimiento = 1;
            //    else
            //        mesVencimiento = mes + 1;
            //}

            //if (mes == 2 && configHeader.DiaVencimiento >= 29)
            //{
            //    configHeader.DiaVencimiento = 28;
            //}
            //FechaVencimiento = DateTime.Parse(string.Concat(año.ToString(), "-", mesVencimiento.ToString(), "-", configHeader.DiaDeGeneracion.ToString()));


            /*Almacenar Generacion*/
            var g = CuentasGeneradasH(FechaGeneracion, FechaVencimiento, usuario, PeriodoFacturado);


            /*Obtener Listado de Propiedades*/
            var listPropiedades = context.propiedades.ToList();


            foreach (var item in listPropiedades)
            {

                var header = new Kondominium_Entities.CuentasPorCobrarEntity();
                //var detalle = new Kondominium_Entities.CuentasPorCobrarDetalleEntity();

                /* Buscar el propietario Responsable de la propiedad 
                 *  Si hubiera mas de un propietario responsable se tomara el de mayor rango,
                 *  Si hubieran tres en el mismo rango se colocara el primero.
                 */
                var listClientes = context.clientepropiedad.Where(x => x.PropiedadId == item.PropiedadId).ToList();

                if (listClientes.Count <= 0)
                {
                    /* No existe cliente asignado se inserta error en el LOG de Generaciones  */
                    AlmacenarLogGeneracion(año, mes, " ERROR: No existe cliente asignado para la propiedad  " + item.PropiedadId, item.PropiedadId, 0);
                }
                else if (listClientes.Count == 1)
                {
                    var r = CrearRecibo(item.PropiedadId, listClientes.FirstOrDefault().ClienteId, configHeader, configDet, item, FechaGeneracion, FechaVencimiento, PeriodoFacturado);
                    AlmacenarLogGeneracion(año, mes, " Info: Archivo Generado de forma exitosa - VaucherNO: " + r, item.PropiedadId, listClientes.FirstOrDefault().ClienteId);
                }
                else if (listClientes.Count > 1)
                {
                    if (listClientes.Where(x => x.TipoCliente == "0").Count() > 0)
                    {
                        var r = CrearRecibo(item.PropiedadId, listClientes.Where(x => x.TipoCliente == "0").FirstOrDefault().ClienteId, configHeader, configDet, item, FechaGeneracion, FechaVencimiento, PeriodoFacturado);

                        if (r != "")
                        {
                            AlmacenarLogGeneracion(año, mes, " Info: Archivo Generado de forma exitosa - VaucherNO: " + r, item.PropiedadId, listClientes.Where(x => x.TipoCliente == "0").FirstOrDefault().ClienteId);
                        }
                    }
                    else if (listClientes.Where(x => x.TipoCliente == "1").Count() > 0)
                    {
                        var r = CrearRecibo(item.PropiedadId, listClientes.Where(x => x.TipoCliente == "1").FirstOrDefault().ClienteId, configHeader, configDet, item, FechaGeneracion, FechaVencimiento, PeriodoFacturado);
                        if (r != "")
                        {
                            AlmacenarLogGeneracion(año, mes, " Info: Archivo Generado de forma exitosa - VaucherNO: " + r, item.PropiedadId, listClientes.Where(x => x.TipoCliente == "1").FirstOrDefault().ClienteId);
                        }
                    }
                    else if (listClientes.Where(x => x.TipoCliente == "2").Count() > 0)
                    {
                        var r = CrearRecibo(item.PropiedadId, listClientes.Where(x => x.TipoCliente == "2").FirstOrDefault().ClienteId, configHeader, configDet, item, FechaGeneracion, FechaVencimiento, PeriodoFacturado);
                        if (r != "")
                        {
                            AlmacenarLogGeneracion(año, mes, " Info: Archivo Generado de forma exitosa - VaucherNO: " + r, item.PropiedadId, listClientes.Where(x => x.TipoCliente == "2").FirstOrDefault().ClienteId);
                        }
                    }
                }

            }


            return (new Resultado { Codigo = 0, Mensaje = "Proceso Generado con exito" }, g);
        }

        private void AlmacenarLogGeneracion(int año, int mes, string observacion, int propiedadID, int clienteID)
        {

            var log = new Kondominium_DAL.cobrosmensalesloggeneracion();
            log.Año = año;
            log.Mes = mes;
            log.Observacion = observacion;
            log.PropiedadId = propiedadID;
            log.Fecha = DateTime.Now;
            log.ClienteId = clienteID;


            context.cobrosmensalesloggeneracion.Add(log);
            context.SaveChanges();
        }

        private string CrearRecibo(int propiedadID, int clienteID, Kondominium_DAL.configcobrosmensual cHeder, List<Kondominium_DAL.configcobrosmensauldet> cDet, Kondominium_DAL.propiedades pro, DateTime FechaGeneracion, DateTime FechaVencimiento, string PeriodoFacturado)
        {
            /*Inserta Encabezado*/


            var arancel = context.aranceles.Where(x => x.ArancelId == pro.ArancelId).FirstOrDefault();
            decimal TotalHeader = 0;

            TotalHeader = (decimal)arancel.Monto + (decimal)cDet.Sum(x => x.Monto).Value;

            var header = new CuentasPorCobrarDatos().SaveA(new CuentasPorCobrarEntity
            {
                CreadoPor = "KomdominoSystem",
                ModificadoPor = "KomdominoSystem",
                FechaDeCreacion = DateTime.Now,
                FechaDeModificacion = DateTime.Now,
                ClienteId = clienteID,
                Eliminado = false,
                FechaDeEmision = FechaGeneracion,
                FechaDeVencimiento = FechaVencimiento,
                PropiedadId = propiedadID,
                TipoCxC = "Recibos",
                Total = TotalHeader,
                PeriodoFacturado = PeriodoFacturado, //FechaGeneracion.ToString("MMMM") + ' ' + FechaGeneracion.Year.ToString()
            }, arancel.Descripcion, pro.Casa.ToString(), pro.CasaLetra, pro.PoligonoId);

            if (header.Item2.Codigo != 0)
            {
                AlmacenarLogGeneracion(FechaGeneracion.Month, FechaGeneracion.Year, header.Item2.Mensaje , propiedadID, clienteID);
                return "";

            }

            var detalle = new CuentasPorCobrarDetalleDatos().Save(new CuentasPorCobrarDetalleEntity
            {
                CreadoPor = "KomdominoSystem",
                ModificadoPor = "KomdominoSystem",
                FechaDeCreacion = DateTime.Now,
                FechaDeModificacion = DateTime.Now,
                Descripcion = "Arancel",
                Eliminado = false,
                Monto = arancel.Monto,
                ProductoId = 1,
                VaucherNumber = header.Item1.VaucherNumber
            });

            foreach (var item in cDet)
            {
                var detallei = new CuentasPorCobrarDetalleDatos().Save(new CuentasPorCobrarDetalleEntity
                {
                    CreadoPor = "KomdominoSystem",
                    ModificadoPor = "KomdominoSystem",
                    FechaDeCreacion = DateTime.Now,
                    FechaDeModificacion = DateTime.Now,
                    Descripcion = new ProductosDatos().GetById(item.ProductoId).Descripcion,
                    Eliminado = false,
                    Monto = (decimal)item.Monto,
                    ProductoId = item.ProductoId,
                    VaucherNumber = header.Item1.VaucherNumber
                });

            }

            return header.Item1.VaucherNumber;


        }

        private CuentasGeneradasEntity CuentasGeneradasH(DateTime fGeneracion, DateTime fVencimiento, string usuario, string PeriodoFacturado)
        {
            var g = new CuentasGeneradasDatos().Save(new CuentasGeneradasEntity
            {
                CreadoPor = usuario,
                ModificadoPo = usuario,
                FechaDeCreacion = DateTime.Now,
                FechaDeModificacion = DateTime.Now,
                FechaDeVencimiento = fVencimiento,
                FechaDeGeneracion = fGeneracion,
                Justificacion = "Generacion Automatica de Recibos",
                PeriodoGenerado = PeriodoFacturado //fGeneracion.ToString("MMMM") + ' ' + fGeneracion.Year.ToString()
            });

            return g.Item1;
        }
    }
}

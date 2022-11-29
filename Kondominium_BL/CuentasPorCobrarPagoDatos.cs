using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kondominium_BL
{
    public class CuentasPorCobrarPagoDatos
    {
        private Kondominium_DAL.KEntities contex = new Kondominium_DAL.KEntities();

        public List<CuentasPorCobrarPagoEntity> GetAll()
        {
            var query = contex.cuentasporcobrarpago.Select(
                        cc => new CuentasPorCobrarPagoEntity
                        {
                            VaucherNumber = cc.VaucherNumber,
                            ClienteId = cc.ClienteId,
                            CuentasPorCobrarPagoId = cc.CuentasPorCobrarPagoId,
                            MetodoPago = cc.MetodoPago,
                            Observacion = cc.Observacion,
                            ReferenciaPago = cc.ReferenciaPago,
                            FechaDeCreacion = cc.FechaDeCreacion,
                            FechaDeModificacion = cc.FechaDeModificacion,
                            CreadoPor = cc.CreadoPor,
                            ModificadoPor = cc.ModificadoPor,
                            Monto = cc.Monto,
                            PropiedadId = cc.PropiedadId,
                            Estado = (int)cc.Estado,
                            Casa = cc.propiedades.Casa,
                            CasaLetra = cc.propiedades.CasaLetra,
                            PoligonoId = cc.propiedades.PoligonoId,
                            FullNameCondomino = string.Concat(cc.clientes.Nombres.Trim(), " ", cc.clientes.Apellidos.Trim())
                        });

            return query.ToList();
        }

        public CuentasPorCobrarPagoEntity GetByVaucherNumberId(string Id)
        {
            var query = contex.cuentasporcobrarpago.Where(x => x.VaucherNumber == Id).FirstOrDefault();
            var cxcpago = new CuentasPorCobrarPagoEntity();

            if (query == null)
                return cxcpago;
            else
            {
                cxcpago.VaucherNumber = query.VaucherNumber;
                cxcpago.ClienteId = query.ClienteId;
                cxcpago.CuentasPorCobrarPagoId = query.CuentasPorCobrarPagoId;
                cxcpago.MetodoPago = query.MetodoPago;
                cxcpago.Observacion = query.Observacion;
                cxcpago.ReferenciaPago = query.ReferenciaPago;
                cxcpago.FechaDeCreacion = query.FechaDeCreacion;
                cxcpago.FechaDeModificacion = query.FechaDeModificacion;
                cxcpago.CreadoPor = query.CreadoPor;
                cxcpago.ModificadoPor = query.ModificadoPor;
                cxcpago.Monto = query.Monto;
                cxcpago.PropiedadId = query.PropiedadId;
                cxcpago.Estado = (int)query.Estado;
                cxcpago.Casa = (int)(query.propiedades == null ? 0 : query.propiedades.Casa);
                cxcpago.CasaLetra = query.propiedades == null ? "" : query.propiedades.CasaLetra;
                cxcpago.PoligonoId = query.propiedades == null ? "" : query.propiedades.PoligonoId;
                cxcpago.FullNameCondomino = string.Concat(query.clientes.Nombres.Trim(), " ", query.clientes.Apellidos.Trim());
            }

            return cxcpago;
        }

        public CuentasPorCobrarPagoEntity GetById(int Id)
        {
            var query = from cc in contex.cuentasporcobrarpago
                        where cc.CuentasPorCobrarPagoId == Id
                        select new CuentasPorCobrarPagoEntity
                        {
                            VaucherNumber = cc.VaucherNumber,
                            ClienteId = cc.ClienteId,
                            CuentasPorCobrarPagoId = cc.CuentasPorCobrarPagoId,
                            MetodoPago = cc.MetodoPago,
                            Observacion = cc.Observacion,
                            ReferenciaPago = cc.ReferenciaPago,
                            FechaDeCreacion = cc.FechaDeCreacion,
                            FechaDeModificacion = cc.FechaDeModificacion,
                            CreadoPor = cc.CreadoPor,
                            ModificadoPor = cc.ModificadoPor,
                            Monto = cc.Monto,
                            PropiedadId = cc.PropiedadId,
                            Estado = (int)cc.Estado,
                            Casa = cc.propiedades.Casa,
                            CasaLetra = cc.propiedades.CasaLetra,
                            PoligonoId = cc.propiedades.PoligonoId,
                            FullNameCondomino = string.Concat(cc.clientes.Nombres.Trim(), " ", cc.clientes.Nombres.Trim())
                        };

            return query.FirstOrDefault();
        }


        public CuentasPorCobrarPagoEntity GetByVaucherNumber(string VaucherNumber)
        {
            var query = from cc in contex.cuentasporcobrarpago
                        where cc.VaucherNumber == VaucherNumber
                        select new CuentasPorCobrarPagoEntity
                        {
                            VaucherNumber = cc.VaucherNumber,
                            ClienteId = cc.ClienteId,
                            CuentasPorCobrarPagoId = cc.CuentasPorCobrarPagoId,
                            MetodoPago = cc.MetodoPago,
                            Observacion = cc.Observacion,
                            ReferenciaPago = cc.ReferenciaPago,
                            FechaDeCreacion = cc.FechaDeCreacion,
                            FechaDeModificacion = cc.FechaDeModificacion,
                            CreadoPor = cc.CreadoPor,
                            ModificadoPor = cc.ModificadoPor,
                            Monto = cc.Monto,
                            PropiedadId = cc.PropiedadId,
                            Estado = (int)cc.Estado,
                            Casa = cc.propiedades.Casa,
                            CasaLetra = cc.propiedades.CasaLetra,
                            PoligonoId = cc.propiedades.PoligonoId,
                            FullNameCondomino = string.Concat(cc.clientes.Nombres.Trim(), " ", cc.clientes.Nombres.Trim())
                        };

            return query.FirstOrDefault();
        }

        public (CuentasPorCobrarPagoEntity, Resultado) Save(CuentasPorCobrarPagoEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.cuentasporcobrarpago.Where(x => x.CuentasPorCobrarPagoId == model.CuentasPorCobrarPagoId).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.cuentasporcobrarpago();

                    if (modlExist != null)
                    {
                        //if (modlExist.Eliminado == true)
                        //    return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "Regstro ha sido marcado como eliminado, no se puede actualizar" });

                        modlNew = modlExist;
                    }

                    modlNew.ClienteId = model.ClienteId;
                    modlNew.VaucherNumber = model.VaucherNumber;

                    modlNew.MetodoPago = model.MetodoPago;
                    modlNew.Observacion = model.Observacion;
                    modlNew.ReferenciaPago = model.ReferenciaPago;
                    modlNew.FechaDeModificacion = DateTime.Now;
                    modlNew.ModificadoPor = model.ModificadoPor;
                    modlNew.Monto = model.Monto;
                    modlNew.PropiedadId = model.PropiedadId;

                    modlNew.FechadePago = model.FechadePago == null ? DateTime.Now : model.FechadePago;

                    if (modlNew.CuentasPorCobrarPagoId == 0)
                    {
                        if (model.VaucherNumber == null)
                            modlNew.VaucherNumber = new CorrelativosDatos().GenerateNextNumber("Pago");
                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;
                        modlNew.Estado = 1;
                        ContextP.cuentasporcobrarpago.Add(modlNew);
                    }
                    ContextP.SaveChanges();

                    model.CuentasPorCobrarPagoId = modlNew.CuentasPorCobrarPagoId;
                }

                return (GetById(model.CuentasPorCobrarPagoId), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {
                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logro almacenar el Registro \n" + ex.Message });
            }
        }

        public (CuentasPorCobrarPagoEntity, Resultado) SavePago(CuentasPorCobrarPagoEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.cuentasporcobrarpago.Where(x => x.CuentasPorCobrarPagoId == model.CuentasPorCobrarPagoId).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.cuentasporcobrarpago();

                    if (modlExist != null)
                    {
                        //if (modlExist.Eliminado == true)
                        //    return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "Regstro ha sido marcado como eliminado, no se puede actualizar" });

                        modlNew = modlExist;
                    }

                    modlNew.ClienteId = model.ClienteId;
                    modlNew.VaucherNumber = model.VaucherNumber;

                    modlNew.MetodoPago = model.MetodoPago;
                    modlNew.Observacion = model.Observacion;
                    modlNew.ReferenciaPago = model.ReferenciaPago;
                    modlNew.FechaDeModificacion = DateTime.Now;
                    modlNew.ModificadoPor = model.ModificadoPor;
                    modlNew.Monto = model.Monto;
                    modlNew.PropiedadId = model.PropiedadId;

                    modlNew.FechadePago = model.FechadePago;

                    if (model.CuentasPorCobrarPagoId == 0)
                    {
                        if (model.VaucherNumber == null)
                            modlNew.VaucherNumber = new CorrelativosDatos().GenerateNextNumber("Pago");

                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;
                        modlNew.Estado = 1;

                        ContextP.cuentasporcobrarpago.Add(modlNew);
                    }
                    ContextP.SaveChanges();

                    model.CuentasPorCobrarPagoId = modlNew.CuentasPorCobrarPagoId;
                }

                return (GetById(model.CuentasPorCobrarPagoId), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {
                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logro almacenar el Registro \n" + ex.Message });
            }
        }

        public (CuentasPorCobrarPagoEntity, Resultado) SavePagoProcess(CuentasPorCobrarPagoEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.cuentasporcobrarpago.Where(x => x.CuentasPorCobrarPagoId == model.CuentasPorCobrarPagoId).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.cuentasporcobrarpago();

                    if (modlExist != null)
                    {
                        //if (modlExist.Eliminado == true)
                        //    return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "Regstro ha sido marcado como eliminado, no se puede actualizar" });

                        modlNew = modlExist;
                    }

                    modlNew.ClienteId = model.ClienteId;
                    modlNew.VaucherNumber = model.VaucherNumber;

                    modlNew.MetodoPago = model.MetodoPago;
                    modlNew.Observacion = model.Observacion;
                    modlNew.ReferenciaPago = model.ReferenciaPago;
                    modlNew.FechaDeModificacion = DateTime.Now;
                    modlNew.ModificadoPor = model.ModificadoPor;
                    modlNew.Monto = model.Monto;
                    modlNew.PropiedadId = model.PropiedadId;

                    modlNew.FechadePago = model.FechadePago;

                    if (model.CuentasPorCobrarPagoId == 0)
                    {
                        if (model.VaucherNumber == null)
                            modlNew.VaucherNumber = new CorrelativosDatos().GenerateNextNumber("Pago");

                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;
                        modlNew.Estado = 3;

                        ContextP.cuentasporcobrarpago.Add(modlNew);
                    }
                    ContextP.SaveChanges();

                    model.CuentasPorCobrarPagoId = modlNew.CuentasPorCobrarPagoId;
                }

                return (GetById(model.CuentasPorCobrarPagoId), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {
                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logro almacenar el Registro \n" + ex.Message });
            }
        }

        public (CuentasPorCobrarPagoEntity, Resultado) SetEstado(int Id, string UserId, int Estado)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.cuentasporcobrarpago.Where(x => x.CuentasPorCobrarPagoId == Id).FirstOrDefault();
                    // var modlNew = new Kondominium_DAL.cuentasporcobrar();

                    if (modlExist != null)
                    {
                        //if (modlExist.Eliminado == true)
                        //    return (new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "Registro ha sido marcado como eliminado, no se puede actualizar" });
                    }

                    if (modlExist.Estado == 4)
                    {
                        return (GetById(Id), new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "El Registro ha sido Anulado no puede ser Actualizado" });
                    }

                    modlExist.Estado = Estado;

                    modlExist.FechaDeModificacion = DateTime.Now;
                    modlExist.ModificadoPor = UserId;
                    ContextP.SaveChanges();
                }

                return (GetById(Id), new Resultado { Codigo = 0, Mensaje = "Registro " + (Estado == 3 ? "Contabilizado" : (Estado == 4 ? "Anulado" : "procesado")) + " con exito" });
            }
            catch (Exception ex)
            {
                return (GetById(Id), new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logro procesar el Registro \n" + ex.Message });
            }
        }

        public (CuentasPorCobrarPagoEntity, Resultado) SetEstado(string VaucharNumber, string UserId, int Estado)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.cuentasporcobrarpago.Where(x => x.VaucherNumber == VaucharNumber).FirstOrDefault();
                    // var modlNew = new Kondominium_DAL.cuentasporcobrar();

                    if (modlExist != null)
                    {
                        //if (modlExist.Eliminado == true)
                        //    return (new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "Registro ha sido marcado como eliminado, no se puede actualizar" });
                    }

                    if (modlExist.Estado == 4)
                    {
                        return (GetById(modlExist.CuentasPorCobrarPagoId), new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "El Registro ha sido Anulado no puede ser Actualizado" });
                    }

                    modlExist.Estado = Estado;

                    modlExist.FechaDeModificacion = DateTime.Now;
                    modlExist.ModificadoPor = UserId;
                    ContextP.SaveChanges();
                }

                return (GetByVaucherNumber(VaucharNumber), new Resultado { Codigo = 0, Mensaje = "Registro " + (Estado == 3 ? "Contabilizado" : (Estado == 4 ? "Anulado" : "procesado")) + " con exito" });
            }
            catch (Exception ex)
            {
                return (GetByVaucherNumber(VaucharNumber), new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logro procesar el Registro \n" + ex.Message });
            }
        }

        public Resultado Delete(CuentasPorCobrarPagoEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.cuentasporcobrarpago.Where(x => x.CuentasPorCobrarPagoId == model.CuentasPorCobrarPagoId).FirstOrDefault();

                    if (modlExist != null)
                    {
                        ContextP.cuentasporcobrarpago.Remove(modlExist);
                        ContextP.SaveChanges();
                        return new Resultado { Codigo = 0, Mensaje = "Exito, Registro eliminado permanentemente" };
                    }
                    else
                        return new Resultado { Codigo = 0, Mensaje = "Registro no encontrado" };
                }
            }
            catch (Exception ex)
            {
                return new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logró eliminar el Registro \n" + ex.Message };
            }
        }

        //public Resultado SetDelete(string Id, string UserId)
        //{
        //    try
        //    {
        //        using (var ContextP = new Kondominium_DAL.KEntities())
        //        {
        //            var modlExist = ContextP.cuentasporcobrarpago.Where(x => x.VaucherNumber == Id).FirstOrDefault();
        //            // var modlNew = new Kondominium_DAL.cuentasporcobrarpago();

        //            if (modlExist == null)
        //                return (new Resultado { Codigo = CodigosMensaje.No_Existe, Mensaje = "Registro no Existe" });

        //            modlExist.Eliminado = true;

        //            modlExist.FechaDeModificacion = DateTime.Now;
        //            modlExist.ModificadoPor = UserId;
        //            ContextP.SaveChanges();
        //        }

        //        return (new Resultado { Codigo = 0, Mensaje = "Registro eliminado con exito" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return (new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logro Eliminar el Registro \n" + ex.Message });
        //    }

        //}
    }
}
using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kondominium_BL
{
    public class CuentasPorCobrarPagoDatos
    {
        Kondominium_DAL.KEntities contex = new Kondominium_DAL.KEntities();
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
                            FechadePago = cc.FechadePago,
                            ClientFullName =   cc.clientes.Nombres + " " + cc.clientes.Apellidos,
                            VPropiedad = cc.propiedades.PoligonoId + "-" + cc.propiedades.Casa.ToString() +  cc.propiedades.CasaLetra,
                            Estado = cc.Estado
                        });



            return query.ToList();
        }

        public CuentasPorCobrarPagoEntity GetByVaucherNumberId(string Id)
        {
            var query = from cc in contex.cuentasporcobrarpago
                        where cc.VaucherNumber == Id
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
                            FechadePago = cc.FechadePago,
                            Estado = cc.Estado
                        };

            return query.FirstOrDefault();
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
                            FechadePago = cc.FechadePago,
                            Estado = cc.Estado
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

                    modlNew.FechadePago = model.FechadePago;


                    if (modlNew.CuentasPorCobrarPagoId == 0)
                    {

                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;

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


                    if (string.IsNullOrEmpty(modlNew.VaucherNumber))
                    {
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

        public Resultado SetEstado(string Id, string UserId, int Estado)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {

                    var modlExist = ContextP.cuentasporcobrarpago.Where(x => x.VaucherNumber == Id).FirstOrDefault();
                    // var modlNew = new Kondominium_DAL.cuentasporcobrar();


                    if (modlExist != null)
                    {
                        //if (modlExist.Eliminado == true)
                        //    return (new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "Registro ha sido marcado como eliminado, no se puede actualizar" });
                    }

                    if (modlExist.Estado == 4)
                    {
                        return (new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "El Registro ha sido Anulado no puede ser Actualizado" });
                    }

                    modlExist.Estado = Estado;

                    modlExist.FechaDeModificacion = DateTime.Now;
                    modlExist.ModificadoPor = UserId;
                    ContextP.SaveChanges();
                }

                return (new Resultado { Codigo = 0, Mensaje = "Registro " + (Estado == 3 ? "Contabilizado" : (Estado == 4 ? "Anulado" : "procesado")) + " con exito" });
            }
            catch (Exception ex)
            {

                return (new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logro procesar el Registro \n" + ex.Message });
            }

        }


        public Resultado Delete(CuentasPorCobrarPagoEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.cuentasporcobrarpago.Where(x => x.VaucherNumber == model.VaucherNumber).FirstOrDefault();

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

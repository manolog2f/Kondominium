using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_BL
{
   public class CuentasPorCobrarDatos
    {
        Kondominium_DAL.KEntities contex = new Kondominium_DAL.KEntities();
        public List<CuentasPorCobrarEntity> GetAll(bool VerEliminado = false)
        {
            var query = from cc in contex.cuentasporcobrar
                        where VerEliminado ? cc.Eliminado == cc.Eliminado : cc.Eliminado == false
                        select new CuentasPorCobrarEntity
                        {
                            VaucherNumber = cc.VaucherNumber,
                            ClienteId = cc.ClienteId,
                            TipoCxC = cc.TipoCxC,
                            FechaDeEmision = cc.FechaDeEmision,
                            FechaDeVencimiento = cc.FechaDeVencimiento,
                            PeriodoFacturado = cc.PeriodoFacturado,
                            Total = cc.Total,
                            NPE = cc.NPE,
                            BRCode =cc.BRCode,
                            FechaDeCreacion = cc.FechaDeCreacion,
                            FechaDeModificacion = cc.FechaDeModificacion,
                            CreadoPor =cc.CreadoPor,
                            ModificadoPor = cc.ModificadoPor,
                            Eliminado = cc.Eliminado,
                            PropiedadId = cc.PropiedadId
                        };



            return query.ToList();
        }

        public CuentasPorCobrarEntity GetById(string Id)
        {
            var query = from cc in contex.cuentasporcobrar
                        where cc.VaucherNumber == Id
                        select new CuentasPorCobrarEntity
                        {
                            VaucherNumber = cc.VaucherNumber,
                            ClienteId = cc.ClienteId,
                            TipoCxC = cc.TipoCxC,
                            FechaDeEmision = cc.FechaDeEmision,
                            FechaDeVencimiento = cc.FechaDeVencimiento,
                            PeriodoFacturado = cc.PeriodoFacturado,
                            Total = cc.Total,
                            NPE = cc.NPE,
                            BRCode = cc.BRCode,
                            FechaDeCreacion = cc.FechaDeCreacion,
                            FechaDeModificacion = cc.FechaDeModificacion,
                            CreadoPor = cc.CreadoPor,
                            ModificadoPor = cc.ModificadoPor,
                            Eliminado = cc.Eliminado,
                            PropiedadId = cc.PropiedadId
                        };

            return query.FirstOrDefault();
        }

        public (CuentasPorCobrarEntity, Resultado) Save(CuentasPorCobrarEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.cuentasporcobrar.Where(x => x.VaucherNumber == model.VaucherNumber).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.cuentasporcobrar();


                    if (modlExist != null)
                    {
                        if (modlExist.Eliminado == true)
                            return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "Regstro ha sido marcado como eliminado, no se puede actualizar" });

                        modlNew = modlExist;
                    }

                    //diciembre2021
                    //NOviembre
                    //Septiembre2021
                    //modlNew.VaucherNumber = model.VaucherNumber;
                    modlNew.ClienteId = model.ClienteId;
                    modlNew.TipoCxC = model.TipoCxC;
                    modlNew.FechaDeEmision = model.FechaDeEmision;
                    modlNew.FechaDeVencimiento = model.FechaDeVencimiento;
                    modlNew.PeriodoFacturado = model.PeriodoFacturado;
                    modlNew.Total = model.Total;
                    modlNew.NPE = model.NPE==null?"": model.NPE;
                    modlNew.BRCode = model.BRCode==null?"": model.BRCode;
                    
                    modlNew.FechaDeModificacion = DateTime.Now;
                    modlNew.ModificadoPor = model.ModificadoPor;
                    modlNew.Eliminado = model.Eliminado;
                    modlNew.Estado = 0;
                    modlNew.PropiedadId = model.PropiedadId;

                    if (string.IsNullOrEmpty(modlNew.VaucherNumber))
                    {
                        modlNew.VaucherNumber = new CxcTypeDatos().GenerateNextNumber(model.TipoCxC);
                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;

                        ContextP.cuentasporcobrar.Add(modlNew);
                    }
                    ContextP.SaveChanges();

                    model.VaucherNumber = modlNew.VaucherNumber;
                }

                return (GetById(model.VaucherNumber), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {

                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logro almacenar el Registro \n" + ex.Message });
            }

        }

        public Resultado Delete(CuentasPorCobrarEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.cuentasporcobrar.Where(x => x.VaucherNumber == model.VaucherNumber).FirstOrDefault();

                    if (modlExist != null)
                    {
                        ContextP.cuentasporcobrar.Remove(modlExist);
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
        public Resultado SetDelete(string Id, string UserId)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {

                    var modlExist = ContextP.cuentasporcobrar.Where(x => x.VaucherNumber == Id).FirstOrDefault();
                    // var modlNew = new Kondominium_DAL.cuentasporcobrar();


                    if (modlExist == null)
                        return (new Resultado { Codigo = CodigosMensaje.No_Existe, Mensaje = "Registro no Existe" });


                    if (modlExist.Estado == 4)
                    {
                        return (new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "El Registro ha sido Anulado no puede ser Actualizado" });
                    }

                    modlExist.Eliminado = true;

                    modlExist.FechaDeModificacion = DateTime.Now;
                    modlExist.ModificadoPor = UserId;
                    ContextP.SaveChanges();
                }

                return (new Resultado { Codigo = 0, Mensaje = "Registro eliminado con exito" });
            }
            catch (Exception ex)
            {

                return (new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logro Eliminar el Registro \n" + ex.Message });
            }

        }

        public Resultado SetEstado(string Id, string UserId, int Estado)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {

                    var modlExist = ContextP.cuentasporcobrar.Where(x => x.VaucherNumber == Id).FirstOrDefault();
                    // var modlNew = new Kondominium_DAL.cuentasporcobrar();


                    if (modlExist != null)
                    {
                        if (modlExist.Eliminado == true)
                            return ( new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "Registro ha sido marcado como eliminado, no se puede actualizar" });
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

                return (new Resultado { Codigo = 0, Mensaje = "Registro "+  (Estado == 3?"Contabilizado": (Estado == 4?"Anulado":"procesado"))  +" con exito" });
            }
            catch (Exception ex)
            {

                return (new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logro procesar el Registro \n" + ex.Message });
            }

        }

        //3Contabilizado // 4 Anulado
    }
}

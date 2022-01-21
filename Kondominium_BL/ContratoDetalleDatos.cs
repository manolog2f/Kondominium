using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kondominium_BL
{
    public class ContratoDetalleDatos
    {
        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public List<ContratosDetalleEntity> GetAll(bool VerEliminado = false)
        {
            var query = context.contratosdetalle.Select(x => new ContratosDetalleEntity
            {
                ContratoId = x.ContratoId,
                Monto = x.Monto,
                ProductoId = x.ProductoId
            });

            return query.ToList();
        }
        public ContratosDetalleEntity GetById(int Id)
        {
            var query = context.contratosdetalle.Where(x => x.ContratoId == Id).Select(x => new ContratosDetalleEntity
            {
                ContratoId = x.ContratoId,
                Monto = x.Monto,
                ProductoId = x.ProductoId
            });

            return query.FirstOrDefault();
        }

        public (ContratosDetalleEntity, Resultado) Save(ContratosDetalleEntity model)
        {
            try
            {
                using (var cn = new Kondominium_DAL.KEntities())
                {
                    var modlExist = cn.contratosdetalle.Where(x => x.ContratoId == model.ContratoId && x.ProductoId == model.ProductoId).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.contratosdetalle();

                    if (modlExist != null)
                    {

                        modlNew = modlExist;
                    }

                    // 
                    modlNew.Monto = model.Monto;

                    if (modlExist == null)
                    {
                        modlNew.ContratoId = model.ContratoId;
                        modlNew.ProductoId = model.ProductoId;

                        cn.contratosdetalle.Add(modlNew);
                    }
                    cn.SaveChanges();

                }

                return (GetById(model.ContratoId), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {
                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "El registro no pudo ser guardado. \n" + ex.Message });

            }
        }

        public Resultado Delete(ContratosDetalleEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.contratosdetalle.Where(x => x.ContratoId == model.ContratoId && x.ProductoId == model.ProductoId).FirstOrDefault();

                    if (modlExist != null)
                    {
                        ContextP.contratosdetalle.Remove(modlExist);
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
        //public Resultado SetDelete(int Id, string UserId)
        //{
        //    try
        //    {
        //        using (var ContextP = new Kondominium_DAL.KEntities())
        //        {

        //            var modlExist = ContextP.contratos.Where(x => x.ContratoId == Id).FirstOrDefault();
        //            // var modlNew = new Kondominium_DAL.Contratos();


        //            if (modlExist == null)
        //                return (new Resultado { Codigo = CodigosMensaje.No_Existe, Mensaje = "Registro no Existe" });

        //            //modlExist.Eliminado = true;

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

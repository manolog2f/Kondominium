using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kondominium_BL
{
    public class SendasDatos
    {
        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public List<SendasEntity> GetAll(bool VerEliminado = false)
        {
            var query = from p in context.sendas
                        where VerEliminado ? p.Eliminado == p.Eliminado : p.Eliminado == false
                        select new SendasEntity
                        {
                            SendaId = p.SendaId,
                            SendaDescripcion = p.SendaDescripcion,
                            FechaDeCreacion = (DateTime)p.FechaDeCreacion,
                            FechaDeModificacion = p.FechaDeModificacion,
                            CreadoPor = p.CreadoPor,
                            ModificadoPor = p.ModificadoPor,
                            Eliminado = p.Eliminado,
                        };


            return query.ToList();
        }
        public SendasEntity GetById(string Id)
        {
            var query = from p in context.sendas
                        where p.SendaId == Id
                        select new SendasEntity
                        {
                            SendaId = p.SendaId,
                            SendaDescripcion = p.SendaDescripcion,
                            FechaDeCreacion = (DateTime)p.FechaDeCreacion,
                            FechaDeModificacion = p.FechaDeModificacion,
                            CreadoPor = p.CreadoPor,
                            ModificadoPor = p.ModificadoPor,
                            Eliminado = p.Eliminado,
                        };

            return query.FirstOrDefault();
        }

        public (SendasEntity, Resultado) Save(SendasEntity model)
        {
            try
            {
                using (var cn = new Kondominium_DAL.KEntities())
                {
                    var modlExist = cn.sendas.Where(x => x.SendaId == model.SendaId).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.sendas();

                    if (modlExist != null)
                    {
                        if (modlExist.Eliminado == true)
                            return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "Regstro ha sido marcado como eliminado, no se puede actualizar" });

                        modlNew = modlExist;
                    }

                    modlNew.SendaId = model.SendaId;
                    modlNew.SendaDescripcion = model.SendaDescripcion;
                    modlNew.Eliminado = model.Eliminado;
                    modlNew.FechaDeModificacion = DateTime.Now;
                    modlNew.ModificadoPor = model.ModificadoPor;



                    if (modlExist == null)
                    {
                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;

                        cn.sendas.Add(modlNew);
                    }
                    cn.SaveChanges();

                    model.SendaId = modlNew.SendaId;

                }

                return (GetById(model.SendaId), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {
                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "El registro no pudo ser guardado. \n" + ex.Message });

            }
        }

        public Resultado Delete(SendasEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.sendas.Where(x => x.SendaId == model.SendaId).FirstOrDefault();

                    if (modlExist != null)
                    {
                        ContextP.sendas.Remove(modlExist);
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

                    var modlExist = ContextP.sendas.Where(x => x.SendaId == Id).FirstOrDefault();
                    // var modlNew = new Kondominium_DAL.Sendas();


                    if (modlExist == null)
                        return (new Resultado { Codigo = CodigosMensaje.No_Existe, Mensaje = "Registro no Existe" });

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
    }
}

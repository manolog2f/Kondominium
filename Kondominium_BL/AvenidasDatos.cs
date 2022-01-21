using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kondominium_BL
{
    public class AvenidasDatos
    {
        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public List<AvenidasEntity> GetAll(bool VerEliminado = false)
        {
            var query = from p in context.avenida
                        where VerEliminado ? p.Eliminado == p.Eliminado : p.Eliminado == false
                        select new AvenidasEntity
                        {
                            AvenidaId = p.AvenidaId,
                            AvenidaDescripcion = p.AvenidaDescripcion,
                            FechaDeCreacion = (DateTime)p.FechaDeCreacion,
                            FechaDeModificacion = p.FechaDeModificacion,
                            CreadoPor = p.CreadoPor,
                            ModificadoPor = p.ModificadoPor,
                            Eliminado = p.Eliminado,
                        };


            return query.ToList();
        }
        public AvenidasEntity GetById(string Id)
        {
            var query = from p in context.avenida
                        where p.AvenidaId == Id
                        select new AvenidasEntity
                        {
                            AvenidaId = p.AvenidaId,
                            AvenidaDescripcion = p.AvenidaDescripcion,
                            FechaDeCreacion = (DateTime)p.FechaDeCreacion,
                            FechaDeModificacion = p.FechaDeModificacion,
                            CreadoPor = p.CreadoPor,
                            ModificadoPor = p.ModificadoPor,
                            Eliminado = p.Eliminado,
                        };

            return query.FirstOrDefault();
        }

        public (AvenidasEntity, Resultado) Save(AvenidasEntity model)
        {
            try
            {
                using (var cn = new Kondominium_DAL.KEntities())
                {
                    var modlExist = cn.avenida.Where(x => x.AvenidaId == model.AvenidaId).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.avenida();

                    if (modlExist != null)
                    {
                        if (modlExist.Eliminado == true)
                            return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "Regstro ha sido marcado como eliminado, no se puede actualizar" });

                        modlNew = modlExist;
                    }

                    modlNew.AvenidaId = model.AvenidaId;
                    modlNew.AvenidaDescripcion = model.AvenidaDescripcion;
                    modlNew.Eliminado = model.Eliminado;
                    modlNew.FechaDeModificacion = DateTime.Now;
                    modlNew.ModificadoPor = model.ModificadoPor;



                    if (modlExist == null)
                    {
                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;

                        cn.avenida.Add(modlNew);
                    }
                    cn.SaveChanges();

                    model.AvenidaId = modlNew.AvenidaId;

                }

                return (GetById(model.AvenidaId), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {
                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "El registro no pudo ser guardado. \n" + ex.Message });

            }
        }

        public Resultado Delete(AvenidasEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.avenida.Where(x => x.AvenidaId == model.AvenidaId).FirstOrDefault();

                    if (modlExist != null)
                    {
                        ContextP.avenida.Remove(modlExist);
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

                    var modlExist = ContextP.avenida.Where(x => x.AvenidaId == Id).FirstOrDefault();
                    // var modlNew = new Kondominium_DAL.Avenidas();


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

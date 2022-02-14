using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_BL
{
   public class AlamedaDatos
    {
        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public List<AlamedaEntity> GetAll(bool VerEliminado = false)
        {
            var query = from p in context.alameda
                        where VerEliminado ? p.Eliminado == p.Eliminado : p.Eliminado == false
                        select new AlamedaEntity
                        {
                            AlamedaId = p.AlamedaId,
                            AlamedaDescripcion = p.AlamedaDescripcion,
                            FechaDeCreacion = (DateTime)p.FechaDeCreacion,
                            FechaDeModificacion = p.FechaDeModificacion,
                            CreadoPor = p.CreadoPor,
                            ModificadoPor = p.ModificadoPor,
                            Eliminado = p.Eliminado,
                            
                        };


            return query.ToList();
        }
        public AlamedaEntity GetById(string Id)
        {
            var query = from p in context.alameda
                        where p.AlamedaId == Id
                        select new AlamedaEntity
                        {
                            AlamedaId = p.AlamedaId,
                            AlamedaDescripcion = p.AlamedaDescripcion,
                            FechaDeCreacion = (DateTime)p.FechaDeCreacion,
                            FechaDeModificacion = p.FechaDeModificacion,
                            CreadoPor = p.CreadoPor,
                            ModificadoPor = p.ModificadoPor,
                            Eliminado = p.Eliminado,
                        };

            return query.FirstOrDefault();
        }

        public (AlamedaEntity, Resultado) Save(AlamedaEntity model)
        {
            try
            {
                using (var cn = new Kondominium_DAL.KEntities())
                {
                    var modlExist = cn.alameda.Where(x => x.AlamedaId == model.AlamedaId).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.alameda();

                    if (modlExist != null)
                    {
                        if (modlExist.Eliminado == true)
                            return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "Regstro ha sido marcado como eliminado, no se puede actualizar" });

                        modlNew = modlExist;
                    }

                    modlNew.AlamedaId = model.AlamedaId;
                    modlNew.AlamedaDescripcion = model.AlamedaDescripcion;
                    modlNew.Eliminado = model.Eliminado;
                    modlNew.FechaDeModificacion = DateTime.Now;
                    modlNew.ModificadoPor = model.ModificadoPor;



                    if (modlExist == null)
                    {
                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;

                        cn.alameda.Add(modlNew);
                    }
                    cn.SaveChanges();

                    model.AlamedaId = modlNew.AlamedaId;

                }

                return (GetById(model.AlamedaId), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {
                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "El registro no pudo ser guardado. \n" + ex.Message });

            }
        }

        public Resultado Delete(AlamedaEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.alameda.Where(x => x.AlamedaId == model.AlamedaId).FirstOrDefault();

                    if (modlExist != null)
                    {
                        ContextP.alameda.Remove(modlExist);
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

                    var modlExist = ContextP.alameda.Where(x => x.AlamedaId == Id).FirstOrDefault();
                    // var modlNew = new Kondominium_DAL.alamedas();


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

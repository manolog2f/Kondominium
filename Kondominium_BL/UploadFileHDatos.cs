using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_BL
{
    public class UploadFileHDatos
    {
        private Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();

        public Resultado Delete(UploadFileHEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.uploadfileh.Where(x => x.UploadFileHId == model.UploadFileHId).FirstOrDefault();

                    if (modlExist != null)
                    {
                        ContextP.uploadfileh.Remove(modlExist);
                        ContextP.SaveChanges();
                        return new Resultado { Codigo = 0, Mensaje = "Exito Resgistro Eliminado Permanetemente" };
                    }
                    else
                        return new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "Registro no encontrado" };
                }
            }
            catch (Exception ex)
            {
                return new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logro eliminar el Registro \n" + ex.Message };
            }
        }

        public List<UploadFileHEntity> GetAll(bool VerEliminado = false)
        {
            var query = from a in context.uploadfileh
                        select new UploadFileHEntity
                        {
                            Estado = a.Estado,
                            FileName = a.FileName,
                            UploadDate = a.UploadDate,
                            UploadFileHId = a.UploadFileHId,
                            UserId = a.UserId
                        };

            return query.ToList();
        }

        public UploadFileHEntity GetById(int Id)
        {
            var query = from a in context.uploadfileh
                        where a.UploadFileHId == Id
                        select new UploadFileHEntity
                        {
                            Estado = a.Estado,
                            FileName = a.FileName,
                            UploadDate = a.UploadDate,
                            UploadFileHId = a.UploadFileHId,
                            UserId = a.UserId
                        };

            return query.FirstOrDefault();
        }

        public (UploadFileHEntity, Resultado) Save(UploadFileHEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.uploadfileh.Where(x => x.UploadFileHId == model.UploadFileHId).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.uploadfileh();

                    if (modlExist != null)
                    {
                        //TODO: Esta parte del eliminado Agregarlo a los demas metodos de Datos
                        //if (modlExist.Eliminado == true)
                        //    return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "Regstro ha sido marcado como eliminado, no se puede actualizar" });

                        modlNew = modlExist;
                    }

                    modlNew.FileName = model.FileName;
                    modlNew.Estado = model.Estado;

                    if (modlNew.UploadFileHId == 0)
                    {
                        modlNew.UploadDate = DateTime.Now;
                        modlNew.UserId = model.UserId;

                        ContextP.uploadfileh.Add(modlNew);
                    }
                    ContextP.SaveChanges();

                    model.UploadFileHId = modlNew.UploadFileHId;
                }

                return (GetById(model.UploadFileHId), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {
                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logro almacenar el Registro \n" + ex.Message });
            }
        }

        //TODO: Crear set delete en todos los Accesos a Datos que contengan Eliminado.
        //public Resultado SetDelete(int Id, string UserId)
        //{
        //    try
        //    {
        //        using (var ContextP = new Kondominium_DAL.KEntities())
        //        {
        //            var modlExist = ContextP.uploadfileh.Where(x => x.ArancelId == Id).FirstOrDefault();
        //            // var modlNew = new Kondominium_DAL.aranceles();

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
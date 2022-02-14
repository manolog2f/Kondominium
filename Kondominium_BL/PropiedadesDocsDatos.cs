using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_BL
{
   public class PropiedadesDocsDatos
    {

        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public List<PropiedadesDocsEntity> GetAll(bool VerEliminado = false)
        {
            var query = from p in context.propiedadesdocs
                        select new PropiedadesDocsEntity
                        {
                          
                            PropiedadId = p.PropiedadId,
                            UrlDocument = p.UrlDocument,
                            Document = p.Document,
                            FechaDeCreacion = p.FechaDeCreacion,
                            FechaDeModificacion = p.FechaDeModificacion,
                            CreadoPor = p.CreadoPor,
                            ModificadoPor = p.ModificadoPor,
                            PropiedadesDocId = p.PropiedadesDocId,
                            DocumentType = p.DocumentType
                            
                        };

            return query.ToList();
        }
        public PropiedadesDocsEntity GetById(int PropiedadId, string TipoDocumento)
        {
            var query = from p in context.propiedadesdocs
                        where p.PropiedadId == PropiedadId && p.PropiedadId == PropiedadId && p.DocumentType == TipoDocumento
                        select new PropiedadesDocsEntity
                        {
                            PropiedadId = p.PropiedadId,
                            UrlDocument = p.UrlDocument,
                            Document = p.Document,
                            FechaDeCreacion = p.FechaDeCreacion,
                            FechaDeModificacion = p.FechaDeModificacion,
                            CreadoPor = p.CreadoPor,
                            ModificadoPor = p.ModificadoPor,
                            PropiedadesDocId = p.PropiedadesDocId,
                            DocumentType = p.DocumentType
                        };

            return query.FirstOrDefault();
        }
        public PropiedadesDocsEntity GetById(int PropiedadId)
        {
            var query = from p in context.propiedadesdocs
                        where p.PropiedadId == PropiedadId && p.PropiedadId == PropiedadId 
                        select new PropiedadesDocsEntity
                        {
                            PropiedadId = p.PropiedadId,
                            UrlDocument = p.UrlDocument,
                            Document = p.Document,
                            FechaDeCreacion = p.FechaDeCreacion,
                            FechaDeModificacion = p.FechaDeModificacion,
                            CreadoPor = p.CreadoPor,
                            ModificadoPor = p.ModificadoPor,
                            PropiedadesDocId = p.PropiedadesDocId,
                            DocumentType = p.DocumentType
                        };

            return query.FirstOrDefault();
        }

        public PropiedadesDocsEntity GetByDocumentId(int DocumentId)
        {
            var query = from p in context.propiedadesdocs
                        where p.PropiedadesDocId == DocumentId
                        select new PropiedadesDocsEntity
                        {
                            PropiedadId = p.PropiedadId,
                            UrlDocument = p.UrlDocument,
                            Document = p.Document,
                            FechaDeCreacion = p.FechaDeCreacion,
                            FechaDeModificacion = p.FechaDeModificacion,
                            CreadoPor = p.CreadoPor,
                            ModificadoPor = p.ModificadoPor,
                            PropiedadesDocId = p.PropiedadesDocId,
                            DocumentType = p.DocumentType
                        };

            return query.FirstOrDefault();
        }

        public List<PropiedadesDocsEntity> GetListById(int PropiedadId)
        {
            var query = from p in context.propiedadesdocs
                        where p.PropiedadId == PropiedadId && p.PropiedadId == PropiedadId
                        select new PropiedadesDocsEntity
                        {
                            PropiedadId = p.PropiedadId,
                            UrlDocument = p.UrlDocument,
                            Document = p.Document,
                            FechaDeCreacion = p.FechaDeCreacion,
                            FechaDeModificacion = p.FechaDeModificacion,
                            CreadoPor = p.CreadoPor,
                            ModificadoPor = p.ModificadoPor,
                            PropiedadesDocId = p.PropiedadesDocId,
                            DocumentType = p.DocumentType
                        };

            return query.ToList();
        }


        public (PropiedadesDocsEntity, Resultado) Save(PropiedadesDocsEntity model)
        {
            try
            {
                using (var cn = new Kondominium_DAL.KEntities())
                {
                    var modlExist = cn.propiedadesdocs.Where(x => x.PropiedadesDocId == model.PropiedadesDocId).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.propiedadesdocs();

                    if (modlExist != null)
                    {
                        modlNew = modlExist;
                    }


                    
                    modlNew.PropiedadId = model.PropiedadId;
                    modlNew.UrlDocument = model.UrlDocument;
                    modlNew.Document = model.Document;
                    modlNew.DocumentType = model.DocumentType;



                    modlNew.FechaDeModificacion = DateTime.Now;
                    modlNew.ModificadoPor = model.ModificadoPor;



                    if (modlExist == null)
                    {
                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;

                        cn.propiedadesdocs.Add(modlNew);
                    }
                    cn.SaveChanges();

                    model.PropiedadesDocId = modlNew.PropiedadesDocId;
                }

                return (GetById(model.PropiedadesDocId), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {
                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "El registro no pudo ser guardado. \n" + ex.Message });

            }
        }

        public Resultado Delete(PropiedadesDocsEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.propiedadesdocs.Where(p => p.PropiedadesDocId == model.PropiedadesDocId).FirstOrDefault();

                    if (modlExist != null)
                    {
                        ContextP.propiedadesdocs.Remove(modlExist);
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
        //public Resultado SetDelete(int ClienteId, int PropiedadId, string TipoCliente, string UserId)
        //{
        //    try
        //    {
        //        using (var ContextP = new Kondominium_DAL.KEntities())
        //        {

        //            var modlExist = ContextP.propiedadesdocs.Where(x => x.ClienteId == ClienteId && x.PropiedadId == PropiedadId && x.TipoCliente == TipoCliente).FirstOrDefault();
        //            // var modlNew = new Kondominium_DAL.propiedadesdocs();


        //            if (modlExist == null)
        //                return (new Resultado { Codigo = CodigosMensaje.No_Existe, Mensaje = "Registro no Existe" });

        //            modlExist.Eliminado = true;

        //            modlExist.FechaModificacion = DateTime.Now;
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

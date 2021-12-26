using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_BL
{
  public  class ClienteDocsDatos
    {
        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public List<ClienteDocsEntity> GetAll(bool VerEliminado = false)
        {
            var query = from p in context.clientesdocs
                        select new ClienteDocsEntity
                        {
                            ClienteId = p.ClienteId,
                            DocumentType = p.DocumentType,
                            UrlDocument = p.UrlDocument,
                            Document = p.Document,
                            FechaDeCreacion = (DateTime)p.FechaDeCreacion,
                            FechaDeModificacion = p.FechaDeModificacion,
                            CreadoPor = p.CreadoPor,
                            ModificadoPor = p.ModificadoPor
                            ,ClienteDocId = p.ClienteDocId
                        };

            return query.ToList();
        }
        public ClienteDocsEntity GetById(int ClienteId, string DocumentType)
        {
            var query = from p in context.clientesdocs
                        where p.ClienteId == ClienteId && p.DocumentType == DocumentType
                        select new ClienteDocsEntity
                        {
                            ClienteId = p.ClienteId,
                            DocumentType = p.DocumentType,
                            UrlDocument = p.UrlDocument,
                            Document = p.Document,
                            FechaDeCreacion = (DateTime)p.FechaDeCreacion,
                            FechaDeModificacion = p.FechaDeModificacion,
                            CreadoPor = p.CreadoPor,
                            ModificadoPor = p.ModificadoPor
                            ,ClienteDocId = p.ClienteDocId
                        };

            return query.FirstOrDefault();
        }

        public ClienteDocsEntity GetByClienteDocId(int ClienteDocId)
        {
            var query = from p in context.clientesdocs
                        where p.ClienteDocId == ClienteDocId
                        select new ClienteDocsEntity
                        {
                            ClienteId = p.ClienteId,
                            DocumentType = p.DocumentType,
                            UrlDocument = p.UrlDocument,
                            Document = p.Document,
                            FechaDeCreacion = (DateTime)p.FechaDeCreacion,
                            FechaDeModificacion = p.FechaDeModificacion,
                            CreadoPor = p.CreadoPor,
                            ModificadoPor = p.ModificadoPor
                            ,
                            ClienteDocId = p.ClienteDocId
                        };

            return query.FirstOrDefault();
        }


        public List<ClienteDocsEntity> GetById(int ClienteId)
        {
            var query = from p in context.clientesdocs
                        where p.ClienteId == ClienteId
                        select new ClienteDocsEntity
                        {
                            ClienteId = p.ClienteId,
                            DocumentType = p.DocumentType,
                            UrlDocument = p.UrlDocument,
                            Document = p.Document,
                            FechaDeCreacion = (DateTime)p.FechaDeCreacion,
                            FechaDeModificacion = p.FechaDeModificacion,
                            CreadoPor = p.CreadoPor,
                            ModificadoPor = p.ModificadoPor,
                            ClienteDocId = p.ClienteDocId
                        };

            return query.ToList();
        }

        public (ClienteDocsEntity, Resultado) Save(ClienteDocsEntity model)
        {
            try
            {
                using (var cn = new Kondominium_DAL.KEntities())
                {
                    var modlExist = cn.clientesdocs.Where(x => x.ClienteDocId == model.ClienteDocId).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.clientesdocs();

                    if (modlExist != null)
                    {
                    
                        modlNew = modlExist;
                    }

                    modlNew.ClienteId = model.ClienteId;
                    modlNew.DocumentType = model.DocumentType;
                    modlNew.UrlDocument = model.UrlDocument;
                    modlNew.Document = model.Document;
                    modlNew.FechaDeModificacion = DateTime.Now;
                    modlNew.ModificadoPor = model.ModificadoPor;


                    if (modlExist == null)
                    {
                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;

                        cn.clientesdocs.Add(modlNew);
                    }
                    cn.SaveChanges();

                    
                }

                return (GetById(model.ClienteId, model.DocumentType), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {
                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "El registro no pudo ser guardado. \n" + ex.Message });

            }
        }

        public Resultado Delete(ClienteDocsEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.clientesdocs.Where(x => x.ClienteDocId == model.ClienteDocId ).FirstOrDefault();

                    if (modlExist != null)
                    {
                        ContextP.clientesdocs.Remove(modlExist);
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
       
    }
}

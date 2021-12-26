using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_BL
{
    public class ClientePropiedadDocsDatos
    {
        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public List<ClientePropiedadDocsEntity> GetAll(bool VerEliminado = false)
        {
            var query = from p in context.clientepropiedaddocs
                        where VerEliminado ? p.Eliminado == p.Eliminado : p.Eliminado == false
                        select new ClientePropiedadDocsEntity
                        {
                            ClienteId = p.ClienteId,
                            PropiedadId = p.PropiedadId,
                            TipoCliente = p.TipoCliente,
                            UrlDocument = p.UrlDocument,
                            Document = p.Document,
                            FechaDeCreacion = p.FechaDeCreacion,
                            FechaModificacion = p.FechaModificacion,
                            CreadoPor = p.CreadoPor,
                            ModificadoPor = p.ModificadoPor,
                            Eliminado = p.Eliminado,
                            ClientePropiedadDocsId = p.ClientePropiedadDocsId,
                            DocumentType = p.DocumentType
                        };

            return query.ToList();
        }
        public ClientePropiedadDocsEntity GetById(int ClienteId, int PropiedadId, string TipoCliente, string TipoDocumento)
        {
            var query = from p in context.clientepropiedaddocs
                        where p.ClienteId == ClienteId && p.PropiedadId == PropiedadId && p.TipoCliente == TipoCliente && p.DocumentType == TipoDocumento
                        select new ClientePropiedadDocsEntity
                        {

                            ClienteId = p.ClienteId,
                            PropiedadId = p.PropiedadId,
                            TipoCliente = p.TipoCliente,
                            UrlDocument = p.UrlDocument,
                            Document = p.Document,
                            FechaDeCreacion = p.FechaDeCreacion,
                            FechaModificacion = p.FechaModificacion,
                            CreadoPor = p.CreadoPor,
                            ModificadoPor = p.ModificadoPor,
                            Eliminado = p.Eliminado,
                            ClientePropiedadDocsId = p.ClientePropiedadDocsId,
                            DocumentType = p.DocumentType
                        };

            return query.FirstOrDefault();
        }

        public List<ClientePropiedadDocsEntity> GetById(int ClienteId, int PropiedadId, string TipoCliente)
        {
            var query = from p in context.clientepropiedaddocs
                        where p.ClienteId == ClienteId && p.PropiedadId == PropiedadId && p.TipoCliente == TipoCliente 
                        select new ClientePropiedadDocsEntity
                        {

                            ClienteId = p.ClienteId,
                            PropiedadId = p.PropiedadId,
                            TipoCliente = p.TipoCliente,
                            UrlDocument = p.UrlDocument,
                            Document = p.Document,
                            FechaDeCreacion = p.FechaDeCreacion,
                            FechaModificacion = p.FechaModificacion,
                            CreadoPor = p.CreadoPor,
                            ModificadoPor = p.ModificadoPor,
                            Eliminado = p.Eliminado,
                            ClientePropiedadDocsId = p.ClientePropiedadDocsId,
                            DocumentType = p.DocumentType
                        };

            return query.ToList();
        }



        public ClientePropiedadDocsEntity GetByClienteDocId(int DocId)
        {
            var query = from p in context.clientepropiedaddocs
                        where p.ClientePropiedadDocsId == DocId
                        select new ClientePropiedadDocsEntity
                        {
                            ClienteId = p.ClienteId,
                            PropiedadId = p.PropiedadId,
                            TipoCliente = p.TipoCliente,
                            UrlDocument = p.UrlDocument,
                            Document = p.Document,
                            FechaDeCreacion = p.FechaDeCreacion,
                            FechaModificacion = p.FechaModificacion,
                            CreadoPor = p.CreadoPor,
                            ModificadoPor = p.ModificadoPor,
                            Eliminado = p.Eliminado,
                            ClientePropiedadDocsId = p.ClientePropiedadDocsId,
                            DocumentType = p.DocumentType
                        };

            return query.FirstOrDefault();
        }


        public (ClientePropiedadDocsEntity, Resultado) Save(ClientePropiedadDocsEntity model)
        {
            try
            {
                using (var cn = new Kondominium_DAL.KEntities())
                {
                    var modlExist = cn.clientepropiedaddocs.Where(x => x.ClientePropiedadDocsId == model.ClientePropiedadDocsId).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.clientepropiedaddocs();

                    if (modlExist != null)
                    {
                        if (modlExist.Eliminado == true)
                            return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "Regstro ha sido marcado como eliminado, no se puede actualizar" });

                        modlNew = modlExist;
                    }


                    modlNew.ClienteId = model.ClienteId;
                    modlNew.PropiedadId = model.PropiedadId;
                    modlNew.TipoCliente = model.TipoCliente;
                    modlNew.UrlDocument = model.UrlDocument;
                    modlNew.Document = model.Document;
                    modlNew.DocumentType = model.DocumentType;

                    modlNew.Eliminado = model.Eliminado;

                    modlNew.FechaModificacion  = DateTime.Now;
                    modlNew.ModificadoPor = model.ModificadoPor;



                    if (modlExist == null)
                    {
                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;

                        cn.clientepropiedaddocs.Add(modlNew);
                    }
                    cn.SaveChanges();

                    model.ClientePropiedadDocsId = modlNew.ClientePropiedadDocsId;
                }

                return (GetByClienteDocId(model.ClientePropiedadDocsId), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {
                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "El registro no pudo ser guardado. \n" + ex.Message });

            }
        }

        public Resultado Delete(ClientePropiedadDocsEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.clientepropiedaddocs.Where( p => p.ClientePropiedadDocsId == model.ClientePropiedadDocsId).FirstOrDefault();

                    if (modlExist != null)
                    {
                        ContextP.clientepropiedaddocs.Remove(modlExist);
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
        public Resultado SetDelete(int ClienteId, int PropiedadId, string TipoCliente, string UserId)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {

                    var modlExist = ContextP.clientepropiedaddocs.Where(x => x.ClienteId == ClienteId && x.PropiedadId == PropiedadId && x.TipoCliente == TipoCliente).FirstOrDefault();
                    // var modlNew = new Kondominium_DAL.clientepropiedaddocs();


                    if (modlExist == null)
                        return (new Resultado { Codigo = CodigosMensaje.No_Existe, Mensaje = "Registro no Existe" });

                    modlExist.Eliminado = true;

                    modlExist.FechaModificacion = DateTime.Now;
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

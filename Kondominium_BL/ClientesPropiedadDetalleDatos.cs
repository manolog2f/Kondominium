using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_BL
{
    public class ClientesPropiedadDetalleDatos
    {
        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public List<ClientePropiedadDetalleEntity> GetAll(bool VerEliminado = false)
        {
            var query = from p in context.clientepropiedaddetalle
                        select new ClientePropiedadDetalleEntity
                        {
                            ClienteId = p.ClienteId,
                            PropiedadId = p.PropiedadId,
                            TipoCliente = p.TipoCliente,
                            FechaInicio = p.FechaInicio,
                            FechaFin = p.FechaFin,
                            Autorrenovable = p.Autorrenovable,
                            InquilinoResponsable = p.InquilinoResponsable,
                            Observacion = p.Observacion,
                            Parentesco = p.Parentesco,
                            FechaDeCreacion = (DateTime)p.FechaDeCreacion,
                            FechaDeModificacion = p.FechaDeModificacion,
                            CreadoPor = p.CreadoPor,
                            ModificadoPor = p.ModificadoPor
                           
                        };

            return query.ToList();
        }
        public ClientePropiedadDetalleEntity GetById(int ClienteId, int PropiedadId)
        {
            var query = from p in context.clientepropiedaddetalle
                        where p.ClienteId == ClienteId && p.PropiedadId == PropiedadId
                        select new ClientePropiedadDetalleEntity
                        {
                            ClienteId = p.ClienteId,
                            PropiedadId = p.PropiedadId,
                            TipoCliente = p.TipoCliente,
                            FechaInicio = p.FechaInicio,
                            FechaFin = p.FechaFin,
                            Autorrenovable = p.Autorrenovable,
                            InquilinoResponsable = p.InquilinoResponsable,
                            Observacion = p.Observacion,
                            Parentesco = p.Parentesco,
                            FechaDeCreacion = (DateTime)p.FechaDeCreacion,
                            FechaDeModificacion = p.FechaDeModificacion,
                            CreadoPor = p.CreadoPor,
                            ModificadoPor = p.ModificadoPor
                        };

            return query.FirstOrDefault();
        }

        public (ClientePropiedadDetalleEntity, Resultado) Save(ClientePropiedadDetalleEntity model)
        {
            try
            {
                using (var cn = new Kondominium_DAL.KEntities())
                {
                    var modlExist = cn.clientepropiedaddetalle.Where(x => x.ClienteId == model.ClienteId && x.PropiedadId == model.PropiedadId).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.clientepropiedaddetalle();

                    if (modlExist != null)
                    {
                        modlNew = modlExist;
                    }

                    modlNew.ClienteId = model.ClienteId;
                    modlNew.PropiedadId = model.PropiedadId;
                    modlNew.TipoCliente = model.TipoCliente;
                    modlNew.FechaInicio = model.FechaInicio;
                    modlNew.FechaFin = model.FechaFin;
                    modlNew.Autorrenovable = model.Autorrenovable;
                    modlNew.InquilinoResponsable = model.InquilinoResponsable;
                    modlNew.Observacion = model.Observacion;
                    modlNew.Parentesco = model.Parentesco;
                    modlNew.FechaDeModificacion = DateTime.Now;
                    modlNew.ModificadoPor = model.ModificadoPor;



                    if (modlExist == null)
                    {
                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;

                        cn.clientepropiedaddetalle.Add(modlNew);
                    }
                    cn.SaveChanges();
                }

                return (GetById(model.ClienteId, model.PropiedadId), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {
                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "El registro no pudo ser guardado. \n" + ex.Message });

            }
        }

        public Resultado Delete(ClientePropiedadDetalleEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.clientepropiedaddetalle.Where(x => x.ClienteId == model.ClienteId && x.PropiedadId == model.PropiedadId).FirstOrDefault();

                    if (modlExist != null)
                    {
                        ContextP.clientepropiedaddetalle.Remove(modlExist);
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

        //            var modlExist = ContextP.clientepropiedaddetalle.Where(x => x.CalleId == Id).FirstOrDefault();
        //            // var modlNew = new Kondominium_DAL.clientepropiedaddetalle();


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

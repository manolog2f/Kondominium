using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Kondominium_BL
{
    public class ClientesDatos
    {
        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public List<ClientesEntity> GetAll(bool VerEliminado = false)
        {
            var query = from c in context.clientes
                        where VerEliminado ? c.Eliminado == c.Eliminado : c.Eliminado == false
                        select new ClientesEntity
                        {
                            ClienteId = c.ClienteId,
                            Nombres = c.Nombres,
                            Apellidos = c.Apellidos,
                            Documento1 = c.Documento1,
                            Documento2 = c.Documento2,
                            Documento3 = c.Documento3,
                            Documento4 = c.Documento4,
                            Email = c.Email,
                            TelefonoMovil = c.TelefonoMovil,
                            TelefonoFijo = c.TelefonoFijo,
                            FechaDeCreacion = c.FechaDeCreacion,
                            FechaDeModificacion = c.FechaDeModificacion,
                            CreadoPor = c.CreadoPor,
                            ModificadoPor = c.ModificadoPor,
                            Eliminado = c.Eliminado,
                        };



            return query.ToList();

        }

        public ClientesEntity GetById(int Id)
        {
            var query = from c in context.clientes
                        where c.ClienteId == Id
                        select new ClientesEntity

                        {
                            ClienteId = c.ClienteId,
                            Nombres = c.Nombres,
                            Apellidos = c.Apellidos,
                            Documento1 = c.Documento1,
                            Documento2 = c.Documento2,
                            Documento3 = c.Documento3,
                            Documento4 = c.Documento4,
                            Email = c.Email,
                            TelefonoMovil = c.TelefonoMovil,
                            TelefonoFijo = c.TelefonoFijo,
                            FechaDeCreacion = c.FechaDeCreacion,
                            FechaDeModificacion = c.FechaDeModificacion,
                            CreadoPor = c.CreadoPor,
                            ModificadoPor = c.ModificadoPor,
                            Eliminado = c.Eliminado,
                        };
            return query.FirstOrDefault();
        }

        public DataTable DataTable()
        {

            var dTabla = new DataTable();

            using (var _context = new Kondominium_DAL.KEntities())
            {
                dTabla = ZoomTechUtils.ZMTDriveDataTable.ToDataTable(_context.clientes.ToList());
            }

            return dTabla;
        }

        public DataTable DataTable(int Id)
        {
            var dTabla = new DataTable();
            using (var _context = new Kondominium_DAL.KEntities())
            {
                dTabla = ZoomTechUtils.ZMTDriveDataTable.ToDataTable(_context.clientes.Where( x => x.ClienteId == Id ).ToList());
            }
            return dTabla;
        }

        public (ClientesEntity, Resultado) Save(ClientesEntity model)
        {
            try
            {
                using (var cn = new Kondominium_DAL.KEntities())
                {
                    var modlExist = cn.clientes.Where(x => x.ClienteId == model.ClienteId).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.clientes();

                    if (modlExist != null)
                    {
                        if (modlExist.Eliminado == true)
                            return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "Regstro ha sido marcado como eliminado, no se puede actualizar" });

                        modlNew = modlExist;
                    }

                    //modlNew.ClienteId = model.ClienteId;
                    modlNew.Nombres = model.Nombres;
                    modlNew.Apellidos = model.Apellidos;
                    modlNew.Documento1 = string.IsNullOrEmpty(model.Documento1) ? "" : model.Documento1;
                    modlNew.Documento2 = string.IsNullOrEmpty(model.Documento2) ? "" : model.Documento2;
                    modlNew.Documento3 = string.IsNullOrEmpty(model.Documento3) ? "" : model.Documento3;
                    modlNew.Documento4 = string.IsNullOrEmpty(model.Documento4) ? "" : model.Documento4;

                    modlNew.Email = string.IsNullOrEmpty(model.Email) ? "" : model.Email;

                    modlNew.TelefonoMovil = string.IsNullOrEmpty(model.TelefonoMovil) ? "" : model.TelefonoMovil;
                    modlNew.TelefonoFijo = string.IsNullOrEmpty(model.TelefonoFijo) ? "" : model.TelefonoFijo;
                    modlNew.FechaDeModificacion = DateTime.Now;

                    modlNew.ModificadoPor = model.ModificadoPor;
                    modlNew.Eliminado = model.Eliminado;

                    if (model.ClienteId == 0)
                    {
                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;

                        cn.clientes.Add(modlNew);
                    }
                    cn.SaveChanges();

                    model.ClienteId = modlNew.ClienteId;
                }

                return (GetById(model.ClienteId), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {

                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "El registro no pudo ser guardado." + ex.Message });
            }
        }

        public Resultado Delete(ClientesEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.clientes.Where(x => x.ClienteId == model.ClienteId).FirstOrDefault();

                    if (modlExist != null)
                    {
                        ContextP.clientes.Remove(modlExist);
                        ContextP.SaveChanges();

                        return new Resultado { Codigo = 0, Mensaje = "Exito, Registro eliminado permanentemente" };
                    }
                    else
                        return new Resultado { Codigo = 0, Mensaje = "Registro no encontrado" };
                }
            }
            catch (Exception ex)
            {

                return new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logró eliminar el registro \n" + ex.Message };
            }
        }

        public Resultado SetDelete(int Id, string UserId)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {

                    var modlExist = ContextP.clientes.Where(x => x.ClienteId == Id).FirstOrDefault();
                    // var modlNew = new Kondominium_DAL.clientes();


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

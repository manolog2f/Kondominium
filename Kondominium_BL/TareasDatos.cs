using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_BL
{
  public  class TareasDatos
    {
        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public List<TareasEntity> GetAll()
        {
            var query = from t in context.tareas
                        
                        select new TareasEntity
                        {
                            TareaId = t.TareaId,
                            Prioridad = t.Prioridad,
                            Titulo = t.Titulo,
                            Descripcion = t.Descripcion,
                            FechaDeEjecucion = t.FechaDeEjecucion,
                            Estatus = t.Estatus,
                            UsuarioAsignado = t.UsuarioAsignado,
                            FechaDeCreacion = (DateTime)t.FechaDeCreacion,
                            FechaDeModificacion = t.FechaDeModificacion,
                            CreadoPor = t.CreadoPor,
                            ModificadoPor = t.ModificadoPor
                        };

            return query.ToList();
        }
        public TareasEntity GetById(int Id)
        {
            var query = from t in context.tareas
                        where t.TareaId == Id
                        select new TareasEntity
                        {
                            TareaId = t.TareaId,
                            Prioridad = t.Prioridad,
                            Titulo = t.Titulo,
                            Descripcion = t.Descripcion,
                            FechaDeEjecucion = t.FechaDeEjecucion,
                            Estatus = t.Estatus,
                            UsuarioAsignado = t.UsuarioAsignado,
                            FechaDeCreacion = (DateTime)t.FechaDeCreacion,
                            FechaDeModificacion = t.FechaDeModificacion,
                            CreadoPor = t.CreadoPor,
                            ModificadoPor = t.ModificadoPor
                        };

            return query.FirstOrDefault();
        }
        public TareasEntity GetByUserId(string UserId)
        {
            var query = from t in context.tareas
                        where t.UsuarioAsignado == UserId
                        select new TareasEntity
                        {
                            TareaId = t.TareaId,
                            Prioridad = t.Prioridad,
                            Titulo = t.Titulo,
                            Descripcion = t.Descripcion,
                            FechaDeEjecucion = t.FechaDeEjecucion,
                            Estatus = t.Estatus,
                            UsuarioAsignado = t.UsuarioAsignado,
                            FechaDeCreacion = (DateTime)t.FechaDeCreacion,
                            FechaDeModificacion = t.FechaDeModificacion,
                            CreadoPor = t.CreadoPor,
                            ModificadoPor = t.ModificadoPor
                        };

            return query.FirstOrDefault();
        }

        public (TareasEntity, Resultado) Save(TareasEntity model)
        {
            try 
            {
                using (var cn = new Kondominium_DAL.KEntities())
                {
                    var modlExist = cn.tareas.Where(x => x.TareaId == model.TareaId).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.tareas();

                    if (modlExist != null)
                    modlNew = modlExist;

                    modlNew.TareaId = model.TareaId;
                    modlNew.Prioridad = model.Prioridad;
                    modlNew.Titulo = model.Titulo;
                    modlNew.FechaDeModificacion = DateTime.Now;
                    modlNew.ModificadoPor = model.ModificadoPor;
                    modlNew.Descripcion = model.Descripcion;
                    modlNew.FechaDeEjecucion = model.FechaDeEjecucion;
                    modlNew.Estatus = model.Estatus;
                    modlNew.UsuarioAsignado = model.UsuarioAsignado;
                    modlNew.FechaDeCreacion = (DateTime)model.FechaDeCreacion;
                    modlNew.FechaDeModificacion = model.FechaDeModificacion;
                    modlNew.CreadoPor = model.CreadoPor;
                    modlNew.ModificadoPor = model.ModificadoPor;



                    if (modlExist == null)
                    {
                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;

                        cn.tareas.Add(modlNew);
                    }
                    cn.SaveChanges();

                    model.TareaId = modlNew.TareaId;

                }

                return (GetById(model.TareaId), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {
                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "El registro no pudo ser guardado. \n" + ex.Message });

            }
        }

        public Resultado Delete(TareasEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.tareas.Where(x => x.TareaId == model.TareaId).FirstOrDefault();

                    if (modlExist != null)
                    {
                        ContextP.tareas.Remove(modlExist);
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
        public Resultado SetDelete(int Id, string UserId)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {

                    var modlExist = ContextP.tareas.Where(x => x.TareaId == Id).FirstOrDefault();
                    // var modlNew = new Kondominium_DAL.Calles();


                    if (modlExist == null)
                        return (new Resultado { Codigo = CodigosMensaje.No_Existe, Mensaje = "Registro no Existe" });

                    //modlExist.Eliminado = true;

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

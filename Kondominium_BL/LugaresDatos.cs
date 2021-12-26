using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_BL
{
    public class LugaresDatos
    {
        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public List<LugaresEntity> GetAll()
        {
            var query = from l in context.lugares
                        
                        select new LugaresEntity
                        {
                            
                            LugarId = l.LugarId,
                            Nombre = l.Nombre,
                            Descripcion = l.Descripcion,
                            FechaDeCreacion = (DateTime)l.FechaDeCreacion,
                            FechaDeModificacion = l.FechaDeModificacion,
                            CreadoPor = l.CreadoPor,
                            ModificadoPor = l.ModificadoPor
                        };

            return query.ToList();
        }
        public LugaresEntity GetById(int Id)
        {
            var query = from l in context.lugares
                        where l.LugarId == Id
                        select new LugaresEntity
                        {
                            LugarId = l.LugarId,
                            Nombre = l.Nombre,
                            Descripcion = l.Descripcion,
                            FechaDeCreacion = (DateTime)l.FechaDeCreacion,
                            FechaDeModificacion = l.FechaDeModificacion,
                            CreadoPor = l.CreadoPor,
                            ModificadoPor = l.ModificadoPor
                        };

            return query.FirstOrDefault();
        }


        public (LugaresEntity, Resultado) Save(LugaresEntity model)
        {
            try
            {
                using (var cn = new Kondominium_DAL.KEntities())
                {
                    var modlExist = cn.lugares.Where(x => x.LugarId == model.LugarId).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.lugares();

                    if (modlExist != null)
                        modlNew = modlExist;
                    

                    modlNew.LugarId = model.LugarId;
                    modlNew.Nombre = model.Nombre;
                    modlNew.Descripcion = model.Descripcion;
                    modlNew.FechaDeModificacion = DateTime.Now;
                    modlNew.ModificadoPor = model.ModificadoPor;



                    if (modlExist == null)
                    {
                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;

                        cn.lugares.Add(modlNew);
                    }
                    cn.SaveChanges();

                    model.LugarId = modlNew.LugarId;

                }

                return (GetById(model.LugarId), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {
                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "El registro no pudo ser guardado. \n" + ex.Message });

            }
        }

        public Resultado Delete(LugaresEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.lugares.Where(x => x.LugarId == model.LugarId).FirstOrDefault();

                    if (modlExist != null)
                    {
                        ContextP.lugares.Remove(modlExist);
                        ContextP.SaveChanges();
                        return new Resultado { Codigo = 0, Mensaje = "Exito, Registro eliminado permanentemente" };
                    }
                    else
                        return new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "Registro no encontrado" };
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

                    var modlExist = ContextP.lugares.Where(x => x.LugarId == Id).FirstOrDefault();
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

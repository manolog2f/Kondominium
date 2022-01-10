using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_BL
{
   public class ConfigCobrosMensualDatos
    {
        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public List<ConfigCobrosMensualEntity> GetAll(bool VerEliminado = false)
        {
            var query = context.configcobrosmensual.Select(x => new ConfigCobrosMensualEntity
            {
                CreadoPor = x.CreadoPor,
                FechaDeCreacion = x.FechaDeCreacion,
                FechaDeModificacion = x.FechaDeModificacion,
                DiaDeGeneracion = x.DiaDeGeneracion, 
                DiaVencimiento = x.DiaVencimiento, 
                IdConfig = x.IdConfig, 
                ModificadoPor = x.ModificadoPor
            });

            return query.ToList();
        }
        public ConfigCobrosMensualEntity GetById(int Id)
        {
            var query = context.configcobrosmensual.Where(x => x.IdConfig == Id).Select(x => new ConfigCobrosMensualEntity
            {
                CreadoPor = x.CreadoPor,
                FechaDeCreacion = x.FechaDeCreacion,
                FechaDeModificacion = x.FechaDeModificacion,
                DiaDeGeneracion = x.DiaDeGeneracion,
                DiaVencimiento = x.DiaVencimiento,
                IdConfig = x.IdConfig,
                ModificadoPor = x.ModificadoPor

            });

            return query.FirstOrDefault();
        }

        

        public (ConfigCobrosMensualEntity, Resultado) Save(ConfigCobrosMensualEntity model)
        {
            try
            {
                using (var cn = new Kondominium_DAL.KEntities())
                {
                    var modlExist = cn.configcobrosmensual.Where(x => x.IdConfig == model.IdConfig).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.configcobrosmensual();

                    if (modlExist != null)
                    {

                        modlNew = modlExist;
                    }
                    modlNew.DiaDeGeneracion = model.DiaDeGeneracion;
                    modlNew.DiaVencimiento = model.DiaVencimiento;
                    //-- modlNew.IdConfig = x.IdConfig,

                    modlNew.FechaDeModificacion = DateTime.Now;
                    modlNew.ModificadoPor = model.ModificadoPor;

                    if (modlExist == null)
                    {
                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;
                        cn.configcobrosmensual.Add(modlNew);
                    }
                    cn.SaveChanges();

                    model.IdConfig = modlNew.IdConfig;

                }

                return (GetById(model.IdConfig), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {
                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "El registro no pudo ser guardado. \n" + ex.Message });

            }
        }

        public Resultado Delete(ConfigCobrosMensualEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.configcobrosmensual.Where(x => x.IdConfig == model.IdConfig).FirstOrDefault();

                    if (modlExist != null)
                    {
                        ContextP.configcobrosmensual.Remove(modlExist);
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

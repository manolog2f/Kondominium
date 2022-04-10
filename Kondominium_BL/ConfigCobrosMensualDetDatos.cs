using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kondominium_BL
{
    public class ConfigCobrosMensualDetDatos
    {
        private Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();

        public List<ConfigCobrosMensualDetEntity> GetAll(bool VerEliminado = false)
        {
            var query = context.configcobrosmensauldet.Select(x => new ConfigCobrosMensualDetEntity
            {
                CreadoPor = x.CreadoPor,
                FechaDeCreacion = x.FechaDeCreacion,
                FechaDeModificacion = x.FechaDeModificacion,
                IdConfig = x.IdConfig,
                ModificadoPor = x.ModificadoPor,
                Monto = x.Monto,
                ProductoId = x.ProductoId,
                ProductoDescripcion = x.productos.Descripcion,
                MTamañoV2 = x.MTamañoV2,
                IdDetalleConf = x.IdDetalleConf
            });

            return query.ToList();
        }

        public ConfigCobrosMensualDetEntity GetById(int Id)
        {
            var query = context.configcobrosmensauldet.Where(x => x.IdDetalleConf == Id).Select(x => new ConfigCobrosMensualDetEntity
            {
                CreadoPor = x.CreadoPor,
                FechaDeCreacion = x.FechaDeCreacion,
                FechaDeModificacion = x.FechaDeModificacion,
                IdConfig = x.IdConfig,
                ModificadoPor = x.ModificadoPor,
                Monto = x.Monto,
                ProductoId = x.ProductoId,
                ProductoDescripcion = x.productos.Descripcion,
                MTamañoV2 = x.MTamañoV2,
                IdDetalleConf = x.IdDetalleConf
            });

            return query.FirstOrDefault();
        }

        public List<ConfigCobrosMensualDetEntity> GetByConfigId(int Id)
        {
            var query = context.configcobrosmensauldet.Where(x => x.IdConfig == Id).Select(x => new ConfigCobrosMensualDetEntity
            {
                CreadoPor = x.CreadoPor,
                FechaDeCreacion = x.FechaDeCreacion,
                FechaDeModificacion = x.FechaDeModificacion,
                IdConfig = x.IdConfig,
                ModificadoPor = x.ModificadoPor,
                Monto = x.Monto,
                ProductoId = x.ProductoId,
                ProductoDescripcion = x.productos.Descripcion,
                MTamañoV2 = x.MTamañoV2,
                IdDetalleConf = x.IdDetalleConf
            });

            return query.ToList();
        }

        public (ConfigCobrosMensualDetEntity, Resultado) Save(ConfigCobrosMensualDetEntity model)
        {
            try
            {
                using (var cn = new Kondominium_DAL.KEntities())
                {
                    var modlExist = cn.configcobrosmensauldet.Where(x => x.IdDetalleConf == model.IdDetalleConf).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.configcobrosmensauldet();

                    if (modlExist != null)
                    {
                        modlNew = modlExist;
                    }
                    modlNew.Monto = model.Monto;
                    modlNew.ProductoId = model.ProductoId;
                    modlNew.IdConfig = model.IdConfig;

                    modlNew.FechaDeModificacion = DateTime.Now;
                    modlNew.ModificadoPor = model.ModificadoPor;

                    modlNew.MTamañoV2 = model.MTamañoV2;

                    if (modlExist == null)
                    {
                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;
                        cn.configcobrosmensauldet.Add(modlNew);
                    }
                    cn.SaveChanges();

                    model.IdDetalleConf = modlNew.IdDetalleConf;
                }

                return (GetById(model.IdDetalleConf), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {
                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "El registro no pudo ser guardado. \n" + ex.Message });
            }
        }

        public Resultado Delete(int IdDetalleConf)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.configcobrosmensauldet.Where(x => x.IdDetalleConf == IdDetalleConf).FirstOrDefault();

                    if (modlExist != null)
                    {
                        ContextP.configcobrosmensauldet.Remove(modlExist);
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
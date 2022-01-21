using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kondominium_BL
{
    public class CuentasGeneradasDetalleBDatos
    {
        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public List<CuentasGeneradasDetalleBEntity> GetAll(bool VerEliminado = false)
        {
            var query = context.cuentasgeneradasdetalleb.Select(x => new CuentasGeneradasDetalleBEntity
            {
                ClienteId = x.ClienteId,
                PeriodoGenerado = x.PeriodoGenerado,
                PropiedadId = x.PropiedadId,
                Monto = x.Monto,
                ProductoId = x.ProductoId

            });

            return query.ToList();
        }
        public CuentasGeneradasDetalleBEntity GetById(int PropiedadId, int ClienteId, string PeriodoGenerado, int ProductoId)
        {
            var query = context.cuentasgeneradasdetalleb.Where(x => x.PeriodoGenerado == PeriodoGenerado && x.PropiedadId == PropiedadId && x.ClienteId == ClienteId && x.ProductoId == ProductoId).Select(x => new CuentasGeneradasDetalleBEntity
            {
                ClienteId = x.ClienteId,
                PeriodoGenerado = x.PeriodoGenerado,
                PropiedadId = x.PropiedadId,
                Monto = x.Monto,
                ProductoId = x.ProductoId

            });

            return query.FirstOrDefault();
        }

        public (CuentasGeneradasDetalleBEntity, Resultado) Save(CuentasGeneradasDetalleBEntity model)
        {
            try
            {
                using (var cn = new Kondominium_DAL.KEntities())
                {
                    var modlExist = cn.cuentasgeneradasdetalleb.Where(x => x.PeriodoGenerado == model.PeriodoGenerado && x.PropiedadId == model.PropiedadId && x.ClienteId == model.ClienteId && x.ProductoId == model.ProductoId).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.cuentasgeneradasdetalleb();

                    if (modlExist != null)
                    {

                        modlNew = modlExist;
                    }
                    modlNew.ProductoId = model.ProductoId;
                    modlNew.ClienteId = model.ClienteId;
                    modlNew.PeriodoGenerado = model.PeriodoGenerado;
                    modlNew.PropiedadId = model.PropiedadId;
                    modlNew.Monto = model.Monto;

                    if (modlExist == null)
                    {
                        cn.cuentasgeneradasdetalleb.Add(modlNew);
                    }
                    cn.SaveChanges();

                }

                return (GetById(model.PropiedadId, model.ClienteId, model.PeriodoGenerado, model.ProductoId), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {
                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "El registro no pudo ser guardado. \n" + ex.Message });
            }
        }

        public Resultado Delete(CuentasGeneradasDetalleBEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.cuentasgeneradasdetalleb.Where(x => x.PeriodoGenerado == model.PeriodoGenerado && x.PropiedadId == model.PropiedadId && x.ClienteId == model.ClienteId).FirstOrDefault();

                    if (modlExist != null)
                    {
                        ContextP.cuentasgeneradasdetalleb.Remove(modlExist);
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

using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kondominium_BL
{
    public class CuentasGeneradasDetalleDatos
    {
        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public List<CuentasGeneradasDetalleEntity> GetAll(bool VerEliminado = false)
        {
            var query = context.cuentasgeneradasdetalle.Select(x => new CuentasGeneradasDetalleEntity
            {
                CreadoPor = x.CreadoPor,
                FechaDeCreacion = x.FechaDeCreacion,
                FechaDeModificacion = x.FechaDeModificacion,
                ModificadoPor = x.ModificadoPor,
                ClienteId = x.ClienteId,
                Fecha = x.Fecha,
                FechaDeVencimiento = x.FechaDeVencimiento,
                PeriodoGenerado = x.PeriodoGenerado,
                PropiedadId = x.PropiedadId,
                Total = x.Total

            });

            return query.ToList();
        }
        public CuentasGeneradasDetalleEntity GetById(int PropiedadId, int ClienteId, string PeriodoGenerado)
        {
            var query = context.cuentasgeneradasdetalle.Where(x => x.PeriodoGenerado == PeriodoGenerado && x.PropiedadId == PropiedadId && x.ClienteId == ClienteId).Select(x => new CuentasGeneradasDetalleEntity
            {
                CreadoPor = x.CreadoPor,
                FechaDeCreacion = x.FechaDeCreacion,
                FechaDeModificacion = x.FechaDeModificacion,
                ModificadoPor = x.ModificadoPor,
                ClienteId = x.ClienteId,
                Fecha = x.Fecha,
                FechaDeVencimiento = x.FechaDeVencimiento,
                PeriodoGenerado = x.PeriodoGenerado,
                PropiedadId = x.PropiedadId,
                Total = x.Total

            });

            return query.FirstOrDefault();
        }

        public (CuentasGeneradasDetalleEntity, Resultado) Save(CuentasGeneradasDetalleEntity model)
        {
            try
            {
                using (var cn = new Kondominium_DAL.KEntities())
                {
                    var modlExist = cn.cuentasgeneradasdetalle.Where(x => x.PeriodoGenerado == model.PeriodoGenerado && x.PropiedadId == model.PropiedadId && x.ClienteId == model.ClienteId).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.cuentasgeneradasdetalle();

                    if (modlExist != null)
                    {

                        modlNew = modlExist;
                    }




                    modlNew.ClienteId = model.ClienteId;
                    modlNew.Fecha = model.Fecha;
                    modlNew.FechaDeVencimiento = model.FechaDeVencimiento;
                    modlNew.PeriodoGenerado = model.PeriodoGenerado;
                    modlNew.PropiedadId = model.PropiedadId;
                    modlNew.Total = model.Total;

                    modlNew.FechaDeModificacion = DateTime.Now;
                    modlNew.ModificadoPor = model.ModificadoPor;

                    if (modlExist == null)
                    {
                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;

                        cn.cuentasgeneradasdetalle.Add(modlNew);
                    }
                    cn.SaveChanges();

                }

                return (GetById(model.PropiedadId, model.ClienteId, model.PeriodoGenerado), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {
                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "El registro no pudo ser guardado. \n" + ex.Message });

            }
        }

        public Resultado Delete(CuentasGeneradasDetalleEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.cuentasgeneradasdetalle.Where(x => x.PeriodoGenerado == model.PeriodoGenerado && x.PropiedadId == model.PropiedadId && x.ClienteId == model.ClienteId).FirstOrDefault();

                    if (modlExist != null)
                    {
                        ContextP.cuentasgeneradasdetalle.Remove(modlExist);
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

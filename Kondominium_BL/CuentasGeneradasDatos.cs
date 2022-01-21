using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kondominium_BL
{
    public class CuentasGeneradasDatos
    {
        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public List<CuentasGeneradasEntity> GetAll(bool VerEliminado = false)
        {
            var query = context.cuentasgeneradas.Select(x => new CuentasGeneradasEntity
            {
                CreadoPor = x.CreadoPor,
                FechaDeCreacion = x.FechaDeCreacion,
                FechaDeModificacion = x.FechaDeModificacion,
                FechaDeGeneracion = x.FechaDeGeneracion,
                FechaDeVencimiento = x.FechaDeVencimiento,
                Justificacion = x.Justificacion,
                ModificadoPo = x.ModificadoPo,
                PeriodoGenerado = x.PeriodoGenerado
            });

            return query.ToList();
        }
        public CuentasGeneradasEntity GetById(string Id)
        {
            var query = context.cuentasgeneradas.Where(x => x.PeriodoGenerado == Id).Select(x => new CuentasGeneradasEntity
            {
                CreadoPor = x.CreadoPor,
                FechaDeCreacion = x.FechaDeCreacion,
                FechaDeModificacion = x.FechaDeModificacion,
                FechaDeGeneracion = x.FechaDeGeneracion,
                FechaDeVencimiento = x.FechaDeVencimiento,
                Justificacion = x.Justificacion,
                ModificadoPo = x.ModificadoPo,
                PeriodoGenerado = x.PeriodoGenerado

            });

            return query.FirstOrDefault();
        }

        /// <summary>
        /// True Ya fue generada
        /// False Aun no fue generada se puede generar
        /// </summary>
        /// <param name="Id">Periodo a generar</param>
        /// <returns>bool</returns>
        public bool ValidaGeneradas(string Id)
        {

            var query = context.cuentasgeneradas.Where(x => x.PeriodoGenerado == Id).FirstOrDefault();

            if (query != null)
            {
                var query2 = context.cuentasgeneradasdetalle.Where(x => x.PeriodoGenerado == Id).Count();

                if (query2 > 0)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public (CuentasGeneradasEntity, Resultado) Save(CuentasGeneradasEntity model)
        {
            try
            {
                using (var cn = new Kondominium_DAL.KEntities())
                {
                    var modlExist = cn.cuentasgeneradas.Where(x => x.PeriodoGenerado == model.PeriodoGenerado).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.cuentasgeneradas();

                    if (modlExist != null)
                    {

                        modlNew = modlExist;
                    }
                    modlNew.FechaDeGeneracion = model.FechaDeGeneracion;
                    modlNew.FechaDeVencimiento = model.FechaDeVencimiento;
                    modlNew.Justificacion = model.Justificacion;
                    modlNew.PeriodoGenerado = model.PeriodoGenerado;

                    modlNew.FechaDeModificacion = DateTime.Now;
                    modlNew.ModificadoPo = model.ModificadoPo;

                    if (modlExist == null)
                    {
                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;
                        cn.cuentasgeneradas.Add(modlNew);
                    }
                    cn.SaveChanges();

                    model.PeriodoGenerado = modlNew.PeriodoGenerado;

                }

                return (GetById(model.PeriodoGenerado), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {
                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "El registro no pudo ser guardado. \n" + ex.Message });

            }
        }

        public Resultado Delete(CuentasGeneradasEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.cuentasgeneradas.Where(x => x.PeriodoGenerado == model.PeriodoGenerado).FirstOrDefault();

                    if (modlExist != null)
                    {
                        ContextP.cuentasgeneradas.Remove(modlExist);
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

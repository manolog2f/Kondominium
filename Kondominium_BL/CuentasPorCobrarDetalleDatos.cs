using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_BL
{
    class CuentasPorCobrarDetalleDatos
    {
        Kondominium_DAL.KEntities contex = new Kondominium_DAL.KEntities();

        public List<CuentasPorCobrarDetalleEntity> GetAll()
        {
            var query = from cd in contex.cuentasporcobrardetalle
                        select new CuentasPorCobrarDetalleEntity
                        {
                            VaucherNumber = cd.VaucherNumber,
                            DetalleId = cd.DetalleId,
                            ProductoId = cd.ProductoId,
                            Descripcion = cd.Descripcion,
                            Monto = cd.Monto,
                            FechaDeCreacion = cd.FechaDeCreacion,
                            FechaDeModificacion = cd.FechaDeModificacion,
                            CreadoPor = cd.CreadoPor,
                            ModificadoPor = cd.ModificadoPor,
                            Eliminado = cd.Eliminado,
                        };

            return query.ToList();
        }

        public CuentasPorCobrarDetalleEntity GetById(string Id)
        {
            var query = from cd in contex.cuentasporcobrardetalle
                        where cd.VaucherNumber == Id
                        select new CuentasPorCobrarDetalleEntity
                        {
                            VaucherNumber = cd.VaucherNumber,
                            DetalleId = cd.DetalleId,
                            ProductoId = cd.ProductoId,
                            Descripcion = cd.Descripcion,
                            Monto = cd.Monto,
                            FechaDeCreacion = cd.FechaDeCreacion,
                            FechaDeModificacion = cd.FechaDeModificacion,
                            CreadoPor = cd.CreadoPor,
                            ModificadoPor = cd.ModificadoPor,
                            Eliminado = cd.Eliminado,
                        };

            return query.FirstOrDefault();
        }

        public (CuentasPorCobrarDetalleEntity, Resultado) Save(CuentasPorCobrarDetalleEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.cuentasporcobrardetalle.Where(x => x.VaucherNumber == model.VaucherNumber).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.cuentasporcobrardetalle();


                    if (modlExist != null)
                    {
                        if (modlExist.Eliminado == true)
                            return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "Regstro ha sido marcado como eliminado, no se puede actualizar" });

                        modlNew = modlExist;
                    }


                    modlNew.VaucherNumber = model.VaucherNumber;
                    modlNew.DetalleId = model.DetalleId;
                    modlNew.ProductoId = model.ProductoId;
                    modlNew.Descripcion = model.Descripcion;
                    modlNew.Monto = model.Monto;
                   
                    modlNew.FechaDeModificacion = model.FechaDeModificacion;
                    modlNew.ModificadoPor = model.ModificadoPor;
                    modlNew.Eliminado = model.Eliminado;

                    if (string.IsNullOrEmpty(modlNew.VaucherNumber))
                    {
                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;

                        ContextP.cuentasporcobrardetalle.Add(modlNew);
                    }
                    ContextP.SaveChanges();

                    model.VaucherNumber = modlNew.VaucherNumber;
                }

                return (GetById(model.VaucherNumber), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {

                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logro almacenar el Registro \n" + ex.Message });
            }

        }
        public Resultado Delete(CuentasPorCobrarDetalleEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.cuentasporcobrardetalle.Where(x => x.VaucherNumber == model.VaucherNumber).FirstOrDefault();

                    if (modlExist != null)
                    {
                        ContextP.cuentasporcobrardetalle.Remove(modlExist);
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
        public Resultado SetDelete(string Id, string UserId)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {

                    var modlExist = ContextP.cuentasporcobrardetalle.Where(x => x.VaucherNumber == Id).FirstOrDefault();
                    // var modlNew = new Kondominium_DAL.cuentasporcobrardetalle();


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

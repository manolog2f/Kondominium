using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kondominium_BL
{
    public class CuentasPorCobrarDetalleDatos
    {
        Kondominium_DAL.KEntities contex = new Kondominium_DAL.KEntities();

        public List<CuentasPorCobrarDetalleEntity> GetAll(bool VerEliminado = false)
        {
            var query = from cd in contex.cuentasporcobrardetalle
                        where VerEliminado ? cd.Eliminado == cd.Eliminado : cd.Eliminado == false
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

        public List<CuentasPorCobrarDetalleEntity> GetByVaucher(string Id)
        {
            var query = from cd in contex.cuentasporcobrardetalle
                        where cd.VaucherNumber == Id && cd.Eliminado != true
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

        public CuentasPorCobrarDetalleEntity GetByDetalleId(int DetalleId)
        {
            var query = from cd in contex.cuentasporcobrardetalle
                        where cd.DetalleId == DetalleId
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
                    var modlExist = ContextP.cuentasporcobrardetalle.Where(x => x.VaucherNumber == model.VaucherNumber && x.DetalleId == model.DetalleId).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.cuentasporcobrardetalle();


                    if (modlExist != null)
                    {
                        if (modlExist.Eliminado == true)
                            return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "Regstro ha sido marcado como eliminado, no se puede actualizar" });

                        modlNew = modlExist;
                    }


                    modlNew.VaucherNumber = model.VaucherNumber;
                    //modlNew.DetalleId = model.DetalleId;
                    modlNew.ProductoId = model.ProductoId;
                    modlNew.Descripcion = new ProductosDatos().GetById(model.ProductoId).Descripcion;
                    modlNew.Monto = model.Monto;

                    modlNew.FechaDeModificacion = DateTime.Now;
                    modlNew.ModificadoPor = model.ModificadoPor;
                    modlNew.Eliminado = model.Eliminado;

                    if (modlNew.DetalleId == 0)
                    {
                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;

                        ContextP.cuentasporcobrardetalle.Add(modlNew);
                    }
                    ContextP.SaveChanges();

                    model.DetalleId = modlNew.DetalleId;
                }

                UpdateTotalHeader(model.VaucherNumber);
                return (GetByDetalleId(model.DetalleId), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {

                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logro almacenar el Registro \n" + ex.Message });
            }

        }

        public void UpdateTotalHeader(string VaucherNumber)
        {
            var det = ((decimal)contex.cuentasporcobrardetalle.Where(x => x.VaucherNumber == VaucherNumber && x.Eliminado != true).Sum(x => x.Monto));
            using (var ContextP = new Kondominium_DAL.KEntities())
            {
                var modlExist = ContextP.cuentasporcobrar.Where(x => x.VaucherNumber == VaucherNumber).FirstOrDefault();

                if (modlExist != null)
                {
                    modlExist.Total = det;
                    ContextP.SaveChanges();
                }
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
        public Resultado SetDelete(int Id, string UserId)
        {
            try
            {
                string Vaucher = "";
                using (var ContextP = new Kondominium_DAL.KEntities())
                {

                    var modlExist = ContextP.cuentasporcobrardetalle.Where(x => x.DetalleId == Id).FirstOrDefault();

                    if (modlExist == null)
                        return (new Resultado { Codigo = CodigosMensaje.No_Existe, Mensaje = "Registro no Existe" });

                    modlExist.Eliminado = true;

                    modlExist.FechaDeModificacion = DateTime.Now;
                    modlExist.ModificadoPor = UserId;

                    Vaucher = modlExist.VaucherNumber;
                    ContextP.SaveChanges();
                }

                UpdateTotalHeader(Vaucher);
                return (new Resultado { Codigo = 0, Mensaje = "Registro eliminado con exito" });
            }
            catch (Exception ex)
            {

                return (new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logro Eliminar el Registro \n" + ex.Message });
            }

        }

    }
}

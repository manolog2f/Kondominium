using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kondominium_BL
{
    public class ProductosDatos
    {
        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public List<ProductosEntity> GetAll(bool VerEliminado = false)
        {
            var query = from prop in context.productos
                        where VerEliminado ? prop.Eliminado == prop.Eliminado : prop.Eliminado == false
                        select new ProductosEntity
                        {
                            Productoid = prop.Productoid,
                            Descripcion = prop.Descripcion,
                            FechaDeCreacion = prop.FechaDeCreacion,
                            FechaDeModificacion = prop.FechaDeModificacion,
                            CreadoPor = prop.CreadoPor,
                            ModificadoPor = prop.ModificadoPor,
                            Eliminado = prop.Eliminado,
                        };

            return query.ToList();
        }

        public ProductosEntity GetById(int Id)
        {
            var query = from prop in context.productos
                        where prop.Productoid == Id
                        select new ProductosEntity
                        {
                            Productoid = prop.Productoid,
                            Descripcion = prop.Descripcion,
                            FechaDeCreacion = prop.FechaDeCreacion,
                            FechaDeModificacion = prop.FechaDeModificacion,
                            CreadoPor = prop.CreadoPor,
                            ModificadoPor = prop.ModificadoPor,
                            Eliminado = prop.Eliminado,
                        };
            return query.FirstOrDefault();
        }

        public (ProductosEntity, Resultado) Save(ProductosEntity model)
        {
            try
            {
                using (var cn = new Kondominium_DAL.KEntities())
                {
                    var modlExist = cn.productos.Where(x => x.Productoid == model.Productoid).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.productos();

                    if (modlExist != null)
                    {
                        if (modlExist.Eliminado == true)
                            return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "Regstro ha sido marcado como eliminado, no se puede actualizar" });

                        modlNew = modlExist;
                    }

                    //modlNew.Productoid = model.Productoid;
                    modlNew.Descripcion = model.Descripcion;

                    modlNew.FechaDeModificacion = DateTime.Now;

                    modlNew.ModificadoPor = model.ModificadoPor;
                    modlNew.Eliminado = model.Eliminado;

                    if (modlExist == null)
                    {
                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;

                        cn.productos.Add(modlNew);
                    }
                    cn.SaveChanges();

                    model.Productoid = modlNew.Productoid;
                }

                return (GetById(model.Productoid), new Resultado { Codigo = 0, Mensaje = "Exito" });

            }
            catch (Exception ex)
            {

                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logro almacenar el Registro \n" + ex.Message });
            }
        }

        public Resultado Delete(ProductosEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.productos.Where(x => x.Productoid == model.Productoid).FirstOrDefault();

                    if (modlExist != null)
                    {
                        ContextP.productos.Remove(modlExist);
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

                    var modlExist = ContextP.productos.Where(x => x.Productoid == Id).FirstOrDefault();
                    // var modlNew = new Kondominium_DAL.productos();


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

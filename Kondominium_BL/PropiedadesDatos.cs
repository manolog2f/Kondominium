﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kondominium_Entities;

namespace Kondominium_BL
{
    public class PropiedadesDatos
    {
        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public List<PropiedadesEntity> GetAll()
        {
            var query = from pr in context.propiedades
                        join ar in context.aranceles on pr.ArancelId equals ar.ArancelId
                        join pl in context.poligonos on pr.PoligonoId equals pl.PoligonoId
                        select new PropiedadesEntity
                        {
                            PropiedadId = pr.PropiedadId,
                            TipoDePropiedad = pr.TipoDePropiedad,
                            Descripcion = pr.Descripcion,
                            Casa = pr.Casa,
                            PoligonoId= pr.PoligonoId,
                            ArancelId = pr.ArancelId,
                            FechaDeCreacion = pr.FechaDeCreacion,
                            FechaDeModificacion = pr.FechaDeModificacion,
                            CreadoPor = pr.CreadoPor,
                            ModificadoPor = pr.ModificadoPor,
                            Eliminado = pr.Eliminado,

                            TipoDePropiedadDesc = ((TipodePropiedades) pr.TipoDePropiedad).ToString(),

                            ArancelDescripcion = ar.Descripcion,
                            PoligonoDescripcion = pl.PoligonoDescripcion

                        };

            return query.ToList();
        }

        public PropiedadesEntity GetById(int Id)
        {
            var query = from pr in context.propiedades
                        where pr.PropiedadId == Id
                        select new PropiedadesEntity
                        {
                            PropiedadId = pr.PropiedadId,
                            TipoDePropiedad = pr.TipoDePropiedad,
                            Descripcion = pr.Descripcion,
                            Casa = pr.Casa,
                            PoligonoId = pr.PoligonoId,
                            ArancelId = pr.ArancelId,
                            FechaDeCreacion = pr.FechaDeCreacion,
                            FechaDeModificacion = pr.FechaDeModificacion,
                            CreadoPor = pr.CreadoPor,
                            ModificadoPor = pr.ModificadoPor,
                            Eliminado = pr.Eliminado,
                        };

            return query.FirstOrDefault();
        }
        public (PropiedadesEntity, Resultado) Save(PropiedadesEntity model)
        {
            try
            {
                using (var cn = new Kondominium_DAL.KEntities())
                {
                    var modlExist = cn.propiedades.Where(x => x.PropiedadId == model.PropiedadId).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.propiedades();

                    if (modlExist != null)
                        if (modlExist.Eliminado == true)
                            return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "Regstro ha sido marcado como eliminado, no se puede actualizar" });

                    modlNew = modlExist;

                    modlNew.PropiedadId = model.PropiedadId;
                    modlNew.TipoDePropiedad = model.TipoDePropiedad;
                    modlNew.Descripcion = model.Descripcion;
                    modlNew.Casa = model.Casa;
                    modlNew.PoligonoId = model.PoligonoId;
                    modlNew.ArancelId = model.ArancelId;
                    
                    modlNew.FechaDeModificacion = model.FechaDeModificacion;
                    
                    modlNew.ModificadoPor = model.ModificadoPor;
                    modlNew.Eliminado = model.Eliminado;


                    if (modlExist != null)
                    {
                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;

                        cn.propiedades.Add(modlNew);
                    }
                    cn.SaveChanges();

                    model.PropiedadId = modlNew.PropiedadId;
                }

                return (GetById(model.PropiedadId), new Resultado { Codigo = 0, Mensaje = "Exito" });

            }
            catch (Exception ex)
            {

                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logro almacenar el Registro \n" + ex.Message });
            }
        }

        public Resultado Delete(PropiedadesEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.propiedades.Where(x => x.PropiedadId == model.PropiedadId).FirstOrDefault();

                    if (modlExist != null)
                    {
                        ContextP.propiedades.Remove(modlExist);
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

                    var modlExist = ContextP.propiedades.Where(x => x.PropiedadId == Id).FirstOrDefault();
                    // var modlNew = new Kondominium_DAL.propiedades();


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

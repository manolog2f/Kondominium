using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kondominium_BL
{
    public class PoligonosDatos
    {
        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public List<PoligonosEntity> GetAll()
        {
            var query = from p in context.poligonos
                        select new PoligonosEntity 
                        {
                          PoligonoId = p.PoligonoId,
                          Descripcion = p.PoligonoDescripcion,
                          FechaDeCreacion = (DateTime)p.FechaDeCreacion,
                          FechaDeModificacion = p.FechaDeModificacion,
                          CreadoPor = p.CreadoPor,
                          ModificadoPor = p.ModificadoPor,
                          Eliminado = p.Eliminado,
                        };

            return query.ToList();
        }
        public PoligonosEntity GetById(string Id)
        {
            var query = from p in context.poligonos
                        where p.PoligonoId == Id
                        select new PoligonosEntity
                        {
                            PoligonoId = p.PoligonoId,
                            Descripcion = p.PoligonoDescripcion,
                            FechaDeCreacion = (DateTime)p.FechaDeCreacion,
                            FechaDeModificacion = p.FechaDeModificacion,
                            CreadoPor = p.CreadoPor,
                            ModificadoPor = p.ModificadoPor,
                            Eliminado = p.Eliminado,
                        };

            return query.FirstOrDefault();
        }
       
        public (PoligonosEntity, Resultado) Save(PoligonosEntity model)
        {
            try
            {
                using (var cn = new Kondominium_DAL.KEntities())
                {
                    var modlExist = cn.poligonos.Where(x => x.PoligonoId == model.PoligonoId).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.poligonos();

                    if (modlExist != null)
                        modlNew = modlExist;


                    //  modlNew.PoligonoId = model.PoligonoId;
                    modlNew.PoligonoDescripcion = model.Descripcion;
                    modlNew.Eliminado = model.Eliminado;
                    modlNew.FechaDeModificacion = DateTime.Now;
                    modlNew.CreadoPor = model.CreadoPor;
                    modlNew.FechaDeCreacion = DateTime.Now;
                    modlNew.ModificadoPor = model.ModificadoPor;



                    if ( string.IsNullOrEmpty( modlNew.PoligonoId ))
                    {
                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;

                        cn.poligonos.Add(modlNew);
                    }
                    cn.SaveChanges();

                    model.PoligonoId = modlNew.PoligonoId;

                }

                return (GetById(model.PoligonoId), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {
                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "El registro no se guardó con éxito \n" + ex.Message });

            }
        }

        public Resultado Delete(PoligonosEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    var modlExist = ContextP.poligonos.Where(x => x.PoligonoId == model.PoligonoId).FirstOrDefault();

                    if (modlExist != null)
                    {
                        ContextP.poligonos.Remove(modlExist);
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

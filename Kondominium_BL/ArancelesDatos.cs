using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kondominium_BL
{
   public class ArancelesDatos
    {
        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public List<ArancelesEntity> GetAll()
        {
            var query = from a in context.aranceles
                        select new ArancelesEntity
                        {
                            Activo = a.Activo,
                            ArancelId = a.ArancelId,
                            CreadoPor = a.CreadoPor,
                            Descripcion = a.Descripcion,
                            Eliminado = a.Eliminado,
                            FechaDeCreacion = a.FechaDeCreacion,
                            FechaDeModificacion = a.FechaDeModificacion,
                            ModificadoPor = a.ModificadoPor,
                            Monto = a.Monto,
                        };

            return query.ToList();
        }
        public ArancelesEntity GetById(int Id)
        {
            var query = from a in context.aranceles
                        where a.ArancelId == Id
                        select new ArancelesEntity
                        {
                            Activo = a.Activo,
                            ArancelId = a.ArancelId,
                            CreadoPor = a.CreadoPor,
                            Descripcion = a.Descripcion,
                            Eliminado = a.Eliminado,
                            FechaDeCreacion = a.FechaDeCreacion,
                            FechaDeModificacion = a.FechaDeModificacion,
                            ModificadoPor = a.ModificadoPor,
                            Monto = a.Monto,
                        };

            return query.FirstOrDefault();
        }
        public (ArancelesEntity, Resultado) Save(ArancelesEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    /// Lambda
                    var modlExist = ContextP.aranceles.Where(x => x.ArancelId == model.ArancelId).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.aranceles();

                    // Si trae null sigunifica que no existe el registro
                    // Si B
                    if (modlExist != null)
                        modlNew = modlExist;

                    
                    modlNew.Activo = model.Activo;
                    // modlNew.ArancelId = model.ArancelId;                   
                    modlNew.Descripcion = model.Descripcion;
                    modlNew.Eliminado = model.Eliminado;
                    modlNew.Monto = model.Monto;
                    modlNew.FechaDeModificacion = DateTime.Now;
                    modlNew.ModificadoPor = model.ModificadoPor;

                    if (modlNew.ArancelId == 0)
                    {
                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;

                        ContextP.aranceles.Add(modlNew);
                    }
                    ContextP.SaveChanges();

                    model.ArancelId = modlNew.ArancelId;
                }

                return (GetById(model.ArancelId), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {

                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logro almacenar el Registro \n" + ex.Message  });
            }

        }
        public  Resultado Delete(ArancelesEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {
                    /// Lambda
                    var modlExist = ContextP.aranceles.Where(x => x.ArancelId == model.ArancelId).FirstOrDefault();

                    /// Valor existe se puede eliminar
                    if (modlExist != null)
                    {
                        ContextP.aranceles.Remove(modlExist);
                        ContextP.SaveChanges();
                        return new Resultado { Codigo = 0, Mensaje = "Exito Resgistro Eliminado Permanetemente" };
                    }
                    else  /// Valor no existe no se puede eliminar
                        return  new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "Registro no encontrado" };
                }

            }
            catch (Exception ex)
            {

                return new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logro eliminar el Registro \n" + ex.Message };
            }
        }
    }
}

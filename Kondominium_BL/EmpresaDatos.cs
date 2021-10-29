using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_BL
{
    public class EmpresaDatos
    {
        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public List<EmpresaEntity> GetAll()
        {
            var query = from e in context.empresa
                        select new EmpresaEntity
                        {
                            EmpresaId = e.EmpresaId,
                            EmpresaNombre = e.EmpresaNombre,
                            Documento1 = e.Documento1,
                            Documento2 = e.Documento2,
                            Documento3 = e.Documento3,
                            Direccion = e.Direccion,
                            Logo = e.Logo,
                            FechaDeCreacion = e.FechaDeCreacion,
                            FechaDeModificacion = e.FechaDeModificacion,
                            CreadoPor = e.CreadoPor,
                            ModificadoPor = e.ModificadoPor,
                        };

            return query.ToList();
        }

        public EmpresaEntity GetById(int Id)
        {
            var query = from e in context.empresa
                        where e.EmpresaId == Id
                        select new EmpresaEntity
                        {
                            EmpresaId = e.EmpresaId,
                            EmpresaNombre = e.EmpresaNombre,
                            Documento1 = e.Documento1,
                            Documento2 = e.Documento2,
                            Documento3 = e.Documento3,
                            Direccion = e.Direccion,
                            Logo = e.Logo,
                            FechaDeCreacion = e.FechaDeCreacion,
                            FechaDeModificacion = e.FechaDeModificacion,
                            CreadoPor = e.CreadoPor,
                            ModificadoPor = e.ModificadoPor,
                        };

            return query.FirstOrDefault();
        }

        public (EmpresaEntity, Resultado) Save(EmpresaEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {

                    var modlExist = ContextP.empresa.Where(x => x.EmpresaId == model.EmpresaId).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.empresa();


                    if (modlExist != null)
                        modlNew = modlExist;


                    modlNew.EmpresaId = model.EmpresaId;
                    modlNew.EmpresaNombre = model.EmpresaNombre;
                    modlNew.Documento1 = model.Documento1;
                    modlNew.Documento2 = model.Documento2;
                    modlNew.Documento3 = model.Documento3;
                    modlNew.Direccion = model.Direccion;
                    modlNew.Logo = model.Logo;
                    
                    modlNew.FechaDeModificacion = DateTime.Now;
                    
                    modlNew.ModificadoPor = model.ModificadoPor;

                    if (modlNew.EmpresaId == 0)
                    {
                        modlNew.FechaDeCreacion = DateTime.Now;
                        modlNew.CreadoPor = model.CreadoPor;

                        ContextP.empresa.Add(modlNew);
                    }
                    ContextP.SaveChanges();

                    model.EmpresaId = modlNew.EmpresaId;
                }

                return (GetById(model.EmpresaId), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {

                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logro almacenar el Registro \n" + ex.Message });
            }
        }
        public Resultado Delete(EmpresaEntity model)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {

                    var modlExist = ContextP.empresa.Where(x => x.EmpresaId == model.EmpresaId).FirstOrDefault();


                    if (modlExist != null)
                    {
                        ContextP.empresa.Remove(modlExist);
                        ContextP.SaveChanges();
                        return new Resultado { Codigo = 0, Mensaje = "Exito Resgistro Eliminado Permanetemente" };
                    }
                    else
                        return new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "Registro no encontrado" };
                }

            }
            catch (Exception ex)
            {

                return new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logro eliminar el Registro \n" + ex.Message };

            }
        }
    }
}

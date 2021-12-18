using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_BL
{
  public class CxcTypeDatos
    {
        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public List<CxcTypeEntity> GetAll()
        {
            var query = from p in context.cxctype
                        select new CxcTypeEntity
                        {
                            Abrev = p.Abrev,
                            Corr = p.Corr,
                            TypeName = p.TypeName
                        };

            return query.ToList();
        }
        public CxcTypeEntity GetById(string Id)
        {
            var query = from p in context.cxctype
                        where p.TypeName == Id
                        select new CxcTypeEntity
                        {
                            Abrev = p.Abrev,
                            Corr = p.Corr,
                            TypeName = p.TypeName
                        };

            return query.FirstOrDefault();
        }

        public (CxcTypeEntity, Resultado) Save(CxcTypeEntity model)
        {
            try
            {
                using (var cn = new Kondominium_DAL.KEntities())
                {
                    var modlExist = cn.cxctype.Where(x => x.TypeName == model.TypeName).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.cxctype();

                    if (modlExist != null)
                    {
                        modlNew = modlExist;
                    }

                    modlNew.Abrev = model.Abrev;
                    modlNew.Corr = model.Corr;



                    if (modlExist == null)
                    {
                        modlNew.TypeName = model.TypeName;
                        cn.cxctype.Add(modlNew);
                    }
                    cn.SaveChanges();
                }
                return (GetById(model.TypeName), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {
                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "El registro no pudo ser guardado. \n" + ex.Message });

            }
        }
    }
}

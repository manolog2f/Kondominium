using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public string GenerateNextNumber(string Id)
        {
            string Voucher = "";

            var dato = GetById(Id);
            Save(new CxcTypeEntity { Abrev = dato.Abrev, TypeName = dato.TypeName, Corr = dato.Corr + 1 });

            Voucher = string.Concat("0000000000", dato.Corr.ToString());
            Voucher = Voucher.Substring(Voucher.Length - 10, 10);
            Voucher = string.Concat(dato.Abrev, Voucher);

            return Voucher;
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

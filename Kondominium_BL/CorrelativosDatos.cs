using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kondominium_Entities;

namespace Kondominium_BL
{
    public class CorrelativosDatos
    {
        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public List<CorrelativosEntity> GetAll()
        {
            var query = from p in context.correlativos
                        select new CorrelativosEntity
                        {
                            Abrev = p.Abrev,
                            Corr = p.Corr,
                            Name = p.Name,
                            Tipo = p.Tipo
                        };

            return query.ToList();
        }
        public CorrelativosEntity GetById(string Id)
        {
            var query = from p in context.correlativos
                        where p.Name == Id
                        select new CorrelativosEntity
                        {
                            Abrev = p.Abrev,
                            Corr = p.Corr,
                            Name = p.Name,
                            Tipo = p.Tipo
                        };

            return query.FirstOrDefault();
        }
        public string GenerateNextNumber(string Id)
        {
            string Voucher = "";

            var dato = GetById(Id);
            Save(new CorrelativosEntity { Abrev = dato.Abrev, Name = dato.Name, Corr = dato.Corr + 1, Tipo = dato.Tipo });

            Voucher = string.Concat("0000000000", dato.Corr.ToString());
            Voucher = Voucher.Substring(Voucher.Length - 10, 10);
            Voucher = string.Concat(dato.Abrev, Voucher);

            return Voucher;
        }




        public (CorrelativosEntity, Resultado) Save(CorrelativosEntity model)
        {
            try
            {
                using (var cn = new Kondominium_DAL.KEntities())
                {
                    var modlExist = cn.correlativos.Where(x => x.Name == model.Name).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.correlativos();

                    if (modlExist != null)
                    {
                        modlNew = modlExist;
                    }

                    modlNew.Abrev = model.Abrev;
                    modlNew.Corr = model.Corr;



                    if (modlExist == null)
                    {
                        modlNew.Name = model.Name;
                        cn.correlativos.Add(modlNew);
                    }
                    cn.SaveChanges();
                }
                return (GetById(model.Name), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {
                return (model, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "El registro no pudo ser guardado. \n" + ex.Message });

            }
        }
    }
}

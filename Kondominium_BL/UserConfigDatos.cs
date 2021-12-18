using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_BL
{
   public class UserConfigDatos
    {
        Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();
        public UserConfigEntity GetByName(string UserId, string NameId)
        {
            try
            {
                var query = context.userconfig.Where(x => x.UserId == UserId && x.PropertyName == NameId)
                            .Select(x => new UserConfigEntity
                            {
                                UserId = x.UserId,
                                PropertyName = x.PropertyName,
                                PropertyValue = x.PropertyValue,
                                CreateByUserId = x.CreateByUserId,
                                CreateDate = x.CreateDate,
                                ModifiedByUserId = x.ModifiedByUserId,
                                ModifiedDate = x.ModifiedDate
                            });

                    return query.FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public List<UserConfigEntity> GetAllByName(string UserId, string NameId)
        {
            try
            {
                var query = context.userconfig.Where(x => x.UserId == UserId && x.PropertyName == NameId)
                            .Select(x => new UserConfigEntity
                            {
                                UserId = x.UserId,
                                PropertyName = x.PropertyName,
                                PropertyValue = x.PropertyValue,
                                CreateByUserId = x.CreateByUserId,
                                CreateDate = x.CreateDate,
                                ModifiedByUserId = x.ModifiedByUserId,
                                ModifiedDate = x.ModifiedDate
                            });

                return query.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public (UserConfigEntity, Resultado) Save(UserConfigEntity uconf)
        {
            try
            {
                using (var ContextP = new Kondominium_DAL.KEntities())
                {

                    var modlExist = ContextP.userconfig.Where(x => x.UserId == uconf.UserId && x.PropertyName == uconf.PropertyName).FirstOrDefault();
                    var modlNew = new Kondominium_DAL.userconfig();

                    if (modlExist != null)
                    {
                        modlNew = modlExist;
                    }

                    modlNew.UserId = uconf.UserId;
                    modlNew.PropertyName = uconf.PropertyName;
                    modlNew.PropertyValue = uconf.PropertyValue;

                    modlNew.ModifiedDate = DateTime.Now;
                    modlNew.ModifiedByUserId = uconf.ModifiedByUserId;

                    if (modlExist  == null)
                    {
                        modlNew.CreateDate = DateTime.Now;
                        modlNew.CreateByUserId = uconf.CreateByUserId;

                        ContextP.userconfig.Add(modlNew);
                    }
                    ContextP.SaveChanges();

                    
                }

                return (GetByName(uconf.UserId, uconf.PropertyName), new Resultado { Codigo = 0, Mensaje = "Exito" });
            }
            catch (Exception ex)
            {

                return (uconf, new Resultado { Codigo = CodigosMensaje.Error, Mensaje = "No se logro almacenar el Registro \n" + ex.Message });
            }
        }

    }
}

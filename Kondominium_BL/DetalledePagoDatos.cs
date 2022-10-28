using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_BL
{
    public class DetalledePagoDatos
    {
        private Kondominium_DAL.KEntities context = new Kondominium_DAL.KEntities();

        public List<DetalleDePagoEntity> Ejecutar(DateTime Desde, DateTime Hasta)
        {
            try
            {
                var lects = context.Database.SqlQuery<DetalleDePagoEntity>(string.Concat("call SP_DetalleDePagos ('", Desde.ToString("yyyy-MM-dd"), "','", Hasta.ToString("yyyy-MM-dd"), "')")).ToList();

                //var consulta = new Kondominium_DAL.  .MYSQL.MRMySqlConect().Consultar(String.Format(@" call                         SP_User_Permission (
                //                 '{0}' )", userid)
                //                , ZTAdminDAL.MYSQL.Server.Security).AsEnumerable().Select(x => new ProfilePermissionEntity
                //                {
                //                    ProfileId = x.Field<string>("ProfileId"),
                //                    ProfilePermissionId = x.Field<string>("ProfilePermissionId"),
                //                    Active = x.Field<int>("PermissionActive"),
                //                    Search = x.Field<int>("Search"),
                //                    New = x.Field<int>("New"),
                //                    Edit = x.Field<int>("Edit"),
                //                    Save = x.Field<int>("Save"),
                //                    Delete = x.Field<int>("Delete"),
                //                }).ToList();

                //var lista = new List<UserPermissionEntity>();

                //foreach (var item in consulta)
                //{
                //    var l = new UserPermissionEntity(
                //            item.ProfilePermissionId,
                //            item.Active == 1 ? true : false,
                //            item.Save == 1 ? true : false,
                //            item.New == 1 ? true : false,
                //            item.Edit == 1 ? true : false,
                //            item.Delete == 1 ? true : false,
                //            item.Search == 1 ? true : false);

                //    lista.Add(l);
                //}

                return lects;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                context.Dispose();
            }
        }
    }
}
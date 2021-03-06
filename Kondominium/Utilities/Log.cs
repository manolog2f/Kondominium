using System;

namespace Kondominium.Utilities
{
    public class Log
    {

        public void Set(String Action, String UserId, String Host, String AplicationName)
        {

            try
            {
                new ZTAdminBL.Security.Log_ActionData().InsetLog(new ZTAdminEntities.Security.Log_ActionEntity()
                {
                    Action = Action,
                    DateTimeOfAction = DateTime.Now,
                    Host = Host,
                    UserId = UserId
                });

            }
            catch (Exception ex)
            {

                Core.logW.WriteLogExection(ZoomTechLog.LogType.Warn, ex, AplicationName, "", UserId);
            }

            /* Inserta en Log que se realizo un Login */
        }
    }

}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTAdminEntities.Security;
//using System.Windows.Forms;

namespace Kondominium.Utilities
{
    public static class Core
    {
        public static string UserId;
        public static bool SmallIconos;
        public static ZoomTechLog.EventViewer.EventViewer logEvenViewer = new ZoomTechLog.EventViewer.EventViewer();
        public static ZoomTechLog.Log4NetMR.classClsRegistrarLog logW1 = new ZoomTechLog.Log4NetMR.classClsRegistrarLog();
        public static ZoomTechLog.Log logW = new ZoomTechLog.Log();
        public static string SMTServer;
        public static string UserEmail;
        public static string PassEmail;
        public static string PortSMTP;
        public static string FromEmail;
        public static bool ViewDeleted;

        static Core()
        {

            Core.UserId = "";
            SmallIconos = false;

            SMTServer = new ZoomTechUtils.Utils().ReadSetting("SMTPServer");
            UserEmail = new ZoomTechUtils.Utils().ReadSetting("UserEmail");
            PassEmail = new ZoomTechUtils.Utils().ReadSetting("PassEmail");
            PortSMTP = new ZoomTechUtils.Utils().ReadSetting("PortSMTP");
            FromEmail = new ZoomTechUtils.Utils().ReadSetting("FromEmail");

            ViewDeleted = false;

            /*
            SMTPServer
            UserEmail"
            PassEmail"
            PortSMTP" */
        }       
    }

    public static class UserConfig
    {
        public static UserEntity  User;
        

        static UserConfig()
        {
            
          
        }


    }

    

    
}

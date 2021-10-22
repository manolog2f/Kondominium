using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTAdminEntities.Security;
//using System.Windows.Forms;

namespace ZTAdmin.Class
{
    public static class Core
    {
        public static string UserId;
        public static bool SmallIconos;
        public static ZoomTechLog.EventViewer.EventViewer logEvenViewer = new ZoomTechLog.EventViewer.EventViewer();
        public static ZoomTechLog.Log4NetMR.classClsRegistrarLog logW1 = new ZoomTechLog.Log4NetMR.classClsRegistrarLog();
        public static ZoomTechLog.Log logW = new ZoomTechLog.Log();

        static Core()
        {
            Core.UserId = "";
            SmallIconos = false;
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

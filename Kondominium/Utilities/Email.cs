using System;
using System.IO;

namespace Kondominium.Utilities
{
    public class Email
    {
        public string Htmlemail(string Uri)
        {
            //var appSettings = ConfigurationManager.AppSettings;
            //   string path = Uri + "/Content/EmailTemplate/ForgetPassword.txt"; //appSettings.GetValues("FormatoEmail")[0].ToString();
            //var dataFile = Server.MapPath(path); //Uri + "/Content/EmailTemplate/ForgetPassword.txt";
            string readText = File.ReadAllText(Uri);
            return (readText);

        }

        /// FormatoEmailCode2
        public string GetBodyForgetPassword(string PassNew, string URI)
        {
            //return Htmlemail(URI);
            return String.Format(Htmlemail(URI), PassNew);

        }

    }
}
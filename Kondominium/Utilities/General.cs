using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kondominium.Utilities
{
    public class General
    {
        public string ExtraerExtencion(string file)
        {
            return file.Substring(file.IndexOf("."), file.Length - file.IndexOf("."));

        }

    }
}
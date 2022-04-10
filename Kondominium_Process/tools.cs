using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Process
{
    public class tools
    {
        public static string GetUntilOrEmpty(string text, string stopAt = "\\")
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.LastIndexOf("\\") + 1;
                if (charLocation > 0)
                {
                    return text.Substring(charLocation, 3);
                }
            }

            return String.Empty;
        }

        internal static decimal toDecimal(string strValue)
        {
            decimal zero;
            if (strValue == "")
            {
                zero = decimal.Zero;
            }
            else if (strValue.ToLower() != "true")
            {
                try
                {
                    zero = decimal.Parse(strValue);
                }
                catch (Exception)
                {
                    zero = decimal.Zero;
                }
            }
            else
            {
                zero = decimal.One;
            }
            return zero;
        }
    }
}
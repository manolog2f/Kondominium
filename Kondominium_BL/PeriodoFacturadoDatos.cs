using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_BL
{
    public class PeriodoFacturadoDatos
    {

        public List<string> periodos()
        {
            var lreturn = new List<string>();
            var FechaActual = new DateTime();

            FechaActual = DateTime.Now.AddYears(-1);

            for (int i = 1; i <= 24; i++)
            {
                lreturn.Add(FechaActual.ToString("MMMM") + ' ' + FechaActual.Year.ToString());
                FechaActual = FechaActual.AddMonths(1);
            }

            return lreturn;
        }

    }
}

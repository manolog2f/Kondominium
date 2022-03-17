using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Process
{
    public class enumerados
    {
        public enum banco
        {
            [DescriptionAttribute("")]
            Banco = 0,
            [DescriptionAttribute("Banco Agricola")]
            BAG = 1,
            [DescriptionAttribute("Banco Cuscatlan")]
            BCU = 2,
            [DescriptionAttribute("Banco de America Central")]
            BAC = 3
        }

        public enum codificacion
        {
            [DescriptionAttribute("Codigo de Barras")]
            BAR = 1,
            [DescriptionAttribute("NPE")]
            NPE = 2,
            [DescriptionAttribute("Pago Manual")]
            PGM = 3,
        }

        public enum letras
        {

            A = 1,
            B = 2,
            C = 3,
            D = 4,
            E = 5,
            F = 6,
            G = 7,
            H = 8,
            I = 9,
            J = 10,
            K = 11,
            L = 12,
            M = 13,
            N = 14,
            O = 15,
            P = 16,
            Q = 17,
            R = 18,
            S = 19,
            T = 20,
            U = 21,
            V = 22,
            W = 23,
            X = 24,
            Y = 25,
            Z = 26

        }
    }
}

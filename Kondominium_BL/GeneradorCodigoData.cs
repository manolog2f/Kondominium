using System;

namespace Kondominium_BL
{
    public class GeneradorCodigoData
    {
        /// <summary>
        /// gln+pago(6 digitos)+impar+8020(referencia)
        /// </summary>

        public (string barra, string mostrar) BR(string gln, decimal Monto, DateTime FechaPago, string arancel, string NumeroCasa, string LetraCasa, string Poligono)
        {
            ///415 + gln + 3902 + 0000000000(Monto) + 8020 + Referencia( Arancel + Numero Casa + Letra Cas + Poligono +  Fecha(MMyy))

            var xMonto = "";
            var xBr = "";
            var xReferencia = "";
            var xMostrar = "";
            var xFecha = "";

            if (Monto.ToString().Contains("."))
                xMonto = "0000000000" + Monto.ToString().Replace(",", "").Replace(".", "");
            else
                xMonto = "0000000000" + Monto.ToString().Replace(",", "").Replace(".", "") + "00";

            xMonto = xMonto.Substring(xMonto.Length - 10, 10);

            xReferencia = rightMR("0" + ReemplazaABC(arancel.Substring(0, 2)), 2) +
                            rightMR("0" + NumeroCasa, 2) +
                            ReemplazaABC(LetraCasa) +
                            ReemplazaABC(Poligono);

            xFecha = FechaPago.ToString("MMyy");

            xBr = string.Concat("415", gln, "3902", xMonto, "8020", xReferencia, xFecha);
            xMostrar = string.Concat("(415) ", gln, "(3902) ", xMonto, "(8020) ", xReferencia, xFecha);

            return (xBr, xMostrar);
        }

        public string NPE(string gln, decimal Monto, DateTime FechaPago, string arancel, string NumeroCasa, string LetraCasa, string Poligono)
        {
            // Ultimos 4 digitos de gln
            var xgln = gln.Substring(gln.Length - 5, 5).Substring(0, 4);
            var xMonto = "";

            if (Monto.ToString().Contains("."))
                xMonto = "00000000" + Monto.ToString().Replace(",", "").Replace(".", "");
            else
                xMonto = "00000000" + Monto.ToString().Replace(",", "").Replace(".", "") + "00";

            xMonto = xMonto.Substring(xMonto.Length - 6, 6);

            /// Yanira dijo que era una constante = 0
            var xImpart = "0";

            ////8020 Referencia para este caso sera poligo y casa
            var xReferencia = rightMR("0" + ReemplazaABC(arancel.Substring(0, 2)), 2) +
                              rightMR("0" + NumeroCasa, 2) +
                              ReemplazaABC(LetraCasa) +
                              ReemplazaABC(Poligono);

            var xFecha = FechaPago.ToString("MMyy");
            var PreNPE = string.Concat(xgln, xMonto, xImpart, xReferencia, xFecha);

            var NPEFinal = new Kondominium_vbFunciones.NPEFuntions().divNPE(PreNPE, new Kondominium_vbFunciones.NPEFuntions().BornNPE(PreNPE));

            return NPEFinal;
        }

        public string ReemplazaABC(string textor)
        {
            return textor == "" ? "00" : textor.Replace("A", "01").
            Replace("B", "02").
            Replace("C", "03").
            Replace("D", "04").
            Replace("E", "05").
            Replace("F", "06").
            Replace("G", "07").
            Replace("H", "08").
            Replace("I", "09").
            Replace("J", "10").
            Replace("K", "11").
            Replace("L", "12").
            Replace("M", "13").
            Replace("N", "14").
            Replace("O", "15").
            Replace("P", "16").
            Replace("Q", "17").
            Replace("R", "18").
            Replace("S", "19").
            Replace("T", "20").
            Replace("U", "21").
            Replace("V", "22").
            Replace("W", "23").
            Replace("X", "24").
            Replace("Y", "25").
            Replace("Z", "26");
        }

        private string rightMR(string texto, int caracteres)
        {
            return texto.Substring(texto.Length - caracteres, caracteres);
        }
    }
}
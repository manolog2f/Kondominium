using System;

namespace Kondominium_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var gcode = new Kondominium_BL.GeneradorCodigoData().NPE("7419700006022", (decimal)135, DateTime.Parse("2021-09-25"), "01", "8", "C", "F");
            var BRcode = new Kondominium_BL.GeneradorCodigoData().BR("7419700006022", (decimal)135, DateTime.Parse("2021-09-25"), "01", "8", "C", "F");

            Console.WriteLine(gcode);

            Console.WriteLine("----------------------------------------------------------");

            Console.WriteLine(BRcode.barra);
            Console.WriteLine(BRcode.mostrar);

            Console.Write("Press <Enter> to exit... ");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }
    }
}

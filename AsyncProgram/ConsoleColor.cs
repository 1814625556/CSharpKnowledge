using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgram
{
    public static class ConsoleColor
    {
        public static void ConsoleTest()
        {
            Console.ForegroundColor = System.ConsoleColor.Red;
            Console.WriteLine("AAAAAAAAAAA");
            Console.ResetColor();
            Console.WriteLine("BBBBBBBBBBB");
            Console.ForegroundColor = System.ConsoleColor.DarkBlue;
            Console.WriteLine("CCCCCCCCC");
        }
    }
}

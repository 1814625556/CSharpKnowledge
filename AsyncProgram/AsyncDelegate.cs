using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AsyncProgram
{
    public delegate int TakesAWhileDelegate(int x, int ms);
    public class AsyncDelegate
    {
        public static int TakesAWhile(int x, int ms)
        {
            Task.Delay(ms).Wait();
            return 42;
        }

        public static void Test()
        {
            try
            {
                TakesAWhileDelegate d1 = TakesAWhile;

                IAsyncResult ar = d1.BeginInvoke(1, 330, null, null);
                while (true)
                {
                    WriteLine("--------------");
                    if (ar.AsyncWaitHandle.WaitOne(50))
                    {
                        WriteLine("Can get the result now");
                        break;
                    }
                }
                int result = d1.EndInvoke(ar);
                WriteLine($"result: {result}");
            }
            catch (PlatformNotSupportedException)
            {
                WriteLine("PlatformNotSupported exception - with async delegates please use the full .NET Framework");
            }
        }
    }
}

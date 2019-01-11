using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgram
{
    public class AsyncException
    {
        static async Task ThrowAfter(int ms, string message)
        {
            Console.WriteLine($"throwAfter....{System.Threading.Thread.CurrentThread.ManagedThreadId}");

            await Task.Delay(ms);
           
            throw new Exception(message);
        }

        public async static void DontHandle()
        {
            try
            {
                await ThrowAfter(200, "Error message..");//这里如果想要使用await 方法名前必须添加async
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        ///获取所有异常
        public static async void ShowAggregateException()
        {
            Task taskResult = null;
            try
            {
                Console.ForegroundColor = System.ConsoleColor.DarkRed
                    ;
                Console.WriteLine($"t1 before :{System.Threading.Thread.CurrentThread.ManagedThreadId}");
                Task t1 = ThrowAfter(2000, "first exception");
                Console.WriteLine($"t2 before :{System.Threading.Thread.CurrentThread.ManagedThreadId}");
                Task t2 = ThrowAfter(2000, "second exception");
                Console.WriteLine($"whenAll before :{System.Threading.Thread.CurrentThread.ManagedThreadId}");
                await (taskResult = Task.WhenAll(t1, t2));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"handled {ex.Message}");
                foreach (var ex1 in taskResult.Exception.InnerExceptions)
                {
                    Console.ForegroundColor = System.ConsoleColor.Red;
                    Console.WriteLine(ex1.Message);
                    Console.ResetColor();
                }
            }
        }
    }
}

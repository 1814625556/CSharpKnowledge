using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgram
{
    public class TaskTest
    {
        public static string Greeting(string name)
        {
            Task.Delay(300).Wait();
            return $"Hello {name}";
        }

        public static Task<string> GreetingAsync(string name)
        {
            return Task.Run<string>(() => Greeting(name));
        }

        public static Func<string, string> greetingInvoke = Greeting;

        public static IAsyncResult BeginGreeting(string name, AsyncCallback callback, object state)
        {
            return greetingInvoke.BeginInvoke(name, callback, state);
        }

        public static string EndGreeting(IAsyncResult ar)
        {
            return greetingInvoke.EndInvoke(ar);
        }

        public static async void ConvertingAsyncPattern()
        {
            var s = await Task<string>.Factory.FromAsync<string>(BeginGreeting, EndGreeting, "Angela", null);//将begin,end转换成task

            Console.WriteLine($"result:{s},Id : {System.Threading.Thread.CurrentThread.ManagedThreadId}");
        }
    }
}

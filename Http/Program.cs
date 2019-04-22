using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Http
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunMethod();
            //启动http服务器
            HttpServer.StartServerAsync(new string[] { });
            Console.WriteLine("method is over...");
            Console.ReadKey();
        }

        static async void RunMethod()
        {
            await HttpClientSample.HttpRequest11("","");
        }
    }
}

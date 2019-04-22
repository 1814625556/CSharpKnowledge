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
            //HttpServer.StartServerAsync(new string[] { });
            args = new[] {"http://localhost:9001/samples"};
            RunServer(args);
            Console.WriteLine("method is over...");
            Console.ReadKey();
        }

        static void RunServer(string[] args)
        {
            if (args.Length < 1)
            {
                //ShowUsage();
                return;
            }
            HttpServer.StartServerAsync(args).Wait();
        }

        static async void RunMethod()
        {
            await HttpClientSample.HttpRequest11("","");
        }
    }
}

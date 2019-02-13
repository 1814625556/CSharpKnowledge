using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgram
{
    public class AsyncHelper
    {
        private static string url = "https://www.baidu.com";
        /// <summary>
        /// 这种方法其实是用委托实现的异步：先执行异步的操作，然后再执行回调函数。。
        /// </summary>
        public static void BeginInvokeTest()
        {
            var resp = "";
            Func<string, string> downloadString = address =>
            {
                var client = new WebClient();
                Console.WriteLine("downloadString method....");


                //Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");

                return client.DownloadString(address);
            };
            downloadString.BeginInvoke("https://www.baidu.com", ar =>
            {
                try
                {
                    Console.WriteLine("BeginInvoke......");
                    resp = downloadString.EndInvoke(ar);
                    Console.WriteLine("downloadString callback....");


                    //Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");

                }
                catch (WebException ex) when (ex.Message.Contains("401"))
                {
                    
                }
            }, null);
            Console.WriteLine("Main ``````");
        }
        /// <summary>
        /// 这种方式就是同步调用。。。
        /// </summary>
        public static void DelegateInvoke()
        {
            Func<string, string> downloadString = address =>
            {
                var client = new WebClient();
                Console.WriteLine("downloadString method....");
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");
                return client.DownloadString(address);
            };

            downloadString.Invoke("https://www.baidu.com");
            Console.WriteLine("DelegateInvoke method....");
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");
        }

        public static void EventAsyncTest()
        {
            var client = new WebClient();
            client.DownloadStringCompleted += (sender1, e1) =>
            {
                try
                {
                    string resp = e1.Result;
                    Console.WriteLine(resp.Substring(0,30));
                    Console.WriteLine($"DownloadStringCompleted: {Thread.CurrentThread.ManagedThreadId}");
                }
                catch (Exception ex) when (ex.InnerException?.Message.Contains("401") ?? false)
                {
                    
                }
            };
            client.DownloadStringAsync(new Uri(url));
            Console.WriteLine($"EventAsyncTest:{Thread.CurrentThread.ManagedThreadId}");
        }

        public static async void OnTaskBasedPattern()
        {
           var client = new WebClient();
           var resp =await client.DownloadDataTaskAsync(url);
           Console.WriteLine("aaaa");
        }

        public static async void HttpClientTest()
        {
            var client = new HttpClient();
            var respon = await client.GetAsync(url);
            Console.WriteLine("get respon...");
            var resp = await respon.Content.ReadAsStringAsync();
            Console.WriteLine("get responString...");

        }
        /// <summary>
        /// await 其实就相当于 yield
        /// </summary>
        public static async void TestTaskRunMethod()
        {
            await Task.Run(() =>
            {
                for (var i = 0; i < 10; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(1);
                }
            });
            Console.WriteLine("---------");
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");
        }

        public static async Task SayOk(string name)
        {
            Task.Delay(100).Wait();
            Console.WriteLine($"Hello {name}");
            Console.ForegroundColor = System.ConsoleColor.Red;
            Console.WriteLine($"SayOk:{System.Threading.Thread.CurrentThread.ManagedThreadId}");
            await Task.Run(() =>
            {
                Task.Delay(100).Wait();
                Console.WriteLine($"新开的任务。。。");
            });
            Console.WriteLine($"Task Run:{System.Threading.Thread.CurrentThread.ManagedThreadId}");
            Console.ResetColor();
            //return Task.Run(() =>
            //{
            //    Console.WriteLine($"Task Run:{System.Threading.Thread.CurrentThread.ManagedThreadId}");
            //    Console.ResetColor();
            //});
        }
    }
}

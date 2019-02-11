using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgram
{
    public class MonitorTest
    {
        static object obj = new object();
        private static bool flag = false;

        public static void Test()
        {
            for (var i = 0; i < 3; i++)
            {
                //Thread.Sleep(200);
                Task.Run(() => Method4());
            }
            //var t1 = new Thread(new ThreadStart(Method4));
            //var t2 = new Thread(new ThreadStart(Method4));
            //t1.Start();
            //t2.Start();
        }

        public static void Method1()
        {
            //Monitor.TryEnter(obj, 500, ref flag);
            //Monitor.Enter(obj);
            //if (flag)
            //{
            //    try
            //    {
            //        Console.WriteLine($"lock success,flag:{flag} - ThreadId:{Thread.CurrentThread.ManagedThreadId}");
            //    }
            //    finally
            //    {
            //        Monitor.Exit(obj);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine($"lock fail,ThreadId:{Thread.CurrentThread.ManagedThreadId}");
            //}
        }

        public static void Method2()
        {
            lock (obj)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"thradId:{Thread.CurrentThread.ManagedThreadId}");
            }
        }

        public static void Method3()
        {
            Monitor.Enter(obj);
            Thread.Sleep(1000);
            Console.WriteLine($"thradId:{Thread.CurrentThread.ManagedThreadId}");
            Monitor.Exit(obj);
        }

        public static void Method4()
        {
            flag = false;//必须有这一步 ref有进有出
            Monitor.TryEnter(obj,500,ref flag);//设置等待被锁定的超时值，避免无限等待。
            Console.WriteLine("尝试获取之后执行了该代码");
            if (flag)
            {
                try
                {
                    Thread.Sleep(600);
                    Console.WriteLine($"flag:{flag} - thradId:{Thread.CurrentThread.ManagedThreadId}");
                }
                finally
                {
                    Monitor.Exit(obj);
                }
            }
            else
            {
                Console.WriteLine($"等待500ms 未获取 obj");
            }
        }
    }
}

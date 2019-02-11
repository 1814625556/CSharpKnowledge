using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MutexTest
{
    class shareRes
    {
        public static bool flag = false;
        public static int count = 0;
        public static Mutex mutex = new Mutex(false,"cc",out flag);
    }

    class IncThread
    {
        int number;
        public Thread thrd;

        public IncThread(string name, int n)
        {
            thrd = new Thread(this.run);
            number = n;
            thrd.Name = name;
            thrd.Start();
        }

        void run()
        {
            Console.WriteLine(thrd.Name + "正在等待 the mutex");
            //申请
            shareRes.mutex.WaitOne();
            Console.WriteLine(thrd.Name + "申请到 the mutex");
            do
            {
                Thread.Sleep(1000);
                shareRes.count++;
                Console.WriteLine("In " + thrd.Name + "ShareRes.count is " + shareRes.count);
                number--;
            } while (number > 0);
            Console.WriteLine(thrd.Name + "释放 the nmutex");
            //  释放
            shareRes.mutex.ReleaseMutex();
            Console.WriteLine($"{thrd.Name}释放the mutex, flag:{shareRes.flag}");
        }
    }

    class DecThread
    {
        int number;
        public Thread thrd;

        public DecThread(string name, int n)
        {
            thrd = new Thread(this.run);
            number = n;
            thrd.Name = name;
            thrd.Start();//线程在此处才开始运行
        }

        void run()
        {
            Console.WriteLine(thrd.Name + "正在等待 the mutex");
            //申请
            shareRes.mutex.WaitOne();
            Console.WriteLine(thrd.Name + "申请到 the mutex");
            do
            {
                Thread.Sleep(1000);
                shareRes.count--;
                Console.WriteLine("In " + thrd.Name + "ShareRes.count is " + shareRes.count);
                number--;
            } while (number > 0);
            Console.WriteLine(thrd.Name + "释放 the nmutex");
            //  释放
            shareRes.mutex.ReleaseMutex();
            Console.WriteLine($"{thrd.Name}释放the mutex, flag:{shareRes.flag}");

        }
    }
}

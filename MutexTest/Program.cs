using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MutexTest
{
    class Program
    {
        Thread thread1 = null;
        Thread thread2 = null;
        Mutex mutex = null;
        public Program()
        {
            mutex = new Mutex();
            thread1 = new Thread(new ThreadStart(thread1Func));
            thread2 = new Thread(new ThreadStart(thread2Func));
        }
        public void RunThread()
        {
            thread1.Start();
            thread2.Start();
        }
        private void thread1Func()
        {
            //mutex.WaitOne();
            
                for (int count = 0; count < 5; count++)
                {
                    lock (this)
                    {
                        TestFunc("Thread1 have run " + count.ToString() + " times");
                        //暂停500ms
                        Thread.Sleep(200);
                    }
                }
            
            //mutex.ReleaseMutex();
        }
        private void thread2Func()
        {
            //mutex.WaitOne();
            
                for (int count = 0; count < 5; count++)
                {
                    lock (this)
                    {
                        TestFunc("Thread2 have run " + count.ToString() + " times");
                        //暂停1500ms
                        Thread.Sleep(2000);
                    }
                }
            
            //mutex.ReleaseMutex();
        }
        private void TestFunc(string str)
        {
            Console.WriteLine("{0} {1}", str, System.DateTime.Now);
        }
        /// <summary>
        /// 入口方法
        /// </summary>
        static void Run1()
        {
            Program p = new Program();
            p.RunThread();
        }

        static void Main(string[] args)
        {
            TestOne();
            Console.ReadKey();
        }
        /// <summary>
        /// 入口方法
        /// </summary>
        static void ProcessLock()
        {
            var flag = false;
            var mutex = new System.Threading.Mutex(true, "Test", out flag);
            //第一个参数:true--给调用线程赋予互斥体的初始所属权
            //第一个参数:互斥体的名称
            //第三个参数:返回值,如果调用线程已被授予互斥体的初始所属权,则返回true
            if (flag)
            {
                Console.Write("Running");
                //mutex.ReleaseMutex();
                //Console.WriteLine(flag);
            }
            else
            {
                Console.Write("Another is Running");
                System.Threading.Thread.Sleep(5000);//线程挂起5秒钟
                Environment.Exit(1);//退出程序
            }
            Console.ReadLine();
        }
        /// <summary>
        /// 初始化同名的Mutex实例
        /// </summary>
        static void MutexNamed()
        {
            var flag1 = false;
            var flag2 = false;
            Mutex m1 = new Mutex(false, "cc", out flag1);
            Mutex m2 = new Mutex(false, "cc", out flag2);
            Console.WriteLine($"Name:{m1.ToString()}");
        }

        static void TestOne()
        {
            DecThread mthrd2 = new DecThread("DecThread thread ", 5);
            IncThread mthrd1 = new IncThread("IncThread thread ", 5);
            

            //mthrd1.thrd.Join();
            //mthrd2.thrd.Join();
        }
    }
}

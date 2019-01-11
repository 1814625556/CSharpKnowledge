using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            //AsyncHelper.BeginInvokeTest();
            //AsyncHelper.DelegateInvoke();
            //AsyncHelper.EventAsyncTest();
            //ConsoleColor.ConsoleTest();
            //AsyncHelper.OnTaskBasedPattern();

            //AsyncHelper.HttpClientTest();
            //AsyncHelper.TestTaskRunMethod();
            
            //TaskTest.ConvertingAsyncPattern();
            //AsyncException.DontHandle();
            //AsyncException.ShowAggregateException();//获取task中的多个异常
            CcTest();
            Console.WriteLine($"Main id : {Thread.CurrentThread.ManagedThreadId}");
            Console.ReadKey();
        }

        public static async void CcTest()
        {
           await AsyncHelper.SayOk("ChenChang");
           Console.WriteLine("AAAAAA");
        }

        /// <summary>
        /// 委托的异步调用
        /// </summary>
        public static void DelegateAsync()
        {
            var cc = TaskTest.greetingInvoke;
            cc.BeginInvoke("Kitty", ar =>
            {
                var result = cc.EndInvoke(ar);
                Console.WriteLine($"callback method:{result}");
                Console.WriteLine($"greetingInvoke id : {Thread.CurrentThread.ManagedThreadId}");
            }, null);
        }

        public class AsyncResult : IAsyncResult
        {

            public bool IsCompleted { get; }
            public WaitHandle AsyncWaitHandle { get; }
            public object AsyncState { get; }
            public bool CompletedSynchronously { get; }
        }
    }
}

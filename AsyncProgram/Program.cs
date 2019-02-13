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
        private static CancellationTokenSource _cts = new CancellationTokenSource();
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
            //CcTest();
            AwaitTest();

            #region 委托的异步调用,fun beigininvoke endinvoke 其中beigin方法的返回结果就是end方法的输入参数，
            //end方法的放回结果就是 同步方法中的返回结果
            //DelegateAsync();
            //DelegateAsync2();
            #endregion

            #region token的用法·····
            //TokenTest();
            //Console.WriteLine("取消 token");
            //Console.ReadKey();
            //_cts.Cancel();
            //Console.WriteLine("token is canceled...");
            #endregion

            #region Parallel用法
            //ParallelSamples.ParallelFor();
            //ParallelSamples.TasksUsingThreadPool();
            //ParallelSamples.RunSynchronousTask();
            //ParallelSamples.TaskWithResultDemo();
            //ParallelSamples.ContinuationTasks();
            #endregion

            #region 任务的层次结构，Task父类子类
            //TaskTest.ParentAndChild();
            #endregion

            #region Semaphore,共享资源限制访问线程数量
            //SemaphoreExample.Method();
            #endregion

            #region MonitorTest

            //MonitorTest.Test();

            #endregion

            #region AsyncDelegate测试

            //AsyncDelegate.Test();

            #endregion

            //Calculator.Test();

            #region 新的task

            //TaskTest2.TestTaskId();
            //TaskTest2.TaskContinueTest();
            //TaskTest2.TaskWaitAny();
            #endregion

            Console.WriteLine("Main method");
            Console.WriteLine($"Main id : {Thread.CurrentThread.ManagedThreadId}");
            Console.ReadKey();
        }
        /// <summary>
        /// Task.Delay(3000).Wait()测试。
        /// </summary>
        public static void DelayWaitTest()
        {
            Task.Run(() =>
            {
                Console.WriteLine(DateTime.Now.Second);
                Task.Delay(3000).Wait();//如果不调用Wait方法，就会直接执行下去。
                Console.WriteLine(DateTime.Now.Second);
                Console.WriteLine("task delay···");
            });
        }

        public static async void CcTest()
        {
           await AsyncHelper.SayOk("ChenChang");
           Console.WriteLine("AAAAAA");
        }

        public static async void AwaitTest()
        {
            await Task.Run(() =>
            {
                Task.Delay(100).Wait();
                Console.WriteLine($"TaskId :{Task.CurrentId}");
            });
            Console.WriteLine("Finally");
        }

        /// <summary>
        /// 取消自定义任务
        /// </summary>
        public static void TokenTest()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    _cts.Token.ThrowIfCancellationRequested();//这段代码必须加上
                    Console.WriteLine($"TokenTest id :{Thread.CurrentThread.ManagedThreadId}");
                }
            }, _cts.Token);
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
            Console.WriteLine("beginInvoke after...");
        }

        public static void DelegateAsync2()
        {
            Func<string, string> fun1 = name => $"Hello {name}";
            fun1.BeginInvoke("Jean", ar =>
            {
                Console.WriteLine(ar.AsyncState);
                var result = fun1.EndInvoke(ar);
                Console.WriteLine($"callback method :{result}");
            }, "aaa");
            Console.WriteLine("DelegateAsync2");
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

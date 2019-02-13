using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgram
{
    public class TaskTest2
    {
        public static void TaskWaitAny()
        {
            var tasks = new Task[5]
            {
                Task.Run(()=>PrintInfo2()),
                Task.Run(()=>PrintInfo2()),
                Task.Run(()=>PrintInfo2()),
                Task.Run(()=>PrintInfo2()),
                Task.Run(()=>PrintInfo2())
            };
            //Task.WaitAll(tasks);
            //Task.WaitAny(tasks);
            var ts = Task.WhenAll(tasks);
        }

        public static void TaskContinueTest()
        {
            var t1 = Task<string>.Run(() =>
            {
                Task.Delay(500).Wait();
                return Task.CurrentId;
            });
            t1.ContinueWith(i =>
            {
                Console.WriteLine($"t1 result is {i.Result}");
                Console.WriteLine($"current taskid is:{Task.CurrentId}");
            });
        }

        public static void TaskWithResultAndParam()
        {
            var t1 = new Task<string>(x=>x.ToString(),"aaa");
            var t2 = Task<string>.Factory.StartNew(x => x.ToString(), "xxx");
        }

        public static void TaskWithParam()
        {
            var tasks = new Task<string>[5]
            {
                new Task<string>(TaskMethod), 
                Task<string>.Factory.StartNew(TaskMethod),
                Task.Run<string>(() => TaskMethod()),
                Task.Run<string>(() => TaskMethod()),
                Task.Run<string>(() => TaskMethod())
            };
            Task.WaitAll(tasks);
            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine(tasks[i].Result);
            }
        }

        public static void TestTaskId()
        {
            new Task(PrintInfo).Start();
            Task.Factory.StartNew(PrintInfo);
            Task.Run(() => PrintInfo());
        }

        /// <summary>
        /// 这种方式会等到所有的task都执行完毕，在执行Task.WaitAll之后的语句
        /// </summary>
        public static void TaskParallel()
        {
            var tasks = new Task[5]
            {
                new Task(PrintInfo),
                new Task(PrintInfo),
                new Task(PrintInfo),
                new Task(PrintInfo),
                new Task(PrintInfo)
            };
            //for (var i = 0; i < 5; i++)
            //{
            //    Task.Run(() => PrintInfo());
            //}
            for (var i = 0; i < 5; i++)
            {
                tasks[i].Start();
            }
            Task.WaitAll(tasks);
        }

        public static void TaskWithResult()
        {

        }

        private static void PrintInfo()
        {
            Task.Delay(100).Wait();
            Console.WriteLine($"TaskId:{Task.CurrentId},ThreadId:{Thread.CurrentThread.ManagedThreadId}");
        }

        private static string TaskMethod()
        {
            return "hello..";
        }

        private static void PrintInfo2()
        {
            Task.Delay(Convert.ToInt32(Task.CurrentId*100)).Wait();
            Console.WriteLine($"TaskId:{Task.CurrentId},ThreadId:{Thread.CurrentThread.ManagedThreadId}");
        }
    }
}

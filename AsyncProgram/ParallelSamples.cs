using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace AsyncProgram
{
    public class ParallelSamples
    {
        public static void ParallelFor()
        {
            ParallelLoopResult result =
                Parallel.For(0, 10, i =>
                {
                    Log($"S {i}");
                    Task.Delay(10).Wait();
                    Log($"E {i}");
                });
            Console.WriteLine($"Is completed: {result.IsCompleted}");
        }
        public static void Log(string prefix)
        {
            Console.WriteLine($"{prefix} task: {Task.CurrentId}, " +
                              $"thread: {Thread.CurrentThread.ManagedThreadId}");
        }
        public static void TaskMethod(object o)
        {
            Log(o?.ToString());
        }
        public static void TasksUsingThreadPool()
        {

            var tf = new TaskFactory();
            Task t1 = tf.StartNew(TaskMethod, "using a task factory");
            Task t2 = Task.Factory.StartNew(TaskMethod, "factory via a task");
            var t3 = new Task(TaskMethod, "using a task constructor and Start");
            t3.Start();
            Task t4 = Task.Run(() => TaskMethod("using the Run method"));
        }
        public static void RunSynchronousTask()
        {
            TaskMethod("just the main thread");
            var t1 = new Task(TaskMethod, "run sync");
            //t1.Start();//这样的话会使用线程池里面的线程的
            t1.RunSynchronously();//同步运行以相同的线程作为主调线程
        }

        public static string TaskWithResult(object obj)
        {
            Persion per = obj as Persion;
            
            Console.WriteLine($"Taskid:{Task.CurrentId}," +
                              $"ThreadId:{Thread.CurrentThread.ManagedThreadId},"+
                              $"isBackThread:{Thread.CurrentThread.IsBackground},"+
                              $"isPoolThread:{Thread.CurrentThread.IsThreadPoolThread}");
            Thread.Sleep(5000);
            Console.WriteLine($"Thread.Sleep over...");
            return $"Name:{per.Name},Age:{per.Age}";
        }
        /// <summary>
        /// 包含返回结果的Task
        /// </summary>
        public static void TaskWithResultDemo()
        {
            //这是通过工厂方法创建任务
            //var str = Task.Factory.StartNew(TaskWithResult, new Persion()
            //{ Name = "Kitty", Age = 25}).Result;

            var t1 = new Task<string>(TaskWithResult,
                new Persion(){Name = "BeiJing",Age = 100},
                TaskCreationOptions.LongRunning);//加上这个Option就不是后台线程了
            t1.Start();
            //t1.Wait();
            var str = t1.Result;
            Console.WriteLine($"result from task : {str}");
        }
        private static void DoOnFirst()
        {
            WriteLine($"doing some task {Task.CurrentId}");
            //Task.Delay(3000).Wait();
        }

        private static string DoOnSecond(Task t)
        {
            WriteLine($"task {t.Id} finished");
            WriteLine($"this task id {Task.CurrentId}");
            WriteLine("do some cleanup");
            //Task.Delay(3000).Wait();
            return "Hello World";
        }
        public static void ContinuationTasks()
        {

            Task t1 = new Task(DoOnFirst);
            var tr = t1.ContinueWith<string>(DoOnSecond);
            t1.Start();
            TaskStatus status = tr.Status;
            var result = tr.Result;
            //Task t2 = t1.ContinueWith(DoOnSecond);
            //Task t3 = t2.ContinueWith(DoOnSecond);
            //Task t4 = t3.ContinueWith(DoOnSecond);
            //t1.Start();
            //Console.WriteLine(str);
        }
    }



















    public class Persion
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}

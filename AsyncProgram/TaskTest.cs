using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgram
{
    public class TaskTest
    {
        public static string Greeting(string name)
        {
            Task.Delay(300).Wait();
            return $"Hello {name}";
        }

        public static Task<string> GreetingAsync(string name)
        {
            return Task.Run<string>(() => Greeting(name));
        }

        public static Func<string, string> greetingInvoke = Greeting;

        public static IAsyncResult BeginGreeting(string name, AsyncCallback callback, object state)
        {
            return greetingInvoke.BeginInvoke(name, callback, state);
        }

        public static string EndGreeting(IAsyncResult ar)
        {
            return greetingInvoke.EndInvoke(ar);
        }

        public static async void ConvertingAsyncPattern()
        {
            var s = await Task<string>.Factory.FromAsync<string>(BeginGreeting, EndGreeting, "Angela", null);//将begin,end转换成task

            Console.WriteLine($"result:{s},Id : {System.Threading.Thread.CurrentThread.ManagedThreadId}");
        }

        public static void ParentAndChild()
        {
            var parent = new Task(ParentTask);
            Console.WriteLine($"parent.Status1 {parent.Status}");
            parent.Start();
            Task.Delay(500).Wait();
            Console.WriteLine($"parent.Status2 {parent.Status}");
            Task.Delay(1500).Wait();
            Console.WriteLine($"parent.Status3 {parent.Status}");
            Task.Delay(3000).Wait();
            Console.WriteLine($"parent.Status4 {parent.Status}");
        }

        private static void ParentTask()
        {
            Console.WriteLine($"parentTaskId is :{Task.CurrentId}\t"+
                $"threadId is {Thread.CurrentThread.ManagedThreadId}");
            var child = new Task(ChildTask);
            child.Start();
            Task.Delay(1000).Wait();
            Console.WriteLine("Parent Finished...");
        }

        private static void ChildTask()
        {
            Task.Delay(5000).Wait();
            Console.WriteLine($"ChildTaskId is :{Task.CurrentId}\t" +
                              $"threadId is {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("Child Finished...");
            //Task.WhenAll()
            //    Task.WaitAll()
        }
    }
}

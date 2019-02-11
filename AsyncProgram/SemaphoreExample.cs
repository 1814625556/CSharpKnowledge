using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgram
{
    public class SemaphoreExample
    {
        public static void Method()
        {
            int studentCount = 10;
            int seatCount = 4;//小小食堂只有4个位子  
            var semaphore = new SemaphoreSlim(seatCount, seatCount);
            var eatings = new Task[studentCount];
            for (int i = 0; i < studentCount; i++)
            {
                eatings[i] = Task.Run(() => Eat(semaphore));
            }
            Task.WaitAll(eatings);
            Console.WriteLine("All students have finished eating!");
        }

        static void Eat(SemaphoreSlim semaphore)
        {
            semaphore.Wait();
            try
            {
                Console.WriteLine("Student {0} is eating now!", Task.CurrentId);
                Thread.Sleep(1000);
            }
            finally
            {
                Console.WriteLine("Student {0} have finished eating!", Task.CurrentId);
                semaphore.Release();
            }
        }  
    }
}

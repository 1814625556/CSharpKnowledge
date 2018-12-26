 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest
{
    public class QueueTest
    {
        public static void Method1()
        {
            Queue<string> qu = new Queue<string>();
            qu.Enqueue("aaa");
            qu.Enqueue("bbb");
            qu.Enqueue("ccc");
            qu.Enqueue("ddd");
           
            Console.WriteLine($"qu count is :{qu.Count}");
            var result = qu.Dequeue();
            Console.WriteLine(result);
            var peekResult1 = qu.Peek();
            var peekResult2 = qu.Peek();
            Console.WriteLine($"peek result :{peekResult1},{peekResult2}");
            Console.WriteLine($"{qu.Count()}");
        }
    }
}

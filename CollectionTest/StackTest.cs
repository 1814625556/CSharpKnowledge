using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest
{
    public class StackTest
    {
        public static void Method1()
        {
            var alphabet = new Stack<char>();
            alphabet.Push('A');
            alphabet.Push('B');
            alphabet.Push('C');
            alphabet.Push('D');
            Console.WriteLine($"alphabet.count is {alphabet.Count}");
            Console.WriteLine($"pop value is :{alphabet.Pop()}--count is {alphabet.Count}");
            Console.WriteLine($"peek:{alphabet.Peek()}-{alphabet.Peek()}-{alphabet.Peek()}");
            Console.WriteLine($"alphabet is contail A? {alphabet.Contains('A')}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAndTulpe
{
    class Program
    {
        static void Main(string[] args)
        {
            var list1 = new LinkedList();
            list1.AddLast(2);
            list1.AddLast(4);
            //list1.AddLast("6");
            list1.AddLast(5);
            list1.AddLast(6);
            list1.AddLast(7);

            foreach (int i in list1)
            {
                Console.WriteLine(i);
            }
            Console.Read();
        }
    }
}

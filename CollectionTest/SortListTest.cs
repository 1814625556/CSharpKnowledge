using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest
{
    public class SortListTest
    {
        public static void Method1()
        {
            var booksList = new SortedList<int,string>();
            booksList.Add(4, "d");
            booksList.Add(5, "e");
            booksList.Add(6, "f");
            booksList.Add(1, "a");
            booksList.Add(2, "b");
            booksList.Add(3, "c");
            foreach (var book in booksList)
            {
                Console.WriteLine($"key:{book.Key},value:{book.Value}");
            }
            Console.WriteLine(booksList[5]);
            string isbn;
            var flag = booksList.TryGetValue(7, out isbn);
            Console.WriteLine($"value:{isbn} -- flag:{flag}");
        }
    }
}

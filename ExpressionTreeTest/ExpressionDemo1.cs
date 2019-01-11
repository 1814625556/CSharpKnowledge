using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeTest
{
    public class ExpressionDemo1
    {
        public static void Method1()
        {
            Expression<Func<int, int>> expr = x => x + 1;
            Console.WriteLine(expr.ToString());  // x=> (x + 1)
        }
    }
}

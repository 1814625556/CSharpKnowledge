using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialCollectionTest
{
    public class Account
    {
        public Account(string name, decimal amount)
        {
            Name = name;
            Amount = amount;
        }
        public string Name { get; }
        public decimal Amount { get; }
    }
}

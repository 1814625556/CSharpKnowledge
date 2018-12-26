using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAndTulpe
{
    public class LinkedListNode
    {
        public LinkedListNode(object value)
        {
            Value = value;
        }

        public object Value { get; }

        public LinkedListNode Next { get; internal set; }
        public LinkedListNode Prev { get; internal set; }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAndTulpe
{
    public class LinkedList : IEnumerable
    {
        public LinkedListNode First { get; private set; }
        public LinkedListNode Last { get; private set; }

        public LinkedListNode AddLast(object node)
        {
            var newNode = new LinkedListNode(node);
            if (First == null)
            {
                First = newNode;
                Last = First;
            }
            else
            {
                Last.Next = newNode;
                Last = newNode;
            }
            return newNode;
        }

        public IEnumerator GetEnumerator()
        {
            LinkedListNode current = First;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
    }
}

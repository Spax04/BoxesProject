using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxes.Models
{
    public class CustomQueue
    {
        NodeQueue _head,_end;
        private int _count;
        public int Count { get { return _count; } }

        public bool IsEmpty() => _head == null;
        public CustomQueue()
        {
            _end = _head = null;
        }

        public void AddQNode(NodeQueue t)
        {
            if (IsEmpty())
            {
               _end = _head = new NodeQueue(t.Index);
                _count++;
            }
            else
            {
               _end.Next = t;
                t.Previous = _end;
                _end = t;
                _count++;
            }
        }

        public void RemoveQNode(Guid id)
        {
            if (IsEmpty())
                return;
            
            for(NodeQueue t = _head; t != null; t = t.Next)
            {
                if(t.Index == id)
                {
                    NodeQueue tempPrev = t.Previous;
                    NodeQueue tempNext = t.Next;
                    tempPrev.Next = tempNext;
                    tempNext.Previous = tempPrev;
                    t.Next = null;
                    t.Previous = null;
                }
            }
            
            if (_head == null)
                _end = null;
         
        }

        public void printNodes()
        {
            int count = 0;
            for(NodeQueue t = _head.Next; t.Next != null; t = t.Next)
            {
                Console.WriteLine((count + 1) + " === " + t.Index);
                count++;
            }
            Console.WriteLine(count);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxes.Models
{
    public class CustomQueue<V>
    {
        NodeQueue<V> _head,_end;
        private int _count;
        public int Count { get { return _count; } }

        public bool IsEmpty() => _head == null;
        public CustomQueue()
        {
            _end = _head = null;
        }

        public void AddQNode(NodeQueue<V> t)
        {
            if (IsEmpty())
            {
               _end = _head = new NodeQueue<V>();
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

        public NodeQueue<V> RemoveQNode(NodeQueue<V> t)
        {
            if (IsEmpty())
                return null;
            
            NodeQueue<V> tempPrev = t.Previous;
            NodeQueue<V> tempNext = t.Next;
                tempPrev.Next = tempNext;
                tempNext.Previous = tempPrev;

            if (_head == null)
                _end = null;
            return t;
        }

        public void printNodes()
        {
            for(NodeQueue<V> t = _head; t != null; t = t.Next)
            {
                Console.WriteLine(t.ValueQNode);
            }
        }
    }
}

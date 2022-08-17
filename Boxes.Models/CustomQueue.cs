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
        public NodeQueue<V> Head { get { return _head; } }
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

        public void RemoveQNode(NodeQueue<V> t)
        {
            if (IsEmpty())
                return;
            
            t.Previous.Next = t.Next;
            t.Next.Previous = t.Previous;
            t.Next = null;
            t.Previous = null;
            
            if (_head == null)
                _end = null;
         
        }

        public void printNodes()
        {
            int count = 0;
            for(NodeQueue<V> t = _head.Next; t.Next != null; t = t.Next)
            {
                Console.WriteLine((count + 1));
                count++;
            }
            Console.WriteLine(count);
        }
    }
}

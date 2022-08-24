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

        /// <summary>
        /// Method allows to add a new <see cref="NodeQueue{V}"/> to the end of <see cref="CustomQueue{V}"/>
        /// </summary>
        /// <param name="t">The new <see cref="NodeQueue{V}"/></param>
        public void AddQNode(NodeQueue<V> t)
        {
            if (IsEmpty())
            {
               _end = _head = t;
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

        /// <summary>
        /// Taka a given <see cref="NodeQueue{V}"/> and placing it to the end of the <see cref="CustomQueue{V}"/>
        /// </summary>
        /// <param name="t">The chosen <see cref="NodeQueue{V}"/></param>
        public void ReplaceQNode(NodeQueue<V> t)
        {
            if (IsEmpty())
                return;
            if (t == _end)
            {
                t.Previous = _end;
                t.Previous.Next = null;
            }
            else if (t == Head)
            {
                t.Next = Head;
                t.Next.Previous = null;
            }
            else
            {
                t.Previous.Next = t.Next;
                t.Next.Previous = t.Previous;
                t.Next = null;
                t.Previous = null;
            }

            _end.Next = t;
            t.Previous = _end;
            _end = t;
        }

        /// <summary>
        ///  Method allows to remove a <see cref="NodeQueue{V}"/> from the HEAD of <see cref="CustomQueue{V}"/>
        /// </summary>
        /// <param name="t">The <see cref="NodeQueue{V}"/> that Up to remove</param>
        public void RemoveQNode(NodeQueue<V> t)
        {
            if (IsEmpty())
                return;
            if(Head == _end)
            {
                _head = _end = null;
            }
            else if(t == _end)
            {
                _end = t.Previous;
                t.Previous.Next = null;
                t.Previous = null;
            }
            else if(t == Head)
            {
               t.Next = Head;
                t.Next.Previous = null;
                t.Next = null;
            }
            else
            {
                t.Previous.Next = t.Next;
                t.Next.Previous = t.Previous;
                t.Next = null;
                t.Previous = null;
            }
            
            
            if (_head == null)
                _end = null;
            _count--;
        }

        // Node for checking =============
        public void printNodes()
        {
            int count = 0;
            for(NodeQueue<V> t = _head; t.Next != null; t = t.Next)
            {
                count++;
            }
            Console.WriteLine(count);
        }
    }
}

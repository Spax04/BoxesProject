using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxes.Models
{
    public class NodeQueue<V>
    {
        private Guid _index;
        private V _value;
        private NodeQueue<V> _next;
        private NodeQueue<V> _previous;

        public NodeQueue()
        {
            
            _index = new Guid();
            _next = null;
            _previous = null;
        }

        public V ValueQNode { get { return _value; } set { _value = value; } }
        public Guid Index { get { return _index; } }
        public NodeQueue<V> Next { get { return _next; } set { _next = value; } }
        public NodeQueue<V> Previous { get { return _previous; } set { _previous = value; } }
    }
}

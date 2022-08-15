using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxes.Models
{
    public class NodeQueue
    {
        private Guid _index;
        private NodeQueue _next;
        private NodeQueue _previous;

        public NodeQueue(Guid id)
        {
            _index = id;
            _next = null;
            _previous = null;
        }

       // public V ValueQNode { get { return _value; } set { _value = value; } }
        public Guid Index { get { return _index; } }
        public NodeQueue Next { get { return _next; } set { _next = value; } }
        public NodeQueue Previous { get { return _previous; } set { _previous = value; } }
    }
}

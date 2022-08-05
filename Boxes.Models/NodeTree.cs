using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxes.Models
{
    public class NodeTree<T>
    {
        private double _key;
        private T _value;

        public NodeTree(double key, T type)
        {
            _key = key;
            _value = type;
        }
        private NodeTree<T> _left;
        private NodeTree<T> _right;

        public NodeTree<T> Left
        {
            get { return _left; }
            set { _left = value; }
        }
        public NodeTree<T> Right
        {
            get { return _right; }
            set { _right = value; }
        }
        public double KeyNode { get { return _key; } }
        public T ValueNode { get { return _value; } set { _value = value; } }
    }
}

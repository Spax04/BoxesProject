using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxes.Models
{
    public class NodeTree<K,V> 
    {
        private K _key;
        private V _value;

        public NodeTree(K key, V type)
        {
            _key = key;
            _value = type;
        }
        private NodeTree<K, V> _left;
        private NodeTree<K, V> _right;

        public NodeTree<K, V> Left
        {
            get { return _left; }
            set { _left = value; }
        }
        public NodeTree<K, V> Right
        {
            get { return _right; }
            set { _right = value; }
        }
        public K KeyNode { get { return _key; } }
        public V ValueNode { get { return _value; } set { _value = value; } }

        public override string ToString()
        {
            return $"Key number: {_key}";
        }
    }
}

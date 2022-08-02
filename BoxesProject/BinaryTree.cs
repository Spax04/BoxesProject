using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxesProject
{
    public class NodeTree<T>
    {
        private double _key;
        private T _value;

        public NodeTree(double key)
        {
            _key = key;
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
    public class BinaryTree<V>
    {
        

        public class PublishNodeTree<T>
        {
            private double _key;
            private T _value;

            public double KeyNode { get { return _key; } }
            public T ValueNode { get { return _value; } }
        }

        public NodeTree<V> _root;
        public BinaryTree()
        {
            _root = null;
        }

        public void AddNode(double x)
        {
            if (_root == null)
                _root = new NodeTree<V>(x);
            else
                AddNode(x, _root);
        }

        private void AddNode(double x, NodeTree<V> t)
        {
            if (x < t.KeyNode)
            {
                if (t.Left == null)
                    t.Left = new NodeTree<V>(x);
                else
                    AddNode(x, t.Left);
            }
            else
            {
                if (t.Right == null)
                    t.Right = new NodeTree<V>(x);
                else
                    AddNode(x, t.Right);
            }
        }

        public void InOrder()
        {
            InOrder(_root);
        }

        private void InOrder(NodeTree<V> t, double x)
        {
            if(t != null)
            {
                InOrder(t.Left);
                if(t.KeyNode == x)
                {

                }
                InOrder(t.Right);
            }
        }

        public void RemoveNode(double x)
        {
            var node = Get(x) as NodeTree<V>;
            if(node != null)
            {
                // best case
                if(node.Left == null && node.Right == null)
                {
                    node = null;
                    return;
                }
                //has one child
                if (node.Left != null && node.Right == null)
                {
                    
                }
                else if (node.Left == null && node.Right != null)
                {

                }

            }
        }

        public V GetPerent(double x,NodeTree<V> T)
        {

        }
        public V Get(double x)
        {
            if(_root != null)
            {
                return Get(x, _root);
            }
            else
            {
                return default(V);
            }
           
        }
        private V Get(double x, NodeTree<V> t)
        {
            if (t == null)
            {
                return default(V);
            }
            if (x == t.KeyNode)
            {
                return t.ValueNode;
            }
            else if(x < t.KeyNode)
            {
                return Get(x, t.Left);
            }
            else
            {
                return Get(x, t.Right);
            }
        }
    }
}

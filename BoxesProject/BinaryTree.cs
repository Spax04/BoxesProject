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
            ///// IS _VALUE NULL????????
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
                {
                    t.Left = new NodeTree<V>(x);
                    
                }
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

        private void InOrder(NodeTree<V> t)
        {
            if(t != null)
            {
                InOrder(t.Left);
                Console.WriteLine(t.KeyNode + " ");
                InOrder(t.Right);
            }
        }

        public void addValue(NodeTree<V> t)
        {
            if(t.ValueNode.GetType() == typeof(BinaryTree<Box>))
            {
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
                //node has one child
                if (node.Left != null && node.Right == null)
                {
                    var perent = GetPerent(x) as NodeTree<V> ;
                    if(perent != null)
                    {
                        if(perent.Right == node)   // if perents RIGHT is a node we want to remove
                        {
                            perent.Right = node.Left;  // perents RIGHT becomes a nodes LEFT
                            
                        }
                        else
                        {
                            perent.Left = node.Left; //else perents LEFT becomes a nodes LEFT
                        }
                    }
                    return;
                }
                else if (node.Left == null && node.Right != null)
                {
                    var perent = GetPerent(x) as NodeTree<V>;
                    if (perent != null)
                    {
                        if (perent.Right == node)  // if perents LEFT is a node we want to remove
                        {
                            perent.Right = node.Right; // perents RIGHT becomes a nodes RIGHT
                        }
                        else
                        {
                            perent.Left = node.Right; // else perents LEFT becomes a nodes RIGHT
                        }
                    }
                    return;
                }

                //node has two children
                if (node.Left != null && node.Right != null)
                {
                    var minimum = GetMiniNode(node.Right);
                    var parant = GetPerent(x) as NodeTree<V>;

                    if (minimum.Right != null) // if minimum has a right node
                    {
                        var minPerent = GetPerent(minimum.KeyNode) as NodeTree<V>;  //find out his perent
                        minPerent.Left = minimum.Right; // minimums perent take a node of the minimum RIGHT node
                    }
                    minimum.Left = node.Left;    // 'minimum' takes the RIGHT and LEFT of the 'node'
                    minimum.Right = node.Right;

                    if (parant.Right == node)   // conecting the nodes perent with the 'minimum'
                        parant.Right = minimum;
                    else
                        parant.Left = minimum;
                    node = null;
                }

            }
        }
        public NodeTree<V> GetMiniNode(NodeTree<V> t)
        {
            if(t.Left == null)
            {
                return t;
            }
            return GetMiniNode(t.Left);
            
        }


        // Get the paerent of the object
        public V GetPerent(double x)
        {
            if(_root != null)
            {
                return GetPerent(x, _root);
            }
            else
            {
                return default(V);
            }
        }
        private V GetPerent(double x, NodeTree<V> t)
        {
            if (t == null)
            {
                return default(V);
            }
            if (t.Left != null && t.Left.KeyNode == x)
            {
                return t.ValueNode;
            }
            else if(t.Right != null && t.Right.KeyNode == x)
            {
                return t.ValueNode;
            }
            else if (x < t.KeyNode)
            {
                return GetPerent(x, t.Left);
            }
            else
            {
                return GetPerent(x, t.Right);
            }
        }

        //Get any object
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Collections;

namespace Boxes.Models
{
    public class BinaryTree<K, V> where K : IComparable<K>
    {
        public NodeTree<K,V> _root;
        static MathProvider<K> _math;
        public BinaryTree()
        {
            _root = null;
            if (typeof(K) == typeof(double))
                _math = new DoubleMathProvide() as MathProvider<K>;
            else if(typeof(K) == null)
            {
                throw new InvalidOperationException($"Type {typeof(K).ToString()} is not suported");
            }
        }
        /// <summary>
        /// Adding a new Node to the Binary Tree
        /// </summary>
        /// <param name="x"></param>
        /// <param name="BValue"></param>
        public void AddNode(K x,V BValue)
        {
            if (_root == null)
                _root = new NodeTree<K, V>(x, BValue);
            else
                AddNode(x, _root,BValue);
        }
        private void AddNode(K x, NodeTree<K, V> t,V BValue)
        {
            
            if (x.CompareTo(t.KeyNode) < 0)
            {
                if (t.Left == null)
                    t.Left = new NodeTree<K,V>(x,BValue);
                else
                    AddNode(x, t.Left,BValue);
            }
            else
            {
                if (t.Right == null)
                    t.Right = new NodeTree<K,V>(x,BValue);  
                else
                    AddNode(x, t.Right,BValue);
            }
        }

        /// <summary>
        /// Removing node from the Binary Tree
        /// </summary>
        /// <param name="x">Key of the Node</param>
        public void RemoveNode(K x)
        {
            var node = GetNode(x);
            var perent = GetPerent(x);
            if (node != null)
            {
                // best case - node dosent have any child nodes
                if(node.Left == null && node.Right == null)
                {
                    
                    if(perent.Left == node)
                    {
                        perent.Left = null;
                    }
                    else
                    {
                        perent.Right = null;
                    }
                    return;
                }
                //node has one child
                if (node.Left != null && node.Right == null)
                {
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
                    else
                    {
                        _root = node.Left;
                    }
                    return;
                }
                else if (node.Left == null && node.Right != null)
                {
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
                    else
                    {
                        _root = node.Right;
                    }
                    return;
                }

                //node has two children
                if (node.Left != null && node.Right != null)
                {
                    var minimum = GetMiniNode(node.Right);
                    var minPerent = GetPerent(minimum.KeyNode); //find out his perent
                    if (minimum.Right != null) // if minimum has a right node
                    {  
                        if(minPerent != node)
                        minPerent.Left = minimum.Right; // minimums perent take a node of the minimum RIGHT node
                    }
                    if(minimum.Left != minimum.Right)
                    minimum.Left = node.Left;                    // 'minimum' takes the RIGHT and LEFT of the 'node'
                    if (node.Right != minimum)
                        minimum.Right = node.Right;
                    else
                        node.Right = null; 
                    if(minPerent.Left == minimum)
                    {
                        minPerent.Left = null;
                    }
                    if(perent == null)  // perent is null when Node is a Root
                    {
                        _root = minimum;
                    }else if(perent.Right == node)
                        perent.Right = minimum;// conecting the nodes perent with the 'minimum'
                    else
                        perent.Left = minimum;
                }
            }
        }
        private NodeTree<K, V> GetMiniNode(NodeTree<K, V> t)
        {
            if(t.Left == null)
            {
                return t;
            }
            return GetMiniNode(t.Left);
            
        }

        /// <summary>
        /// Get the paerent of the chosen Node
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private NodeTree<K, V> GetPerent(K x)
        {
            if(_root != null)
            {
                return GetPerent(x, _root);
            }
            else
            {
                return null;
            }
        }
        private NodeTree<K, V> GetPerent(K x, NodeTree<K, V> t)
        {
            if (t == null)
            {
                return null;
            }
            if (t.Left != null && x.CompareTo(t.Left.KeyNode) == 0)
            {
                return t;
            }
            else if(t.Right != null && x.CompareTo(t.Right.KeyNode) == 0)
            {
                return t;
            }
            else if (x.CompareTo(t.KeyNode) < 0)
            {
                return GetPerent(x, t.Left);
            }
            else
            {
                return GetPerent(x, t.Right);
            }
        }

        /// <summary>
        /// Get Value of the Node
        /// </summary>
        /// <param name="x">Key of the Node</param>
        /// <returns></returns>
        public V GetValue(K x)
        {
            if (_root != null)
                return GetValue(x, _root);
            else
                return default(V);
            
           
        }
        private V GetValue(K x, NodeTree<K, V> t)
        {
            if(t == null)
            {
                return default(V);
            }
            if (x.CompareTo(t.KeyNode) == 0)
            {
                return t.ValueNode; // this returns null!!!  // it returns null bcs Valuee isnt created
            }
            else if(x.CompareTo(t.KeyNode) < 0)
            {
                return GetValue(x, t.Left);
            }
            else
            {
                return GetValue(x, t.Right);
            }
        }

        /// <summary>
        /// Getting a Node by Key
        /// </summary>
        /// <param name="x">Key of the Node</param>
        /// <returns></returns>
        public NodeTree<K, V> GetNode(K x)
        {
            if (_root != null)
                return GetNode(x, _root);
            else
                return null;
        }
        private NodeTree<K, V> GetNode(K x, NodeTree<K, V> t)
        {
            if (x.CompareTo(t.KeyNode) == 0)
            {
                return t; 
            }
            else if (x.CompareTo(t.KeyNode) < 0)
            {
                return GetNode(x, t.Left);
            }
            else
            {
                return GetNode(x, t.Right);
            }
        }
        /// <summary>
        /// Checking if Node exist
        /// </summary>
        /// <param name="x">Key of the Node</param>
        /// <returns>returns true if node exist</returns>
        public bool IfExist(K x)
        {
            NodeTree<K, V> t = GetNode(x);
            if(t == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Finding a closer try depents of the key 
        /// </summary>
        /// <param name="x">Key of the node</param>
        /// <param name="rangeOne">Minimum range</param>
        /// <param name="rangeTwo">Midle ragne</param>
        /// <param name="rangeThree">Max range</param>
        /// <returns></returns>
        public V FindCloserTree(K x,K rangeOne,K rangeTwo,K rangeThree)
        {
            V a = FindCloserTree(x, rangeOne, _root);
            if(a == null)
            {
                a = FindCloserTree(x, rangeTwo, _root);
                if(a == null)
                {
                    a = FindCloserTree(x, rangeThree, _root);
                }
            }
            return a;
        }
        private V FindCloserTree(K p,K prosent, NodeTree<K, V> t)
        { 
            K maxRange = _math.Multiply(p, prosent);

            if(t == null)
            {
                return default(V);
            }
            if (t.KeyNode.CompareTo(maxRange) <=0  && t.KeyNode.CompareTo(p) > 0)
            {
                return t.ValueNode;
            }else if(t.KeyNode.CompareTo(maxRange) > 0)
            {
                return FindCloserTree(p,prosent, t.Left);
            }
            else
            {
                return FindCloserTree(p, prosent, t.Right);
            }
        }

        public IEnumerable GetEnumeratorValue(Order ord)
        {
            switch (ord)
            {
                case Order.inOrder:
                    return InOrderValue(_root);
                case Order.preOrder:
                    return PreOrderValue(_root);
                case Order.postOrder:
                    return PostOrderValue(_root);
                default:
                    return default;
            }
        }
        public IEnumerable GetEnumerator(Order ord)
        {
            switch (ord)
            {
                case Order.inOrder:
                    return InOrderNode(_root);
                case Order.preOrder:
                    return PreOrderNode(_root);
                case Order.postOrder:
                    return PostOrderNode(_root);
                default:
                    return default;
            }
        }

        // InOrder ---------------
        private IEnumerable InOrderValue(NodeTree<K,V> node)
        {
            if (node != null)
            {
                foreach (V val in InOrderValue(node.Left))
                    yield return val;
                yield return node.ValueNode;
                foreach (V val in InOrderValue(node.Right))
                    yield return val;
            }
        }
        private IEnumerable InOrderNode(NodeTree<K, V> node)
        {
            if (node != null)
            {
                foreach (NodeTree<K, V> val in InOrderNode(node.Left))
                    yield return val;
                yield return node;
                foreach (NodeTree<K, V> val in InOrderNode(node.Right))
                    yield return val;
            }
        }
        // ------------------

        // PreOrder ----------------
        private IEnumerable PreOrderValue(NodeTree<K, V> node)
        {
            if (node != null)
            {
                yield return node.ValueNode;
                foreach (V val in PreOrderValue(node.Left))
                    yield return val;
                foreach (V val in PreOrderValue(node.Right))
                    yield return val;
            }
        }
        private IEnumerable PreOrderNode(NodeTree<K, V> node)
        {
            if (node != null)
            {
                yield return node;
                foreach (V val in PreOrderNode(node.Left))
                    yield return val;
                foreach (V val in PreOrderNode(node.Right))
                    yield return val;
            }
        }
        //------------------
        private IEnumerable PostOrderValue(NodeTree<K, V> node)
        {
            if (node != null)
            {
                foreach (V val in PostOrderValue(node.Left))
                    yield return val;
                foreach (V val in PostOrderValue(node.Right))
                    yield return val;
                yield return node.ValueNode;
            }
        }
        private IEnumerable PostOrderNode(NodeTree<K, V> node)
        {
            if (node != null)
            {
                foreach (V val in PostOrderNode(node.Left))
                    yield return val;
                foreach (V val in PostOrderNode(node.Right))
                    yield return val;
                yield return node;
            }
        }

        public override string ToString()
        {
            return $"Tree's Node Key : {_root.KeyNode}";
        }
    }
}

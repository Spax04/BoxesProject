using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxes.Models
{
    public class BinaryTree<V>
    {
        public NodeTree<V> _root;
        
        public BinaryTree()
        {
            _root = null;
        }

        public void AddNode(double x,V BValue)
        {
            if (_root == null)
                _root = new NodeTree<V>(x,BValue);
            else
                AddNode(x, _root,BValue);
        }

        private void AddNode(double x, NodeTree<V> t,V BValue)
        {
            if (x < t.KeyNode)
            {
                if (t.Left == null)
                {
                    t.Left = new NodeTree<V>(x,BValue);
                    
                }
                else
                    AddNode(x, t.Left,BValue);
            }
            else
            {
                if (t.Right == null)
                {
                    t.Right = new NodeTree<V>(x,BValue);
                    
                }
                else
                    AddNode(x, t.Right,BValue);
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
                    return;
                }

                //node has two children
                if (node.Left != null && node.Right != null)
                {
                    var minimum = GetMiniNode(node.Right);
                    var minPerent = GetPerent(minimum.KeyNode); //find out his perent
                    if (minimum.Right != null) // if minimum has a right node
                    {  
                        minPerent.Left = minimum.Right; // minimums perent take a node of the minimum RIGHT node
                    }
                    minimum.Left = node.Left;                    // 'minimum' takes the RIGHT and LEFT of the 'node'
                    if(node.Right != minimum)
                        minimum.Right = node.Right;
                    if(minPerent.Left == minimum)
                    {
                        minPerent.Left = null;
                    }

                    if (perent.Right == node)   // conecting the nodes perent with the 'minimum'
                        perent.Right = minimum;
                    else
                        perent.Left = minimum;
                   
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
        public NodeTree<V> GetPerent(double x)
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
        private NodeTree<V> GetPerent(double x, NodeTree<V> t)
        {
            if (t == null)
            {
                return null;
            }
            if (t.Left != null && t.Left.KeyNode == x)
            {
                return t;
            }
            else if(t.Right != null && t.Right.KeyNode == x)
            {
                return t;
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
        public V GetValue(double x)
        {
            if (_root != null)
                return GetValue(x, _root);
            else
                return default(V);
            
           
        }

        private V GetValue(double x, NodeTree<V> t)
        {
            if(t == null)
            {
                return default(V);
            }
            if (x == t.KeyNode)
            {
                return t.ValueNode; // this returns null!!!  // it returns null bcs Valuee isnt created
            }
            else if(x < t.KeyNode)
            {
                return GetValue(x, t.Left);
            }
            else
            {
                return GetValue(x, t.Right);
            }
        }

        public NodeTree<V> GetNode(double x)
        {
            if (_root != null)
                return GetNode(x, _root);
            else
                return null;
        }

        private NodeTree<V> GetNode(double x, NodeTree<V> t)
        {
            if (x == t.KeyNode)
            {
                return t; 
            }
            else if (x < t.KeyNode)
            {
                return GetNode(x, t.Left);
            }
            else
            {
                return GetNode(x, t.Right);
            }
        }

        public bool IfExist(double x)
        {
            NodeTree<V> t = GetNode(x);
            if(t == null)
            {
                return false;
            }
            return true;
        }

        public bool find(double x)
        {
            return find(x, _root);
        }

        private bool find(double x, NodeTree<V> t)
        {
            if (t == null)
                return false;
            if (t.KeyNode == x)
                return true;
            return find(x, t.Left) || find(x, t.Right);
        }

        public V FindCloserTree(double x)
        {
            V a = FindCloserTree(x,0.5,_root);
            if(a == null)
            {
                a = FindCloserTree(x,0.75,_root);
                if(a == null)
                {
                    a = FindCloserTree(x, 2, _root);
                }
            }
            return a;
        }

        public V FindCloserTree(double x,double prosent, NodeTree<V> t)
        {
            double maxRange = x;
            maxRange += x * prosent;

            if(t == null)
            {
                return default(V);
            }
            if (t.KeyNode < maxRange && t.KeyNode > x)
            {
                return t.ValueNode;
            }else if(t.KeyNode > maxRange)
            {
                return FindCloserTree(x,prosent, t.Left);
            }
            else
            {
                return FindCloserTree(x, prosent, t.Right);
            }
            
        }
    }
}

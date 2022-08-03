using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxesProject
{
    public class TreeMenenger

    {
        private BinaryTree<BinaryTree<Box>> _tree;

        public TreeMenenger()
        {
            _tree = new BinaryTree<BinaryTree<Box>>();
            
           
        }

        public BinaryTree<BinaryTree<Box>> Tree { get { return _tree; } set { _tree = value; } }
        public void AddNodeAndValue(double x)
        {
            _tree.AddNode(x);
           
        }

        public void AddValue(double x)
        {
            NodeTree<BinaryTree<Box>> t = _tree.Get(x);  //why t is null???
            t.ValueNode = new BinaryTree<Box>();
        }

        public void AddInnerNodeAndValue(double x, double y)
        {
            NodeTree<BinaryTree<Box>> a = _tree.Get(x);
            a.ValueNode.AddNode(y);
        }

        public void AddInnerValue(NodeTree<Box> inner)
        {
            inner.ValueNode = new Box();
        }

        public NodeTree<Box> GetInnerNode(double x,double y)
        {
            NodeTree<BinaryTree<Box>> a = _tree.Get(x);
           NodeTree<Box> b = a.ValueNode.Get(y);
            return b;
        }
    }
}

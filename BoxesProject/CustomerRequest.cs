using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxesProject
{
    public class CustomerRequest
    {
        BinaryTree<BinaryTree<Box>> tree;

        public CustomerRequest()
        {
            tree = new BinaryTree<BinaryTree<Box>>();
            tree._root.ValueNode = new BinaryTree<Box>();
            tree.AddNode(5);
            tree.AddNode(6);
            tree.AddNode(4);
            addInnerNode(4,5);
        }

        public void addInnerNode(double x,double y)
        {
            var a = tree.Get(x);
            a.AddNode(y);
        }

        public NodeTree<Box> GetInner(double x,double y)
        {
            var a = tree.Get(x);
            return default(NodeTree<Box>);
          
        }

       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxesProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<BinaryTree<Box>> tree = new BinaryTree<BinaryTree<Box>>();

            tree.AddNode(5);
            tree.AddNode(6);
            tree.AddNode(4);
            tree.InOrder();

            tree._root.ValueNode.AddNode(5);
        }

        // Tree<tree> => tree.Node<tree> => tree.node<box> 
    }
}

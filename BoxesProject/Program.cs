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
            tree.AddNode(8);
            tree.AddNode(10);
            tree.AddNode(3);
            tree.AddNode(4.5);
            tree.AddNode(4.3);
            tree.AddNode(4.7);
            tree.AddNode(4.8);
            tree.AddNode(4.6);
            tree.InOrder();
            Console.WriteLine("====================");
           tree.RemoveNode(4.5);
            tree.InOrder();
        }

        // Tree<tree> => tree.Node<tree> => tree.node<box> 
    }
}

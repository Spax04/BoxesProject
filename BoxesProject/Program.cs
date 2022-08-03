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
            TreeMenenger tree = new TreeMenenger();
            tree.AddNode(5);
            tree.AddNode(6);
            tree.AddNode(4);

            //root tree
            tree.AddInnerNode(5, 3);
            tree.AddInnerNode(5, 4);
            tree.AddInnerNode(5, 2);

            // left tree
            tree.AddInnerNode(4, 3);
            tree.AddInnerNode(4, 4);
            tree.AddInnerNode(4, 2);

            // right tree
            tree.AddInnerNode(6, 3);
            tree.AddInnerNode(6, 4);
            tree.AddInnerNode(6, 2);

            tree.AddBox(6,2);
            tree.AddBox(6, 2);
            tree.AddBox(6, 2);

            tree.testPrint(6,2);

            /*tree.AddNodeAndValue(5);
            
            tree.AddNodeAndValue(6);
            tree.AddNodeAndValue(4);
            tree.AddValue(5);
            tree.Tree.InOrder();*/


            /*  Console.WriteLine("====================");
             tree.RemoveNode(4.5);
              tree.InOrder();*/


        }

        // Tree<tree> => tree.Node<tree> => tree.node<box> 
    }
}

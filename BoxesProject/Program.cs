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

            tree.AddNodeAndValue(5);
            
            tree.AddNodeAndValue(6);
            tree.AddNodeAndValue(4);
            tree.AddValue(5);
            tree.Tree.InOrder();

          
          /*  Console.WriteLine("====================");
           tree.RemoveNode(4.5);
            tree.InOrder();*/

            
        }

        // Tree<tree> => tree.Node<tree> => tree.node<box> 
    }
}

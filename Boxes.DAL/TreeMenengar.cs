using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boxes.Models;
using System.Threading.Tasks;

namespace Boxes.DAL
{
    public class TreeMenengar 
    {
        BinaryTree<double, BinaryTree<double, Box>> Tree;
        public TreeMenengar(BinaryTree<double,BinaryTree<double,Box>> tree)
        {
            Tree = tree;
        }

        /// <summary>
        /// Adding node to the tree
        /// Node contains BinaryTree
        /// </summary>
        /// <param name="x"> width of the box</param>
        public void AddTreeNode(double x)
        {
            Tree.AddNode(x, new BinaryTree<double, Box>());
        }

        /// <summary>
        /// Adding inner node it will contains <see cref="Box"/>
        /// </summary>
        /// <param name="x">width of the box</param>
        /// <param name="y">height of the box</param>
        public void AddInnerBTree(double x, double y,int count)
        {
            var a = Tree.GetValue(x);
            a.AddNode(y, new Box(x,y,count));
        }

        /// <summary>
        /// Method gets Inner Binary tree by width
        /// </summary>
        /// <param name="x">width of the box</param>
        /// <returns></returns>
        public BinaryTree<double, Box> GetInnerBTree(double x) // geting inner tree
        {
            return Tree.GetValue(x);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boxes.Models;
using System.Threading.Tasks;

namespace Boxes.DAL
{
    public class TreeRepository 
    {
        private static DataMock _context = DataMock.Instans;

        /// <summary>
        /// Adding node to the <see cref="DataMock.Tree"/>
        /// Node contains BinaryTree
        /// </summary>
        /// <param name="x"> width of the box</param>
        public void AddTreeNode(double x)
        {
            _context.Tree.AddNode(x, new BinaryTree<Box>());
        }

        /// <summary>
        /// Adding inner node it will contains <see cref="Box"/>
        /// </summary>
        /// <param name="x">width of the box</param>
        /// <param name="y">height of the box</param>
        public void AddInnerNode(double x, double y,int count)
        {
            var a = _context.Tree.GetValue(x);
            a.AddNode(y, new Box(count));
        }

        /// <summary>
        /// Method gets Inner Binary tree by width
        /// </summary>
        /// <param name="x">width of the box</param>
        /// <returns></returns>
        public BinaryTree<Box> GetInnerNode(double x) // geting inner tree
        {
            return _context.Tree.GetValue(x);
        }
    }
}

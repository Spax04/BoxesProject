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
        public void AddNode(double x)
        {
            _tree.AddNode(x,new BinaryTree<Box>());
        }

        public void AddInnerNode(double x, double y)
        {
            var a = _tree.Get(x);
            a.AddNode(y,new Box());
        }

        public void AddBox(double x,double y)
        {
            Box box = GetBox(x,y);
            box.AddBox();
        }

        public void testPrint(double x,double y)
        {
            Box b = GetBox(x,y);
            Console.WriteLine(b); 
        }

        public Box GetBox(double x, double y)
        {
            BinaryTree<Box> a = _tree.Get(x) ;
            Box b = a.Get(y);
            return b;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boxes.Models;
using System.Threading.Tasks;

namespace Boxes.DAL
{
    public class BoxRepository : IRepository<Box>
    {
        private BinaryTree<BinaryTree<Box>> _tree;
        private TreeMenengar _treeMenengar;
        private static BoxRepository _instans;
        public static BoxRepository Instans
        {
            get
            {
                if (_instans == null)
                {
                    _instans = new BoxRepository();
                }

                return _instans;
            }
        }
        private BoxRepository()
        {
            _tree = new BinaryTree<BinaryTree<Box>>();
            _treeMenengar = new TreeMenengar(_tree);
            Init();
        }

       
        public void Add(double x, double y, int count)
        {
            var a = _treeMenengar.GetInnerBTree(x);
            var b = GetItem(x, y);

            if (a == null)
                _treeMenengar.AddTreeNode(x);
            if (b == null)
                _treeMenengar.AddInnerBTree(x, y, count);
            else
                b.FillBoxes(count);  // add 'count' boxes if a box already exist;
        }


        private Box RequestItemFromDB(double x,double y)
        {
            var a = _treeMenengar.GetInnerBTree(x);
            if(a == null)
            {
                a = _tree.FindCloserTree(x);
                if(a== null)
                {
                    Console.WriteLine("Unsuccessful attempt to find a suitable box.");
                    return null;
                }
                Console.WriteLine("We didnt find the WIDTH you asked. Most closer WIDTH is: "+ a._root.ValueNode.Width );
            }

            var b = GetItem(a._root.ValueNode.Width, y);
            if (b == null)
            {
                b = a.FindCloserTree(y);
                if(b == null)
                {
                    Console.WriteLine("Unsuccessful attempt to find a suitable box.");
                    return null;
                }
                Console.WriteLine("We didnt find the HEIGHT you asked. Most closer HEIGHT is: " + b.Height);
            }
            return b;
        }
        public List<Box> RequestItemFromDB(double x, double y,int count)
        {
            List<Box> bList = new List<Box>();
            Box b = RequestItemFromDB(x,y);
            
            if (b == null)
            {
                Console.WriteLine("There are not enought boxes for your size.");
                return null;
            }
            bList.Add(b);
            Console.WriteLine($"Box you have requested:\n{b}");
            int leftRequest = b.RequestBox(count);
            if (leftRequest > 0 )
            {
                Console.WriteLine("There is a last one box in stack. The box was deleted");
                RemoveBox(b.Width,b.Height);
                bList.AddRange(RequestItemFromDB(b.Width,b.Height,leftRequest));
            }
            return bList;
        }

        public void RefillBoxes(double x, double y, int count)
        {
            Box a = GetItem(x, y);
            if (a != null) // if Box exist it will be refill
            {
                a.FillBoxes(count);
            }
            else //else a new box size was created widt max amount
            {
                _treeMenengar.AddInnerBTree(x, y, count);
            }
        }


        // Printings -----------------
        public void PrintDitales(double x, double y) 
        {
            Box b = GetItem(x, y);
            Console.WriteLine(b);
        }

        public void PrintWidths()
        {
            _tree.InOrder();
        }

        public void PrintHeights(double x)
        {
            BinaryTree<Box> b = _treeMenengar.GetInnerBTree(x);
            Console.WriteLine($"Box width: {x}. Heights: ");
            b.InOrder();
        }

        // Private ------------
        public Box GetItem(double x, double y)
        {
            BinaryTree<Box> a = _treeMenengar.GetInnerBTree(x);

            if (a == null) return null;
            return a.GetValue(y);
        }

        private void RemoveBox(double x,double y)
        {
            Box box = GetItem(x, y);
            if(box != null)
            {
                var a = _treeMenengar.GetInnerBTree(box.Width);
                a.RemoveNode(box.Height);
            }
        }

        private void Init()
        {
            //tree Width 15x?
            Add(15, 15, 5);
            Add(15, 20, 5);
            Add(15, 10, 5);
            Add(15,5, 5);
            Add(15, 8, 5);
            Add(15, 16, 5);
            Add(15, 22, 5);

            //tree Width 20x?
            Add(20, 15, 5);
            Add(20, 20, 5);
            Add(20, 10, 5);
            Add(20, 5, 5);
            Add(20, 8, 5);
            Add(20, 16, 5);
            Add(20, 22, 5);

            //tree Width 9x?
            Add(9, 15, 5);
            Add(9, 20, 5);
            Add(9, 10, 5);
            Add(9, 5, 5);
            Add(9, 8, 5);
            Add(9, 16, 5);
            Add(9, 22, 5);

            //tree Width 6x?
            Add(6, 15, 5);
            Add(6, 20, 5);
            Add(6, 10, 5);
            Add(6, 5, 5);
            Add(6, 8, 5);
            Add(6, 16, 5);
            Add(6, 22, 5);

            //tree Width 4x?
            Add(4, 15, 5);
            Add(4, 20, 5);
            Add(4, 10, 5);
            Add(4, 5, 5);
            Add(4, 8, 5);
            Add(4, 16, 5);
            Add(4, 22, 5);

            //tree Width 3x?
            Add(3, 15, 5);
            Add(3, 20, 5);
            Add(3, 10, 5);
            Add(3, 5, 5);
            Add(3, 8, 5);
            Add(3, 16, 5);
            Add(3, 22, 5);

            //tree Width 5x?
            Add(5, 15, 5);
            Add(5, 20, 5);
            Add(5, 10, 5);
            Add(5, 5, 5);
            Add(5, 8, 5);
            Add(5, 16, 5);
            Add(5, 22, 5);

            //tree Width 7x?
            Add(7, 15, 5);
            Add(7, 20, 5);
            Add(7, 10, 5);
            Add(7, 5, 5);
            Add(7, 8, 5);
            Add(7, 16, 5);
            Add(7, 22, 5);

            //tree Width 8x?
            Add(8, 15, 5);
            Add(8, 20, 5);
            Add(8, 10, 5);
            Add(8, 5, 5);
            Add(8, 8, 5);
            Add(8, 16, 5);
            Add(8, 22, 5);

            //tree Width 12x?
            Add(12, 15, 5);
            Add(12, 20, 5);
            Add(12, 10, 5);
            Add(12, 5, 5);
            Add(12, 8, 5);
            Add(12, 16, 5);
            Add(12, 22, 5);

            //tree Width 13x?
            Add(13, 15, 5);
            Add(13, 20, 5);
            Add(13, 10, 5);
            Add(13, 5, 5);
            Add(13, 8, 5);
            Add(13, 16, 5);
            Add(13, 22, 5);

            //tree Width 13.5x?
            Add(13.5, 15, 5);
            Add(13.5, 20, 5);
            Add(13.5, 10, 5);
            Add(13.5, 5, 5);
            Add(13.5, 8, 5);
            Add(13.5, 16, 5);
            Add(13.5, 22, 5);

            //tree Width 12.5x?
            Add(12.5, 15, 5);
            Add(12.5, 20, 5);
            Add(12.5, 10, 5);
            Add(12.5, 5, 5);
            Add(12.5, 8, 5);
            Add(12.5, 16, 5);
            Add(12.5, 22, 5);

            //tree Width 10.5x?
            Add(10.5, 15, 5);
            Add(10.5, 20, 5);
            Add(10.5, 10, 5);
            Add(10.5, 5, 5);
            Add(10.5, 8, 5);
            Add(10.5, 16, 5);
            Add(10.5, 22, 5);

            //tree Width 10x?
            Add(10, 15, 5);
            Add(10, 20, 5);
            Add(10, 10, 5);
            Add(10, 5, 5);
            Add(10, 8, 5);
            Add(10, 16, 5);
            Add(10, 22, 5);

            //tree Width 11x?
            Add(11, 15, 5);
            Add(11, 20, 5);
            Add(11, 10, 5);
            Add(11, 5, 5);
            Add(11, 8, 5);
            Add(11, 16, 5);
            Add(11, 22, 5);

            // Right tree-------------

            //tree Width 20x?
            Add(20, 15, 5);
            Add(20, 20, 5);
            Add(20, 10, 5);
            Add(20, 5, 5);
            Add(20, 8, 5);
            Add(20, 16, 5);
            Add(20, 22, 5);

            //tree Width 25x?
            Add(25, 15, 5);
            Add(25, 20, 5);
            Add(25, 10, 5);
            Add(25, 5, 5);
            Add(25, 8, 5);
            Add(25, 16, 5);
            Add(25, 22, 5);

            //tree Width 28x?
            Add(28, 15, 5);
            Add(28, 20, 5);
            Add(28, 10, 5);
            Add(28, 5, 5);
            Add(28, 8, 5);
            Add(28, 16, 5);
            Add(28, 22, 5);

            //tree Width 30x?
            Add(30, 15, 5);
            Add(30, 20, 5);
            Add(30, 10, 5);
            Add(30, 5, 5);
            Add(30, 8, 5);
            Add(30, 16, 5);
            Add(30, 22, 5);

            //tree Width 26x?
            Add(26, 15, 5);
            Add(26, 20, 5);
            Add(26, 10, 5);
            Add(26, 5, 5);
            Add(26, 8, 5);
            Add(26, 16, 5);
            Add(26, 22, 5);

            //tree Width 22x?
            Add(22, 15, 5);
            Add(22, 20, 5);
            Add(22, 10, 5);
            Add(22, 5, 5);
            Add(22, 8, 5);
            Add(22, 16, 5);
            Add(22, 22, 5);
            //tree Width 22x?
            Add(23, 15, 5);
            Add(23, 20, 5);
            Add(23, 10, 5);
            Add(23, 5, 5);
            Add(23, 8, 5);
            Add(23, 16, 5);
            Add(23, 22, 5);

            //tree Width 17x?
            Add(17, 15, 5);
            Add(17, 20, 5);
            Add(17, 10, 5);
            Add(17, 5, 5);
            Add(17, 8, 5);
            Add(17, 16, 5);
            Add(17, 22, 5);

            //tree Width 18x?
            Add(18, 15, 5);
            Add(18, 20, 5);
            Add(18, 10, 5);
            Add(18, 5, 5);
            Add(18, 8, 5);
            Add(18, 16, 5);
            Add(18, 22, 5);

            //tree Width 19x?
            Add(19, 15, 5);
            Add(19, 20, 5);
            Add(19, 10, 5);
            Add(19, 5, 5);
            Add(19, 8, 5);
            Add(19, 16, 5);
            Add(19, 22, 5);

            //tree Width 16x?
            Add(16, 15, 5);
            Add(16, 20, 5);
            Add(16, 10, 5);
            Add(16, 5, 5);
            Add(16, 8, 5);
            Add(16, 16, 5);
            Add(16, 22, 5);
        }
    }
}

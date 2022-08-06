using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boxes.Models;
using System.Threading.Tasks;

namespace Boxes.DAL
{
    public class BoxRepository
    {
        private static DataMock _context = DataMock.Instans;

        TreeRepository _treeRepository = new TreeRepository();
        public void AddBoxToDB(double x, double y, int count)
        {
            var a = _treeRepository.GetInnerBTree(x);
            var b = GetBox(x, y);

            if (a == null)
                _treeRepository.AddTreeNode(x);
            if (b == null)
                _treeRepository.AddInnerBTree(x, y, count);
            else
                b.AddBox(count);  // add 'count' boxes if a box already exist;
        }

        public Box GetBox(double x, double y)
        {
            BinaryTree<Box> a = _treeRepository.GetInnerBTree(x);

            if (a == null) return null;
            return a.GetValue(y);
        }

        public void RemoveBox(double x, double y)
        {
            Box box = GetBox(x, y);
            if (box.RequestBox())
            {
                var a = _treeRepository.GetInnerBTree(x);
                a.RemoveNode(y);
            }
        }

        public void CustomreBoxRequest(double x,double y)
        {
            var a = _treeRepository.GetInnerBTree(x);
            if(a == null)
            {
                a = _context.Tree.FindCloserTree(x);
                Console.WriteLine("We didnt find the WIDTH you asked. Most closer WIDTH is: " + a._root.KeyNode);
            }

            var b = GetBox(x, y);
            if (b == null)
            {
                b = a.FindCloserTree(y);
                Console.WriteLine("We didnt find the HEIGHT you asked. Most closer HEIGHT is: " + b.Height);
            }

            
            b.RequestBox();
            Console.WriteLine(b);
        }

        public void RefillBoxes(double x, double y, int count)
        {
            Box a = GetBox(x, y);
            if (a != null) // if Box exist it will be refill
            {
                a.FillBoxes(count);
            }
            else //else a new box size was created widt max amount
            {
                _treeRepository.AddInnerBTree(x, y, count);
            }
        }


        // Printings -----------------
        public void PrintDitales(double x, double y) 
        {
            Box b = GetBox(x, y);
            Console.WriteLine(b);
        }

        public void PrintWidths()
        {
            _context.Tree.InOrder();
        }

        public void PrintHeights(double x)
        {
            BinaryTree<Box> b = _treeRepository.GetInnerBTree(x);
            b.InOrder();
        }
    }
}

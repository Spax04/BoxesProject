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

        TreeMenengar _treeMenengar = new TreeMenengar();
        public void AddBoxToDB(double x, double y, int count)
        {
            var a = _treeMenengar.GetInnerBTree(x);
            var b = GetBox(x, y);

            if (a == null)
                _treeMenengar.AddTreeNode(x);
            if (b == null)
                _treeMenengar.AddInnerBTree(x, y, count);
            else
                b.AddBox(count);  // add 'count' boxes if a box already exist;
        }


        private Box CustomreBoxRequest(double x,double y)
        {
            var a = _treeMenengar.GetInnerBTree(x);
            if(a == null)
            {
                a = _context.Tree.FindCloserTree(x);
                if(a== null)
                {
                    Console.WriteLine("Unsuccessful attempt to find a suitable box.");
                    return null;
                }
                Console.WriteLine("We didnt find the WIDTH you asked. Most closer WIDTH is: "+ a._root.ValueNode.Width );
            }

            var b = GetBox(a._root.ValueNode.Width, y);
            if (b == null)
            {
                b = a.FindCloserTree(y);
                if(b== null)
                {
                    Console.WriteLine("Unsuccessful attempt to find a suitable box.");
                    return null;
                }
                Console.WriteLine("We didnt find the HEIGHT you asked. Most closer HEIGHT is: " + b.Height);
            }

            
            return b;
           
        }
        public void CustomreBoxRequest(double x, double y,int count)
        {
            Box b = CustomreBoxRequest(x,y);
            if (b == null)
            {
                Console.WriteLine("There are not enought boxes for your size.");
                return;
            }
            Console.WriteLine(b);
            int leftRequest = b.RequestBox(count);
            if (leftRequest > 0 )
            {
                Console.WriteLine("There is a last one box in stack. The box was deleted");
                RemoveBox(b.Width,b.Height);
                CustomreBoxRequest(b.Width,b.Height,leftRequest);
            }
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
                _treeMenengar.AddInnerBTree(x, y, count);
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
            BinaryTree<Box> b = _treeMenengar.GetInnerBTree(x);
            b.InOrder();
        }

        // Private ------------
        private Box GetBox(double x, double y)
        {
            BinaryTree<Box> a = _treeMenengar.GetInnerBTree(x);

            if (a == null) return null;
            return a.GetValue(y);
        }

        private void RemoveBox(double x,double y)
        {
            Box box = GetBox(x, y);
            if(box != null)
            {
                var a = _treeMenengar.GetInnerBTree(box.Width);
                a.RemoveNode(box.Height);
            }
            
        }
    }
}

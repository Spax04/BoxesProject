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
        public void AddBoxToDB(double x, double y)
        {
            Box box = GetBox(x, y); // checking if a box already exist
            if(box == null) // if size doesnt exist, db creats a new size
            {
                var a = _context.Tree.GetNode(x);
                if(a == null)
                {
                    _treeRepository.AddTreeNode(x);
                }
                
                _treeRepository.AddInnerNode(x,y);
            }
            else
            {
                box.AddBox();  // add +1 box if a box already exist;
            } 
        }

        public Box GetBox(double x, double y)
        {
            BinaryTree<Box> a = _treeRepository.GetInnerNode(x);
            return a.GetValue(y);
        }

        public void RemoveBox(double x, double y)
        {
            Box box = GetBox(x, y);
            if (box.RequestBox())
            {
                var a = _treeRepository.GetInnerNode(x);
                a.RemoveNode(y);
            }
        }

        public void RefillBoxes(double x, double y)
        {
            Box a = GetBox(x, y);
            if (a != null) // if Box exist it will be refill
            {
                a.FillBoxes();
            }
            else //else a new box size was created widt max amount
            {
                _treeRepository.AddInnerNode(x, y);
            }
        }

        public void testPrint(double x, double y) // DONT FORGET REMOVE
        {
            Box b = GetBox(x, y);
            Console.WriteLine(b);
        }
    }
}

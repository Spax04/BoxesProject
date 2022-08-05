using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boxes.Models;
using System.Threading.Tasks;

namespace Boxes.DAL
{
    public class DataMock
    {
        private static DataMock _instans;
        public static  DataMock Instans
        {
            get 
            { 
                if( _instans == null)
                {
                    _instans = new DataMock();
                }
                
                return _instans; 
            }
        }

        private BinaryTree<BinaryTree<Box>> _tree;
        private DataMock()
        {
            _tree = new BinaryTree<BinaryTree<Box>>();
        }
        public BinaryTree<BinaryTree<Box>> Tree { get { return _tree; } set { _tree = value; } }

        public void Init()
        {
            _tree.AddNode(5,new BinaryTree<Box>());
            _tree.AddNode(6, new BinaryTree<Box>());
            _tree.AddNode(4, new BinaryTree<Box>());
        }
            
        
    }
}

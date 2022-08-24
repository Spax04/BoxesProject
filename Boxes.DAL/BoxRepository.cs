using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boxes.Models;
using System.Threading.Tasks;
using System.Collections;
using Boxes.Conf;
using System.Windows.Threading;

namespace Boxes.DAL
{
    public class BoxRepository : IRepository<Box>
    {
        private static Configurations _config = Configurations.Instans;
        private BinaryTree<double,BinaryTree<double,Box>> _tree;
        private TreeMenengar _treeMenengar;
        private static BoxRepository _instans;
        private int MAX_EXPIRE_DAYS = _config.Data.EXPIRE_DAYS;
        DispatcherTimer timer;

        public IEnumerable Boxes { get { return GetAllBoxes(); } }
        private CustomQueue<Box> _queue;

        public CustomQueue<Box> Queue { get { return _queue; } }
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
            _tree = new BinaryTree<double,BinaryTree<double,Box>>();
            _treeMenengar = new TreeMenengar(_tree);
            _queue = new CustomQueue<Box>();
            Init();
            TimerCheck();
        }

        /// <summary>
        /// Basic method for adding new Box to DB. If box already exist - count updates
        /// </summary>
        /// <param name="x">Box's width</param>
        /// <param name="y">Box's height</param>
        /// <param name="count">How many boxes to add</param>
        public void Add(double x, double y, int count)
        {
            var a = _treeMenengar.GetInnerBTree(x);
            var b = GetItem(x, y);

            if (a == null)
                _treeMenengar.AddTreeNode(x);
            if (b == null)
            {
                b = _treeMenengar.AddInnerBTree(x, y, count);
                _queue.AddQNode(b.NodeQueue);
            }
            else
                b.FillBoxes(count);  // add 'count' boxes if a box already exist;
        }
        /// <summary>
        /// Basic method for requesting Box from DB by width and height. The method is private by defuelt
        /// </summary>
        /// <param name="x">Box's width</param>
        /// <param name="y">Box's height</param>
        /// <returns></returns>
        private Box RequestItemFromDB(double x,double y)
        {
            bool suggestNewBox;
            var a = _treeMenengar.GetInnerBTree(x);
            if(a == null)
            {
                Console.WriteLine("We didnt find the WIDTH you asked. Do you want bigger size? (True/False)");
                suggestNewBox = Convert.ToBoolean(Console.ReadLine());
                if (suggestNewBox)
                {
                    a = _tree.FindCloserTree(x, 1.4, 1.75, 2);
                    if (a == null)
                    {
                        Console.WriteLine("Unsuccessful attempt to find a suitable box.");
                        return null;
                    }
                    Console.WriteLine("Most closer WIDTH is: " + a._root.ValueNode.Width);
                }
                else
                {
                    return null;
                }
            }

            var b = GetItem(a._root.ValueNode.Width, y);
            if (b == null)
            {
                Console.WriteLine("We didnt find the HEIGHT you asked. Do you want bigger size? (True/False)");
                suggestNewBox = Convert.ToBoolean(Console.ReadLine());
                if (suggestNewBox)
                {
                    b = a.FindCloserTree(y, 1.4, 1.75, 2);
                    if (b == null)
                    {
                        Console.WriteLine("Unsuccessful attempt to find a suitable box.");
                        return null;
                    }
                    Console.WriteLine("Most closer HEIGHT is: " + b.Height);
                }
                else
                {
                    return null;
                }
            }
            if (b != null)
            {
                _queue.ReplaceQNode(b.NodeQueue);
            }
            // ALEX -- fix putting QNode to the end of the queue

            return b;
        }

        /// <summary>
        /// Basic method for requesting amount of boxes. Method suggest to request another size if current size doesnt exist. Delete node if amount equels to 0.
        /// </summary>
        /// <param name="x">Box's width</param>
        /// <param name="y">Box's height</param>
        /// <param name="count">How many boxes to get</param>
        /// <returns></returns>
        public IEnumerable RequestItemFromDB(double x, double y,int count)
        {
            Box b = RequestItemFromDB(x,y);
            if (b == null)
            {
                Console.WriteLine("There is no box.");
                yield break;
            }
            else
            {

                Console.WriteLine($"Box you have requested:\n{b}");
                int leftRequest = b.RequestBox(count);
                if (leftRequest > 0)
                {
                    Console.WriteLine("There is a last one box in stack. The box was deleted");
                    RemoveBox(b.Width, b.Height);
                }

                if (leftRequest != 0)
                {
                    foreach (Box nb in RequestItemFromDB(x, y, leftRequest))
                        yield return nb;
                } 
            }


        }

        /// <summary>
        /// Update amount boxes. Returns exception if <see cref="Box"/> doestns exist
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="count"></param>
        /// <exception cref="ArgumentException"></exception>
        public void RefillBoxes(double x, double y, int count)
        {
            Box a = GetItem(x, y);
            if (a != null) // if Box exist it will be refill
                a.FillBoxes(count);
            else
                throw new ArgumentException("The Box doesn't exist!");
        }

        #region Print Methods Region
        public void Print(IEnumerable items)
        {
            foreach (var a in items)
            {
                Console.WriteLine(a);
            }
        }

        public void PrintInnerTrees(double x)
        {
            Print(GetBoxesInTree(x));
        }

        public void PrintTrees()
        {
            Print(GetTreesKey());
        }
        #endregion

        // Private ------------
        public Box GetItem(double x, double y)
        {
            BinaryTree<double,Box> a = _treeMenengar.GetInnerBTree(x);

            if (a == null) return null;
            return a.GetValue(y);
        }
        /// <summary>
        /// Method implemetns removing the <see cref="NodeTree{K, V}"/> where V is <see cref="Box"/>
        /// </summary>
        /// <param name="x">Box's width</param>
        /// <param name="y">Box's height</param>
        private void RemoveBox(double x,double y)
        {
            Box box = GetItem(x, y);
            if(box != null)
            {
                var a = _treeMenengar.GetInnerBTree(box.Width);
                _queue.RemoveQNode(box.NodeQueue);
                a.RemoveNode(box.Height);
            }
        }

        /// <summary>
        /// Returns <see cref="IEnumerable"/> width all <see cref="Box"/>'s in <see cref="BinaryTree{K, V}"/>
        /// </summary>
        /// <returns>All <see cref="Box"/>'s</returns>
        public IEnumerable GetAllBoxes()
        {
            foreach (BinaryTree<double, Box> YTree in _tree.GetEnumeratorValue(Order.inOrder))
                foreach (Box box in YTree.GetEnumeratorValue(Order.inOrder))
                    yield return box;
        }
        /// <summary>
        /// Returns all <see cref="Box"/>'s in specific <see cref="BinaryTree{K, V}"/>
        /// </summary>
        /// <param name="x">Inner tree in Main tree</param>
        /// <returns><see cref="Box"/>'s</returns>
        public IEnumerable GetBoxesInTree(double x)
        {
            BinaryTree<double, Box> YTree = _tree.GetValue(x);

            foreach(Box b in YTree.GetEnumeratorValue(Order.inOrder)) { yield return b; }       
        }

        /// <summary>
        /// Return all <see cref="BinaryTree{K, V}"/> in Main tree
        /// </summary>
        /// <returns><see cref="BinaryTree{K, V}"/></returns>
        public IEnumerable GetTreesKey()
        {
            foreach (var YTree in _tree.GetEnumerator(Order.inOrder))
            {
                yield return YTree;
            }
        }

        // Queue -------------------------

        /// <summary>
        /// Timer that implements method <see cref="ExpireCheck(object, object)"/> on pre day(24 hours)
        /// </summary>
        public void TimerCheck()
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(1, 0, 0, 0, 0);
            timer.Tick += ExpireCheck;
            timer.Start();
        }

        /// <summary>
        /// Method implements checking expire date of the box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExpireCheck(object sender, object e)
        {
            bool check = true;
            while (check)
            {
                check = false;
                if(_queue.Head != null)
                if (_queue.Head.ValueQNode.Date.AddDays(MAX_EXPIRE_DAYS) < DateTime.Now)
                {
                    RemoveBox(_queue.Head.ValueQNode.Width, _queue.Head.ValueQNode.Height);
                        check = true;
                }
            }
        }
        //------------------------------------------

        // Example three--------
        private void Init()
        {
            // Left tree ---------------
            //tree Width 15x?
            Add(15.5, 15, 5);
            Add(15.5, 20, 5);
            Add(15.5, 10, 5);
            Add(15.5, 5, 5);
            Add(15.5, 11, 5);
            Add(15.5, 16, 5);
            Add(15.5, 22, 5);

            //tree Width 20x?
            Add(20, 15, 5);
            Add(20, 20, 5);
            Add(20, 10, 5);
            Add(20, 5, 5);
            Add(20, 11, 5);
            Add(20, 16, 5);
            Add(20, 22, 5);

            //tree Width 9x?
            Add(9, 15, 5);
            Add(9, 20, 5);
            Add(9, 10, 5);
            Add(9, 5, 5);
            Add(9, 11, 5);
            Add(9, 16, 5);
            Add(9, 22, 5);

            //tree Width 6x?
            Add(6, 15, 5);
            Add(6, 20, 5);
            Add(6, 10, 5);
            Add(6, 5, 5);
            Add(6, 11, 5);
            Add(6, 16, 5);
            Add(6, 22, 5);

            //tree Width 4x?
            Add(4, 15, 5);
            Add(4, 20, 5);
            Add(4, 10, 5);
            Add(4, 5, 5);
            Add(4, 11, 5);
            Add(4, 16, 5);
            Add(4, 22, 5);

            //tree Width 3x?
            Add(3, 15, 5);
            Add(3, 20, 5);
            Add(3, 10, 5);
            Add(3, 5, 5);
            Add(3, 11, 5);
            Add(3, 16, 5);
            Add(3, 22, 5);

            //tree Width 5x?
            Add(5, 15, 5);
            Add(5, 20, 5);
            Add(5, 10, 5);
            Add(5, 5, 5);
            Add(5, 11, 5);
            Add(5, 16, 5);
            Add(5, 22, 5);

            //tree Width 7x?
            Add(7, 15, 5);
            Add(7, 20, 5);
            Add(7, 10, 5);
            Add(7, 5, 5);
            Add(7, 11, 5);
            Add(7, 16, 5);
            Add(7, 22, 5);

            //tree Width 8x?
            Add(8, 15, 5);
            Add(8, 20, 5);
            Add(8, 10, 5);
            Add(8, 5, 5);
            Add(8, 11, 5);
            Add(8, 16, 5);
            Add(8, 22, 5);

            //tree Width 12x?
            Add(12, 15, 5);
            Add(12, 20, 5);
            Add(12, 10, 5);
            Add(12, 5, 5);
            Add(12, 11, 5);
            Add(12, 16, 5);
            Add(12, 22, 5);

            //tree Width 13x?
            Add(13, 15, 5);
            Add(13, 20, 5);
            Add(13, 10, 5);
            Add(13, 5, 5);
            Add(13, 11, 5);
            Add(13, 16, 5);
            Add(13, 22, 5);

            //tree Width 13.5x?
            Add(13.5, 15, 5);
            Add(13.5, 20, 5);
            Add(13.5, 10, 5);
            Add(13.5, 5, 5);
            Add(13.5, 11, 5);
            Add(13.5, 16, 5);
            Add(13.5, 22, 5);

            //tree Width 12.5x?
            Add(12.5, 15, 5);
            Add(12.5, 20, 5);
            Add(12.5, 10, 5);
            Add(12.5, 5, 5);
            Add(12.5, 11, 5);
            Add(12.5, 16, 5);
            Add(12.5, 22, 5);

            //tree Width 10.5x?
            Add(10.5, 15, 5);
            Add(10.5, 20, 5);
            Add(10.5, 10, 5);
            Add(10.5, 5, 5);
            Add(10.5, 11, 5);
            Add(10.5, 16, 5);
            Add(10.5, 22, 5);

            //tree Width 10x?
            Add(10, 15, 5);
            Add(10, 20, 5);
            Add(10, 10, 5);
            Add(10, 5, 5);
            Add(10, 11, 5);
            Add(10, 16, 5);
            Add(10, 22, 5);

            //tree Width 11x?
            Add(11, 15, 5);
            Add(11, 20, 5);
            Add(11, 10, 5);
            Add(11, 5, 5);
            Add(11, 11, 5);
            Add(11, 16, 5);
            Add(11, 22, 5);

            // Right tree -------------

            //tree Width 20x?
            Add(20, 15, 5);
            Add(20, 20, 5);
            Add(20, 10, 5);
            Add(20, 5, 5);
            Add(20, 11, 5);
            Add(20, 16, 5);
            Add(20, 22, 5);

            //tree Width 25x?
            Add(25, 15, 5);
            Add(25, 20, 5);
            Add(25, 10, 5);
            Add(25, 5, 5);
            Add(25, 11, 5);
            Add(25, 16, 5);
            Add(25, 22, 5);

            //tree Width 28x?
            Add(28, 15, 5);
            Add(28, 20, 5);
            Add(28, 10, 5);
            Add(28, 5, 5);
            Add(28, 11, 5);
            Add(28, 16, 5);
            Add(28, 22, 5);

            //tree Width 30x?
            Add(30, 15, 5);
            Add(30, 20, 5);
            Add(30, 10, 5);
            Add(30, 5, 5);
            Add(30, 11, 5);
            Add(30, 16, 5);
            Add(30, 22, 5);

            //tree Width 26x?
            Add(26, 15, 5);
            Add(26, 20, 5);
            Add(26, 10, 5);
            Add(26, 5, 5);
            Add(26, 11, 5);
            Add(26, 16, 5);
            Add(26, 22, 5);

            //tree Width 22x?
            Add(22, 15, 5);
            Add(22, 20, 5);
            Add(22, 10, 5);
            Add(22, 5, 5);
            Add(22, 11, 5);
            Add(22, 16, 5);
            Add(22, 22, 5);
            //tree Width 22x?
            Add(23, 15, 5);
            Add(23, 20, 5);
            Add(23, 10, 5);
            Add(23, 5, 5);
            Add(23, 11, 5);
            Add(23, 16, 5);
            Add(23, 22, 5);

            //tree Width 17x?
            Add(17, 15, 5);
            Add(17, 20, 5);
            Add(17, 10, 5);
            Add(17, 5, 5);
            Add(17, 11, 5);
            Add(17, 16, 5);
            Add(17, 22, 5);

            //tree Width 18x?
            Add(18, 15, 5);
            Add(18, 20, 5);
            Add(18, 10, 5);
            Add(18, 5, 5);
            Add(18, 11, 5);
            Add(18, 16, 5);
            Add(18, 22, 5);

            //tree Width 19x?
            Add(19, 15, 5);
            Add(19, 20, 5);
            Add(19, 10, 5);
            Add(19, 5, 5);
            Add(19, 11, 5);
            Add(19, 16, 5);
            Add(19, 22, 5);

            //tree Width 16x?
            Add(16, 15, 5);
            Add(16, 20, 5);
            Add(16, 10, 5);
            Add(16, 5, 5);
            Add(16, 11, 5);
            Add(16, 16, 5);
            Add(16, 22, 5);
        }

        //----------------------
    }
}

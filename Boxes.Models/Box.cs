using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxes.Models
{
    public class Box
    {
        private int _count;
        private DateTime _date;
        private const int MaxBoxes = 10;
        public Box()
        {
            _count = MaxBoxes;
            _date = DateTime.Now;
        }

        public void AddBox()
        {
            _count++;
        }
        public bool RequestBox()
        {
            _date = DateTime.Now;
            _count--;
            if( _count == 0)
                return true;
            else
                return false;
        }
        public void FillBoxes() 
        {
            _count = MaxBoxes;
        }

        public override string ToString()
        {
            return _count.ToString();
        }
        public int Count { get { return _count; } }
        public DateTime Date { get { return _date; } }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxesProject
{
    public class Box
    {
        private int _count;
        private DateTime _date;

        public Box()
        {
            _count = 1;
            _date = DateTime.Now;
        }

        public void AddBox()
        {
            _count++;
        }
        public bool GetBox()
        {
            _date = DateTime.Now;
            _count--;
            if( _count == 0)
                return true;
            else
                return false;
        }
        public int Count { get { return _count; } }
        public DateTime Date { get { return _date; } }
    }
}

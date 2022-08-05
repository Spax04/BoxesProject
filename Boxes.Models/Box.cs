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
        private const int MaxCount = 100;
        private readonly double _width;
        private readonly double _height;
        public Box(double x,double y,int count)
        {
            _count = count;
            _date = DateTime.Now;
            _width = x;
            _height = y;
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
        public void FillBoxes(int count) 
        {
            _count += count;
            if (_count > MaxCount)
            {
                _count = MaxCount;
                Console.WriteLine("There are to much boaxes. Current count was returned to '100'. ");
            }
        }

        public override string ToString()
        {
            return $"Box's width: {_width}. Box's height: {_height}. Current count of the boxs: {_count}. Last time box war requested: {_date:g}";
        }
        public int Count { get { return _count; } }
        public DateTime Date { get { return _date; } }
    }
}

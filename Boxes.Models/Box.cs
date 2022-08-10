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
        private const int MinCount = 10;
        private readonly double _width;
        private readonly double _height;
        public Box(double x,double y,int count)
        {
            _count = count;
            _date = DateTime.Now;
            _width = x;
            _height = y;
        }

        public void FillBoxes(int count)
        {
            _count += count;
            if (_count > MaxCount)
            {
                _count = MaxCount;
                Console.WriteLine("There are to much boxes. Current count was returned to '100'. ");
            }
        }
        public int RequestBox(int countRequest)
        {
            _date = DateTime.Now;
            if(_count > 0)
            {
                _count -= countRequest;
            }
            
            if(_count <= MinCount && _count > 0)
            {
                Console.WriteLine($"{_count} boxes left of the size.");
            }
            if( _count <= 0)
            {
                Console.WriteLine("Not enough boxes of this size. Missing: " + (_count * -1));
                return _count * -1;
            }
            else
                return 0;
        }

        public override string ToString()
        {
            if(_count < 0)
                return $"Box's width: {_width}. Box's height: {_height}. Current count of the boxs: 0. Last time box war requested: {_date:g}\nBox doesn't exist any more";
            else
                return $"Box's width: {_width}. Box's height: {_height}. Current count of the boxs: {_count}. Last time box war requested: {_date:g}";
        }
        public int Count { get { return _count; } }
        public DateTime Date { get { return _date; } }
        public double Width { get { return _width; } }
        public double Height { get { return _height; } }
    }
}

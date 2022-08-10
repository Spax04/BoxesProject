using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxes.Models
{
    public class DoubleMathProvide : MathProvider<double>
    {
        public override double Multiply(double a, double b)
        {
           return a * b;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxes.Models
{
    public abstract class MathProvider<T>
    {
        public abstract T Multiply(T a,T b);
    }
}

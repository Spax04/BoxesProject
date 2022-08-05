using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxes.DAL
{
    public interface IRepository<V>
    {
        void Add(double x,double y);
        V Get(double x);
    }
}

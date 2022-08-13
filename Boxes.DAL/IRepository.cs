using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxes.DAL
{
    public interface IRepository<V>
    {
        void Add(double x,double y,int count);

        IEnumerable RequestItemFromDB(double x,double y,int count);

        V GetItem(double x,double y);
    }
}

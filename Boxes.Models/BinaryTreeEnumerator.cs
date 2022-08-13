using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxes.Models
{
    public class BinaryTreeEnumerator<key, value> : IEnumerator
    {
        //private BinaryTree<key, value> _tree;

        

        public NodeTree<key,value> Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();


        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}

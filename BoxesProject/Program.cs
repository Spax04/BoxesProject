using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boxes.DAL;
using System.Threading.Tasks;

namespace Boxes.Models
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BoxRepository br = new BoxRepository();

            br.AddBoxToDB(5, 5,100);
            
        }

       
    }
}

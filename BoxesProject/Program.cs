using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boxes.DAL;
using Boxes.Models;
using System.Threading.Tasks;

namespace Boxes.Models
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BoxRepository br = BoxRepository.Instans;



            br.PrintInnerTrees(3);

           /* foreach(var a in br.RequestItemFromDB(3, 9, 11))
            {
                Console.WriteLine(a);
            }
*/
            Console.WriteLine("===================");

            
            Console.WriteLine("==========");
            
        }
    }
}

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
             
           

            br.PrintWidths();
            Console.WriteLine("================");
            br.PrintHeights(5);
            Console.WriteLine("================");
            br.PrintHeights(4);
            Console.WriteLine("================");
            br.PrintHeights(6);
            Console.WriteLine("================");
            br.Add(2, 1,10);
            br.PrintWidths();
            Console.WriteLine("==================");
            br.PrintHeights(3);
            Console.WriteLine("================");
            List<Box> b = br.RequestItemFromDB(3, 9, 10);

            Console.WriteLine("===================");

            foreach (Box b2 in b)
            {
                Console.WriteLine(b2);
            }
            Console.WriteLine("==========");
            br.PrintHeights(3);
        }
    }
}

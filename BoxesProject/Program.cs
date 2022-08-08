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
            Console.WriteLine("'5 tree'");
            br.PrintHeights(5);
            Console.WriteLine("================");
            Console.WriteLine("'4 tree'");
            br.PrintHeights(4);
            Console.WriteLine("================");
            Console.WriteLine("'6 tree'");
            br.PrintHeights(6);
            Console.WriteLine("================");
            br.Add(7, 1,10);
            br.PrintWidths();
            Console.WriteLine("==================");
            br.PrintHeights(7);
            Console.WriteLine("================");
           List<Box> b =  br.RequestItemFromDB(5, 5,6);

            foreach(Box b2 in b)
            {
                Console.WriteLine(b2);
            }
 
        }
    }
}

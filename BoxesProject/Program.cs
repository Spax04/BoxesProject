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
            BoxRepository br = new BoxRepository();

           
            br.AddBoxToDB(5, 5, 5);
            br.AddBoxToDB(5, 6,5);
            br.AddBoxToDB(5, 4, 5);

            br.AddBoxToDB(6, 5, 5);
            br.AddBoxToDB(6, 6, 5);
            br.AddBoxToDB(6, 4, 5);

            br.AddBoxToDB(4, 5, 5);
            br.AddBoxToDB(4, 6, 5);
            br.AddBoxToDB(4, 4, 5);

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
           

            br.CustomreBoxRequest(5, 5,6);
 
        }
    }
}

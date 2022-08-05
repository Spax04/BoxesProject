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
            br.AddBoxToDB(5, 5, 100);
            br.AddBoxToDB(5, 5, 100);
            br.AddBoxToDB(5, 6,100);
            br.AddBoxToDB(5, 4, 100);

            br.AddBoxToDB(6, 5, 100);
            br.AddBoxToDB(6, 6, 100);
            br.AddBoxToDB(6, 4, 100);

            br.AddBoxToDB(4, 5, 100);
            br.AddBoxToDB(4, 6, 100);
            br.AddBoxToDB(4, 4, 100);

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
            br.PrintDitales(5, 5);


        }

       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boxes.DAL;
using Boxes.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Boxes.Models
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BoxRepository br = BoxRepository.Instans;
           /* Configurations config = new Configurations();
            Console.WriteLine($"Max exp deys: {Configurations.Data.MAX_EXPIRE_DAYS} \n Max Boxes: {Configurations.Data.MAX_EXPIRE_DAYS} \nMin boxes: {Configurations.Data.MAX_EXPIRE_DAYS}");
*/
            br.PrintInnerTrees(3);
            br.PrintTrees();
            Console.WriteLine("===================");
            var IE = br.RequestItemFromDB(3, 9, 21);
            foreach (var a in IE)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("==========");
            br.PrintInnerTrees(3);
            Console.WriteLine("==========");
            br.Queue.printNodes();  

            
        }
    }
}

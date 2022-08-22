﻿using System;
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
         
            br.PrintInnerTrees(3);
            br.PrintTrees();
            Console.WriteLine("===================");
            var IE = br.RequestItemFromDB(3, 9, 16);
            foreach (var a in IE)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("==========");
            br.PrintInnerTrees(3);
            Console.WriteLine("==========");
            br.Queue.printNodes();

            Console.ReadLine();
        }
    }
}

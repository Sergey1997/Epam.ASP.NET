using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindNthRootLogic;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            double answer = Newton.FindNthRoot(10, 2, 0.00000001);
            //answer = Math.Round(answer, 1);
            Console.Write(answer);
        }
    }
}

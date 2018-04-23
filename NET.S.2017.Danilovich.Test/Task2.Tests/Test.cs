using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2;

namespace Task2.Tests
{
    class Test
    {
        public static void Main(string[] args)
        {
            RandomBytesFileGenerator generator = new RandomBytesFileGenerator("D:\\Epam\\Epam.ASP.NET\\NET.S.2017.Danilovich.Test\\Task2.Tests", ".txt");
            generator.GenerateFiles(1, 15);
            RandomCharsFileGenerator generator2 = new RandomCharsFileGenerator("D:\\Epam\\Epam.ASP.NET\\NET.S.2017.Danilovich.Test\\Task2.Tests", ".byte");
            generator2.GenerateFiles(2, 20);
        }
    }
}

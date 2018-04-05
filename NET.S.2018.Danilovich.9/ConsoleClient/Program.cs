﻿using System;
using System.Configuration;
using static StreamsDemo.StreamsExtension;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = ConfigurationManager.AppSettings["sourceFilePath"];

            var destination = ConfigurationManager.AppSettings["destinationFilePath"];
            Console.WriteLine(source);
            Console.WriteLine(destination);

            //Console.WriteLine($"ByByteCopy() done. Total bytes: {ByByteCopy(source, destination)}");
            Console.WriteLine($"InMemoryByBlockCopy() done. Total strings: {ByLineCopy(source, destination)}");
            //Console.WriteLine($"BufferedCopy() done. Total bytes: {BufferedCopy(source, destination)}");
            //Console.WriteLine($"InMemoryByteCopy() done. Total bytes: {InMemoryByByteCopy(source, destination)}");

            Console.WriteLine(IsContentEquals(source, destination));
            
            //etc
        }
    }
}

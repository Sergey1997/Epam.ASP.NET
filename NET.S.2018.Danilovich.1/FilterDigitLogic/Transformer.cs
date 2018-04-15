using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FilterDigitLogic
{
    public static class Transformer<T>
    {
        public static T Square(T number)
        {
            return number;
        }

        public static int Square(int number) => number * number;

        public static string Square(string number) => number.Remove(0, 3);
    }
}

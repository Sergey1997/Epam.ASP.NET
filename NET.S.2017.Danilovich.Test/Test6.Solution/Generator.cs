using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test6.Solution
{
    public class Generator
    {
        public static IEnumerable<T> Generate<T>(T a, T b, int count, Func<T, T, T> func)
        {
            yield return a;
            yield return b;
            int i = 0;

            while(i < count - 2)
            {
                T next = func(a, b);
                yield return next;
                a = b;
                b = next;
                i++;
            }

        }
    }
}

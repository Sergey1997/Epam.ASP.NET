using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FilterDigitLogic
{
    public interface ITransformer
    {
        /// <summary>   Transforms. </summary>
        /// <param name="number">   Number of. </param>
        /// <returns>   An int. </returns>
        int Transform(int number);
    }
    public static class TransformerSquare
    {
        public static int Square(int number) => number * number;
    }
    public static class Transformer
    {
        public static int Square(int number) => number * number;
    }
}

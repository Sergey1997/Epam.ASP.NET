using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterDigitLogic
{
    public class Pow : ITransformer
    {
        public int Degree { get; set; }
        public Pow(int degree)
        {
            Degree = degree;
        }
        
        public int Transform(int number)
        {
            for(int i = 1; i < Degree; i++)
            {
                number *= number;
            }

            return number;
        }   
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
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
}

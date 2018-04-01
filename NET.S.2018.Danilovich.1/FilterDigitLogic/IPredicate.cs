using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterDigitLogic
{
    /// <summary>   Interface for checking numbers. </summary>
    public interface IPredicate
    {
        /// <summary>   Query if 'number' is suitable. </summary>
        /// <param name="number">   Number for checking. </param>
        /// <returns>   True if suitable, false if not. </returns>
        bool IsSuitable(int number);
    }
}

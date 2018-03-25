using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingLibrary
{
    public interface IStrategy
    {
        /// <summary>   Algorithm for array strategies . </summary>
        /// <param name="array">    The array. </param>
        /// <returns>   An int? number </returns>
        int? Algorithm(int[] array);
    }
}

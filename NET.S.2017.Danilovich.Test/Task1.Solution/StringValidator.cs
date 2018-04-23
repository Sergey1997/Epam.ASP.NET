using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solution
{
    public class StringValidator : IValidator
    {
        public Tuple<bool, string> IsValid(string password)
        {
            if(password == null)
            {
                throw new ArgumentNullException($"{(nameof(password))} cant be a null");
            }
            if (password == string.Empty)
                return Tuple.Create(false, $"{password} is empty ");

            return Tuple.Create(true, "");
        }
    }
}

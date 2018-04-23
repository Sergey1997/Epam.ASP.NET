using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solution
{
    public class LengthValidator : IValidator
    {
        public Tuple<bool, string> IsValid(string password)
        {
            if (password.Length <= 7)
                return Tuple.Create(false, $"{password} length too short");
            
            if (password.Length >= 15)
                return Tuple.Create(false, $"{password} length too long");

            return Tuple.Create(true, "");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solution
{
    public interface IValidator
    {
        Tuple<bool, string> VerifyPassword(string password, int minLength = 7, int maxLength = 15, bool checkForAlfaChar = true, bool checkForDigitChar = true);
    }
}

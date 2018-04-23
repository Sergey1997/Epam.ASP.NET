using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solution
{
    public class CustomValidator : IValidator
    {
        public Tuple<bool, string> VerifyPassword(string password, int minLength, int maxLength, bool checkForAlfaChar, bool checkForDigitChar)
        {
            if (password == null)
                throw new ArgumentException($"{password} is null arg");

            if (password == string.Empty)
                return Tuple.Create(false, $"{password} is empty ");

            if (password.Length <= minLength)
                return Tuple.Create(false, $"{password} length too short");

            if (password.Length >= maxLength)
                return Tuple.Create(false, $"{password} length too long");

            if (checkForAlfaChar == true)
            {
                if (!password.Any(char.IsLetter))
                    return Tuple.Create(false, $"{password} hasn't alphanumerical chars");
            }

            if (checkForDigitChar == true)
            {
                if (!password.Any(char.IsNumber))
                    return Tuple.Create(false, $"{password} hasn't digits");
            }
            
            return Tuple.Create(true, "Password is Ok. User was created");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public class Client
    {
        /// <summary>   Constructor of entity man. </summary>
        /// <param name="name">     The name. </param>
        /// <param name="surname">  The person's surname. </param>
        /// <param name="lastname"> The lastname. </param>
        /// <param name="passport"> The passport. </param>
        public Client(string name, string surname, string lastname, string passport)
        {
            if (name == null || surname == null || lastname == null || passport == null)
            {
                throw new ArgumentNullException("Need more information about client");
            }

            Name = name;
            Surname = surname;
            Lastname = lastname;
            NumberOfPassport = passport;
        }

        public string NumberOfPassport { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Lastname { get; set; }

        public bool Equals(Client man)
        {
            if (man == null || GetType() != man.GetType())
            {
                return false;
            }

            if (Name == man.Name && Surname == man.Surname && Lastname == man.Lastname && NumberOfPassport == man.NumberOfPassport)
            {
                return true;
            }

            return false;
        }
    }
}

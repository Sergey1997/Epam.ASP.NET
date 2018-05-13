using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
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
            Name = name;
            Surname = surname;
            Lastname = lastname;
            NumberOfPassport = passport;
        }

        public string NumberOfPassport { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Lastname { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Client client &&
                   NumberOfPassport == client.NumberOfPassport &&
                   Name == client.Name &&
                   Surname == client.Surname &&
                   Lastname == client.Lastname;
        }

        public override int GetHashCode()
        {
            int hashCode = 940430837;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NumberOfPassport);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Surname);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Lastname);
            return hashCode;
        }

        public override string ToString()
        {
            return $"\nName: {Name}\nSurName: {Surname}\nLastName: {Lastname}\nNumberOfPassport: {NumberOfPassport}\n";
        }
    }
}

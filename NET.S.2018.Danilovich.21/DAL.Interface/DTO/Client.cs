using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class Client
    {
        public Client(string name, string surname, string lastname, string numberOfPassport)
        {
            Name = name;
            Surname = surname;
            Lastname = lastname;
            NumberOfPassport = numberOfPassport;
        }

        public string NumberOfPassport { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Lastname { get; set; }

    }
}

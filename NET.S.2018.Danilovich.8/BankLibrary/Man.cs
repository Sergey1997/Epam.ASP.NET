using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public class Man
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Lastname { get; set; }

        public virtual string GetShortName()
        {
            return $"{Surname} {Name[0]}.{Lastname[0]}.";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Man man = (Man)obj;
            if ((Name == man.Name) || man.Name.Equals(Name))
            {
                if ((Surname == man.Surname) || man.Surname.Equals(Surname))
                {
                    if ((Lastname == man.Lastname) || man.Lastname.Equals(Lastname))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}

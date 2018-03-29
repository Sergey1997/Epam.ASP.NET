using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    
    public class Account
    {
        private int id;
        static int counter = 0;
        public Man man;
        public Gradation gradation;
        public decimal balance = 0;
        public Account(Man man, Gradation gradation)
        {
            this.man = new Man(man.Name,man.Surname,man.Lastname);
            this.gradation = gradation;
            id = ++counter;
        }
        
        private uint Bonuses
        {
            get
            {
                return CostOfBalance * CostOfFiiling;
            }
        }
        public virtual void Put(decimal money)
        {
            if(money < 0)
            {
                throw new ArgumentOutOfRangeException($"{(nameof(money))} cant be less then zero");
            }

            balance += money;
        }

        public virtual void Withdraw(decimal money)
        {
            if (money < 0)
            {
                throw new ArgumentOutOfRangeException($"{(nameof(money))} cant be less then zero");
            }
            if(this.balance > money)
            {
                throw new ArgumentOutOfRangeException($"{(nameof(money))} cant be more then {nameof(balance)} when withdrawing money");
            }

            balance -= money;
        }

        public uint CostOfBalance
        {
            get
            {
                switch (gradation)
                {
                    case Gradation.Base:
                        return 1;
                    case Gradation.Silver:
                        return 3;
                    case Gradation.Gold:
                        return 5;
                    case Gradation.Platinum:
                        return 7;
                }

                throw new ArgumentOutOfRangeException(nameof(gradation));
            }
        }
        public uint CostOfFiiling
        {
            get
            {
                switch (gradation)
                {
                    case Gradation.Base:
                        return 2;
                    case Gradation.Silver:
                        return 4;
                    case Gradation.Gold:
                        return 5;
                    case Gradation.Platinum:
                        return 7;
                }

                throw new ArgumentOutOfRangeException(nameof(gradation));
            }
        }
        public bool Equals(Account other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (!man.Equals(other) || id != other.id || gradation != other.gradation)
            {
                return false;
            }

            return true;
        }
    }
    public enum Gradation
    {
        Base = 1,
        Silver,
        Gold,
        Platinum
    }
}

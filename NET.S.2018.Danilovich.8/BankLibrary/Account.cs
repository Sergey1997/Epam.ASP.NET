using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public abstract class Account
    {
        private Man man;
        private Gradation gradation;
        private decimal balance;
        public Account();

        private uint Bonuses
        {
            get
            {
                return CostOfBalance * CostOfFiiling;
            }
        }
        private uint CostOfBalance
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

                throw new ArgumentException(nameof(gradation));
            }
        }
        private uint CostOfFiiling
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

                throw new ArgumentException(nameof(gradation));
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    enum Gradation
    {
        Base = 1,
        Silver,
        Gold,
        Platinum
    }
}

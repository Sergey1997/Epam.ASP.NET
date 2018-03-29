using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public interface IAccount
    {
        /// <summary>   Puts the given money to account. </summary>
        /// <param name="money">    The money to put. </param>
        void Put(decimal money);
        
        /// <summary>   Withdraws the given money from account. </summary>
        /// <param name="money">    The money to put. </param>
        void Withdraw(decimal money);
    }
}

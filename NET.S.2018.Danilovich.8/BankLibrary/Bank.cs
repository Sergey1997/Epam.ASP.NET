using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public class Bank
    {
        public List<Account> accounts = null;

        public void OpenAccount(Account account)
        {
            if(accounts == null)
            {
                accounts = new List<Account>
                {
                    account
                };
            }
            else
            {
                accounts.Add(account);
            }
            if(account == null)
            {
                throw new ArithmeticException($"{(nameof(account))} is null");
            }
            
        }
        public void CloseAccount(Account account)
        {
            if (account == null)
            {
                throw new ArithmeticException($"{(nameof(account))} is null");
            }

            if(accounts == null)
            {
                throw new Exception("List of accounts is null, nothing to close");
            }

            foreach(var item in accounts)
            {
                if (item.Equals(account))
                {
                    accounts.Remove(item);
                }
                else
                {
                    throw new ArgumentException($"{(nameof(account))} doesnt find in list");
                }
            }
        }
    }
}

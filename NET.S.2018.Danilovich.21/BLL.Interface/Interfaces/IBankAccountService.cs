using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Interfaces
{
    public interface IBankAccountService
    {
        void Open(Client client, Gradation gradation);
        
        void Close(int id);
        
        void Put(int id, decimal balance);
        
        void Withdraw(int id, decimal balance);

        IEnumerable<BankAccount> GetAllAccounts();
    }
}

using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Interfaces
{
    public interface IRepository
    {
        IEnumerable<Account> GetAll();

        Account Take(int id);
        
        void Add(Account account);
        
        void Update(Account account);
        
        void Delete(Account account);
    }
}

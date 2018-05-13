using BLL.Interface.Entities;
using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class BankAccountMapper
    {
        public static Account ToAccount(this BankAccount bankAccount)
        {
            if (bankAccount is null)
            {
                return null;
            }

            return new Account()
            {
                Id = bankAccount.Id,
                Client = new DAL.Interface.DTO.Client(bankAccount.Client.Name, bankAccount.Client.Surname, bankAccount.Client.Lastname, bankAccount.Client.NumberOfPassport),
                Balance = bankAccount.Balance,
                BonusPoints = bankAccount.BonusPoints,
                Gradation = (int)bankAccount.Gradation
            };
        }
        
        public static BankAccount ToBankAccount(this Account account)
        {
            if (account is null)
            {
                return null;
            }

            return new BankAccount(
                account.Id,
                new BLL.Interface.Entities.Client(account.Client.Name, account.Client.Surname, account.Client.Lastname, account.Client.NumberOfPassport),
                (Gradation)account.Gradation, 
                account.Balance, 
                account.BonusPoints);
        }
    }
}

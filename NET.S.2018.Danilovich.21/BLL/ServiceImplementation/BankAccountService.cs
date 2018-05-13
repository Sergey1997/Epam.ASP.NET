using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Mappers;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceImplementation
{
    public class BankAccountService : IBankAccountService
    {
        private IGenerator generator;
        private IGradationCounter graduation;
        private IRepository repository;

        public BankAccountService(IRepository repository, IGenerator generator, IGradationCounter graduation)
        {
            this.Repository = repository;
            this.Generator = generator;
            this.Graduation = graduation;
        }
    
        private IRepository Repository
        {
            get => this.repository;

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException($"{(nameof(value))} cant be a null");
                }

                this.repository = value;
            }
        }
        private IGenerator Generator
        {
            get => this.generator;

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.generator = value;
            }
        }

        private IGradationCounter Graduation
        {
            get => this.graduation;

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException($"{(nameof(value))} cant be a null");
                }

                this.graduation = value;
            }
        }

        public IEnumerable<BankAccount> GetAllAccounts()
        {
            return Repository.GetAll().Select(account => account.ToBankAccount());
        }

        public void Close(int id)
        {
            BankAccount bankAccount = this.GetAllAccounts().First(element => element.Id == id);

            if (bankAccount is null)
            {
                throw new KeyNotFoundException($"{(nameof(bankAccount))} with id {(id)}  dont found");
            }
            
            this.Repository.Delete(bankAccount.ToAccount());
        }

        public void Open(Client client, Gradation gradation)
        {
            BankAccount bankAccount = new BankAccount(generator.GenerateId(), client,gradation, 0, 0);

            this.Graduation.SetGraduationType(bankAccount.Gradation);
            
            this.Repository.Add(bankAccount.ToAccount());
        }

        public void Put(int id, decimal balance)
        {
            if (balance <= 0)
            {
                throw new ArgumentException(nameof(balance));
            }
            

            BankAccount account = this.GetAllAccounts().First(x=>x.Id == id);

            if (account is null)
            {
                throw new KeyNotFoundException(nameof(account));
            }

            this.Graduation.SetGraduationType(account.Gradation);
            account.Balance = account.Balance + balance;
            account.BonusPoints = this.Graduation.Add(account.BonusPoints);
            this.Repository.Update(account.ToAccount());
        }

        public void Withdraw(int id, decimal balance)
        {
            if (balance <= 0)
            {
                throw new ArgumentException(nameof(balance));
            }

            BankAccount bankAccount = this.GetAllAccounts().First(element => element.Id == id);

            if (bankAccount is null)
            {
                throw new KeyNotFoundException(nameof(bankAccount));
            }

            this.Graduation.SetGraduationType(bankAccount.Gradation);

            bankAccount.Balance = bankAccount.Balance - balance;
            bankAccount.BonusPoints = this.Graduation.Decrease(bankAccount.BonusPoints);

            this.Repository.Update(bankAccount.ToAccount());
        }
    }
}

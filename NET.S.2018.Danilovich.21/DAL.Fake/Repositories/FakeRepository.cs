using System;
using System.Collections.Generic;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.Fake.Repositories
{
    public class FakeRepository : IRepository
    {
        private readonly List<Account> accounts;

        public FakeRepository()
        {
            accounts = new List<Account>();
        }

        public IEnumerable<Account> GetAll()
        {
            return accounts;
        }

        public Account Take(int id)
        {
            return this.accounts.Find(a => a.Id == id);
        }

        public void Add(Account account)
        {
            if (accounts.Contains(account))
            {
                throw new InvalidOperationException();
            }

            accounts.Add(account);
        }

        public void Update(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException($"Argument {nameof(account)} is null");
            }

            int index = this.accounts.FindIndex(a => a.Id == account.Id);

            if (index < 0)
            {
                throw new ApplicationException($"Account not found");
            }

            this.accounts.RemoveAt(index);
            this.accounts.Insert(index, account);
        }

        public void Delete(Account account)
        {
            Update(account);
        }
    }
}
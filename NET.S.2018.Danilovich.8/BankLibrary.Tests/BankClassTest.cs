using NUnit.Framework;
using BankLibrary;
using System.Collections.Generic;
using System;

namespace BankLibrary.Tests
{
    class BankClassTest
    {
        Man man = new Man("Sergey", "Danilovich", "Igorevich", "FRM7575");
        Gradation gradation = Gradation.Platinum;

        Man man1 = new Man("Oleg", "Dobrotsky", "Ivanovich", "Number213");
        Gradation gradation1 = Gradation.Gold;
        [Test]
        public void OpenAccountTestMethod()
        {
            Bank bank = new Bank();
            Account account = new Account(man, gradation);
            Account account1 = new Account(man, gradation);
            List<Account> expected = new List<Account>()
            {
               account,account1
            };

            bank.OpenAccount(account);
            bank.OpenAccount(account1);
            CollectionAssert.AreEqual(expected, bank.Accounts);
        }
        [Test]
        public void CloseAccountTestMethod()
        {
            Bank bank = new Bank();
            Account account = new Account(man, gradation);
            Account account1 = new Account(man, gradation);
            List<Account> expected = new List<Account>()
            {
                account
            };

            bank.OpenAccount(account);
            bank.OpenAccount(account1);
            bank.CloseAccount(account1);
            CollectionAssert.AreEqual(expected, bank.Accounts);
        }
        [TestCase]
        public void Bank_CloseAccountMethod_ArgumentNullException()
        {
            Bank bank = new Bank();
            Assert.Throws<ArgumentNullException>(() => bank.CloseAccount(null));
        }
        [TestCase]
        public void Bank_CloseAccountMethod_NullReferenceException()
        {
            Bank bank = null;
            Account account = new Account(man, gradation);
            Assert.Throws<NullReferenceException>(() => bank.CloseAccount(account));
        }
        [TestCase]
        public void Bank_CloseAccountMethod_ArgumentException()
        {
            Bank bank = new Bank();
            Account account = new Account(man1, gradation1);
            Account actual = new Account(man, gradation);
            bank.OpenAccount(actual);
            Assert.Throws<ArgumentException>(() => bank.CloseAccount(account));
        }
    }
}

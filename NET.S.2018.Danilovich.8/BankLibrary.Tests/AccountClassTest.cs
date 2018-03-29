using System;
using NUnit.Framework;

namespace BankLibrary.Tests
{
    public class AccountClassTest
    {
        Man man = new Man("Sergey", "Danilovich", "Igorevich", "FRM7575");
        Gradation gradation = Gradation.Platinum;
        [Test]
        public void Account_Constructor_Test()
        {
            Account actual = new Account(man, gradation);
            Assert.IsNotNull(actual);
        }
        [Test]
        [TestCase(102950)]
        [TestCase(13.244)]
        [TestCase(55.3321423412342)]
        public void Account_PutMethod_Test(decimal money)
        {
            Account actual = new Account(man, gradation);
            decimal prevBalance = actual.Balance;
            uint prevPoints = actual.BonusePoints;
            actual.Put(money);
            Assert.AreEqual(actual.Balance, prevBalance + money);
            Assert.AreEqual(actual.BonusePoints, prevPoints + (uint)(money / 50) * (actual.CostOfBalance + actual.CostOfFiiling));
        }

        [TestCase(-15.2)]
        public void AccountPutTest_Money_ArgumentOutOfRangeException(decimal money)
        {
            Account actual = new Account(man, gradation);
            Assert.Throws<ArgumentOutOfRangeException>(() => actual.Put(money));
        }
        [TestCase(1000)]
        public void AccountWithdrawTest_Money_ArgumentOutOfRangeException(decimal money)
        {
            Account actual = new Account(man, gradation)
            {
                Balance = 800
            };
            Assert.Throws<ArgumentOutOfRangeException>(() => actual.Withdraw(money));
        }
        [Test]
        [TestCase(500)]
        [TestCase(13.244)]
        [TestCase(55.3321423412342)]
        public void Account_WithdrawMethod_Test(decimal money)
        {
            Account actual = new Account(man, gradation)
            {
                Balance = 10000,
                BonusePoints = 200

            };

            decimal prevBalance = actual.Balance;
            uint prevPoint = actual.BonusePoints;
            actual.Withdraw(money);
            Assert.AreEqual(actual.Balance, prevBalance - money);
            Assert.AreEqual(actual.BonusePoints, prevPoint - (uint)(money / 40) * (actual.CostOfBalance + actual.CostOfFiiling));
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bank.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WithdrawFromAccount()
        {
            //Arrange
            var account = new Account(123, 123, 500m);

            var expectedBalance = 400m;
            var amount = 100m;
            //Act

            account.Withdraw(amount);

            //assert
            Assert.AreEqual(expectedBalance, account.Balance);
        }

        [TestMethod]
        public void DepositNegative()
        {
            //Arrange
            var account = new Account(123, 123, 500m);
            var expectedResult = false;

            var expectedBalance = 500m;
            var amount = -100m;
            //Act

            var result = account.Deposit(amount);

            //assert
            Assert.AreEqual(expectedBalance, account.Balance);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Deposit()
        {
            //Arrange
            var account = new Account(123, 123, 500m);
            var expectedResult = true;

            var expectedBalance = 600m;
            var amount = 100m;
            //Act

            var result = account.Deposit(amount);

            //assert
            Assert.AreEqual(expectedBalance, account.Balance);
            Assert.AreEqual(expectedResult, result);
        }
    }
}

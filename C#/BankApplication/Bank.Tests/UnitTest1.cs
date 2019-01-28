using System;
using System.Security.Principal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bank.Tests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
            
            //arrange
            var a = 5;
            var b = 7;

            var expectedResult = 12;

            //act

            var result = Summera(a, b);

            //assert
            Assert.AreEqual(expectedResult, result);

        }
        [TestMethod]
        public void AdderaNegativtTal()
        {
            //arrange
            var a = -5;
            var b = -7;

            var expectedResult = -12;

            //act

            var result = Summera(a, b);

            //assert
            Assert.AreEqual(expectedResult, result);

        }

        [TestMethod]

        public void WithdrawFromAccount()
        {
            //Arrange
            var account = new Account(123, 123, 500m);

            var expectedBalance = 600m;
            var amount = 100m;
            //Act

            account.Deposit(amount);

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

        private int Summera(int a, int b)
        {
            return a+b;
        }
    }
}

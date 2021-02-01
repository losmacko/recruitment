using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Recruitment.Common.Models;
using Recruitment.HashFunction.Services;
using Recruitment.HashFunction.Tests._Utills;

namespace Recruitment.HashFunction.Tests.Services
{
    [TestFixture]
    class HashTests
    {
        [Test] 
        [AutoMoqData]
        public void AreNotNull(LoginDataRequest loginData, Hash sut)
        {
            //Act
            var data = sut.GenerateHash(loginData);
            
            //Arrange
            Assert.NotNull(data);
        }

        [Test]
        [AutoMoqData]
        public void AfterEachCallResultAreSame(LoginDataRequest loginData, Hash sut)
        {
            //Act
            var result = sut.GenerateHash(loginData);
            var result2 = sut.GenerateHash(loginData);

            //Arrange
            Assert.AreEqual(result, result2);
        }


        [Test]
        [AutoMoqData]
        public void CheckSumShouldBeGeneratedForEmptyString(Hash sut)
        {
            //Arrange
            var loginData = new LoginDataRequest();

            //Act
            var result = sut.GenerateHash(loginData);

            //Arrange
            Assert.NotNull(result);
        }
    }
}

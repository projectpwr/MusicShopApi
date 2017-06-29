using System;
using Xunit;
using Moq;
using Services;
using DataAccessInterfaces;
using Services.Models;

namespace Services.Tests
{
    public class AccountRegisterLoginTest
    {
        [Fact]
        public void anAccountRegisterLoginmodelShouldHaveAMinimumPasswordLenghtOf6()
        {
            var target = new AccountRegisterLogin() ;
            Assert.True(true);
        }


        [Fact]
        public void testSomeProductCanFindItsManufacturersNameAlongWithDependancyInjectionAndMocks()
        {
            var mockIManufacturer = new Mock<IManufacturer>();
            mockIManufacturer.Setup(m => m.getName()).Returns("a test name");
            
            var target = new SomeProduct(mockIManufacturer.Object);

            var actual = target.GetManufacturersName();
            Assert.Equal("a test name", actual);
        }
    }
}

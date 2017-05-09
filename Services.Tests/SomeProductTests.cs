using System;
using Xunit;
using Moq;
using Services;
using DataAccessInterfaces;

namespace Services.Tests
{
    public class SomeProductTests
    {
        [Fact]
        public void aTestThatAutoFailsShouldFail()
        {
            Assert.False(false);
        }

        [Fact]
        public void anEmptyTestShouldPass()
        {
        }

        [Fact]
        public void testSomeProductCanFindItsManufacturersNameAlongWithDependancyInjectionAndMocks()
        {
            var mockIManufacturer = new Mock<IManufacturer>();
            mockIManufacturer.Setup(m => m.getName()).Returns("a test name");
            
            var target = new SomeProduct(mockIManufacturer.Object);

            var actual = target.GetManufacturersName();
            Assert.Equal("a test nameS", actual);
        }
    }
}
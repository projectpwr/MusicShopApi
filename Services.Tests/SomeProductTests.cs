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
        public void TestThatAutoFailsShouldFail()
        {
            Assert.False(false);
        }

        [Fact]
        public void EmptyTestShouldPass()
        {
        }

        [Fact]
        public void SomeProductCanFindItsManufacturersNameAlongWithDependancyInjectionAndMocks()
        {
            /*
            var mockIManufacturer = new Mock<IManufacturer>();
            mockIManufacturer.Setup(m => m.getName()).Returns("a test name");
            
            var target = new SomeProduct(mockIManufacturer.Object);

            var actual = target.GetManufacturersName();
            Assert.Equal("a test name", actual);
            */
        }
    }
}

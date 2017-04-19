using System;
using Xunit;
using Models;

namespace Models.Tests
{
    public class Class1Test
    {
        [Fact]
        public void someMethodShouldDoSomething()
        {
        }

        [Fact]
        public void someMethodShouldDoSomething222()
        {
            var thing = new Class1();
            var expected = "Oh hi there";
            var actual = thing.something();
            Assert.Equal(expected, actual);
        }
    }
}

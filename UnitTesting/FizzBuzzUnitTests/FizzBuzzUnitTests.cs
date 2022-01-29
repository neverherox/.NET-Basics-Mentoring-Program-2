using System;
using FB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzzUnitTests
{
    [TestClass]
    public class FizzBuzzUnitTests
    {
        [TestMethod]
        [DataRow(3, "Fizz")]
        [DataRow(5, "Buzz")]
        [DataRow(15, "FizzBuzz")]
        [DataRow(16, "16")]

        public void Calculate_Number_ReturnsValidString(int number, string expected)
        {
            var fizzBuzz = new FizzBuzz();

            var result = fizzBuzz.Calculate(number);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(101)]
        public void Calculate_Number_ThrowsArgumentOutOfRangeException(int number)
        {
            var fizzBuzz = new FizzBuzz();
            Func<int, string> func = fizzBuzz.Calculate;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                func(number));
        }
    }
}

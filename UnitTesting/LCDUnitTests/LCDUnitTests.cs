using System;
using LCD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LCDUnitTests
{
    [TestClass]
    public class LCDUnitTests
    {
        [TestMethod]
        [DataRow(910, "._....._.\n|_|..||.|\n..|..||_|\n")]
        public void Convert_Number_ReturnsValidRepresentation(int number, string expected)
        {
            var result = LCDConverter.Convert(number);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Convert_Negative_ThrowsArgumentException()
        {
            var number = -910;
            Func<int, string> func = LCDConverter.Convert;

            Assert.ThrowsException<ArgumentException>(() => func(number));
        }
    }
}

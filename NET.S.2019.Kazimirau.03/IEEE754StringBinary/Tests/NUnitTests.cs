﻿using NUnit.Framework;

namespace IEEE754StringBinary.Tests
{
    [TestFixture]
    public class NUnitTests
    {
        [Test]
        public void IEEE754Converter_ConvertGetWholePart_Test()
        {
            Assert.AreEqual("1100", IEEE754Converter.GetWholePart(12.375));
        }

        [Test]
        public void IEEE754Converter_ConvertGetFractionalPart_Test()
        {
            Assert.AreEqual("011", IEEE754Converter.GetFractionalPart(12.375));
        }

        [Test]
        public void IEEE754Converter_ConvertGetExponenta()
        {
            Assert.AreEqual("10000000110", IEEE754Converter.GetExponenta(255.255));
        }
        [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, ExpectedResult = "0100000111101111111111111111111111111111111000000000000000000000")]
        [TestCase(double.MinValue, ExpectedResult = "1111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.MaxValue, ExpectedResult = "0111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.Epsilon, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000001")]
        [TestCase(double.NaN, ExpectedResult = "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(-0.0, ExpectedResult = "1000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(0.0, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000000")]
        public string IEEE754Converter_Convert_Test(double number) => IEEE754Converter.Convert(number);
    }
}
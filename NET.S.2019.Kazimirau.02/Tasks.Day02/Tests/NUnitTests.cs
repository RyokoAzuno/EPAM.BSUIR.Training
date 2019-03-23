using NUnit.Framework;
using System;

namespace Tasks.Day02.Tests
{
    [TestFixture]
    public class NUnitTests
    {
        #region InsertNumberTests
        [Test]
        public void InsertNumber_Test1()
        {
            Assert.AreEqual(120, Tasks.InsertNumber(8, 15, 3, 8));
        }

        [Test]
        public void InsertNumber_Test2()
        {
            Assert.AreEqual(15, Tasks.InsertNumber(15, 15, 0, 0));
        }

        [Test]
        public void InsertNumber_Test3()
        {
            Assert.AreEqual(9, Tasks.InsertNumber(8, 15, 0, 0));
        }
        #endregion

        #region FindNextBiggerNumberTests
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public int FindNextBiggerNumber_Test(int n) => Tasks.FindNextBiggerNumber(n);
        #endregion

        #region FilterDigitTests
        [Test]
        public void FilterDigit_Test()
        {
            var arr = new[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            CollectionAssert.AreEqual(new[] { 7, 7, 70, 17 }, Tasks.FilterDigit(arr, 7));
        }
        #endregion

        #region FindNthRootTests
        [TestCase(1, 5, 0.0001, ExpectedResult = 1)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        [TestCase(0.0081, 4, 0.1, ExpectedResult = 0.3)]
        [TestCase(-0.008, 3, 0.1, ExpectedResult = -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]
        public double FindNthRoot_Test(double number, int n, double eps) => Tasks.FindNthRoot(number, n, eps);

        [Test]
        public void FindNthRoot_ArgumentOutOfRangeException_Test()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Tasks.FindNthRoot(8, 15, -7));
            Assert.Throws<ArgumentOutOfRangeException>(() => Tasks.FindNthRoot(8, 15, -0.6));
        }
        #endregion
    }
}

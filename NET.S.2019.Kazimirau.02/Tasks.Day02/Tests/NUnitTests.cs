using NUnit.Framework;

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

        #region FindNextBiggerNumber
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
    }
}

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
    }
}

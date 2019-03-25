using NUnit.Framework;

namespace GCD.Tests
{
    [TestFixture]
    public class NUnitTests
    {
        #region BinaryGcd
        [TestCase(30, 12, ExpectedResult = 6)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(8, 9, ExpectedResult = 1)]
        [TestCase(50, 250, ExpectedResult = 50)]
        [TestCase(10927782, -6902514, ExpectedResult = 846)]
        [TestCase(-10234567, -234568989, ExpectedResult = 97)]
        [TestCase(0, -301, ExpectedResult = 301)]
        [TestCase(-1590771464, 0, ExpectedResult = 1590771464)]
        [TestCase(10927782, 0, ExpectedResult = 10927782)]
        public int BinaryGcdTests(int a, int b) => MyGCD.BinaryGcd(a, b);

        [Test]
        public void BinaryGcdTest_WithTwoZeroNumbers_ThrowArgumentException()
        {
            Assert.Throws<System.ArgumentException>(() => MyGCD.BinaryGcd(0, 0));
        }
        #endregion

        #region EuclideanGcd
        [TestCase(30, 12, ExpectedResult = 6)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(8, 9, ExpectedResult = 1)]
        [TestCase(50, 250, ExpectedResult = 50)]
        [TestCase(10927782, -6902514, ExpectedResult = 846)]
        [TestCase(-10234567, -234568989, ExpectedResult = 97)]
        [TestCase(0, -301, ExpectedResult = 301)]
        [TestCase(-1590771464, 0, ExpectedResult = 1590771464)]
        [TestCase(10927782, 0, ExpectedResult = 10927782)]
        public int EuclideanGcdTests(int a, int b) => MyGCD.EuclideanGcd(a, b);

        [Test]
        public void EuclideanGcdTest_WithTwoZeroNumbers_ThrowArgumentException()
        {
            Assert.Throws<System.ArgumentException>(() => MyGCD.EuclideanGcd(0, 0));
        }
        #endregion

        [TestCase(85886, 94344, 73964, 42448, ExpectedResult = 2)]
        [TestCase(85884, 94344, 73464, 42448, ExpectedResult = 4)]
        [TestCase(85888, 94848, 73464, 42448, 98888, ExpectedResult = 8)]
        public int EuclideanGcd_WithParams_Tests(params int[] arr) => MyGCD.EuclideanGcd(arr);
    }
}

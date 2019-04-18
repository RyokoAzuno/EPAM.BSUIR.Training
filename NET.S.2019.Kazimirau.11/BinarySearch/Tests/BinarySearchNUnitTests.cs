using NUnit.Framework;

namespace BinarySearch.Tests
{
    [TestFixture]
    class BinarySearchNUnitTests
    {
        [TestCase(5, new[] {0, 1, 2, 3, 4, 5 }, ExpectedResult = 5)]
        [TestCase(4, new[] { 0, 1, 2, 3, 4, 5 }, ExpectedResult = 4)]
        [TestCase(3, new[] { 0, 1, 2, 3, 4, 5 }, ExpectedResult = 3)]
        [TestCase(1, new[] { 0, 1, 2, 3, 4, 5 }, ExpectedResult = 1)]
        [TestCase(0, new[] { 0, 1, 2, 3, 4, 5 }, ExpectedResult = 0)]
        [TestCase(-2, new[] { -5, -2, 0, 8, 12, 23, 45, 51 }, ExpectedResult = 1)]
        [TestCase(-7, new[] { -5, -2, 0, 8, 12, 23, 45, 51 }, ExpectedResult = -1)]
        public int BinarySearch_Int32_Tests(int key, int[] arr) => BinarySearch.Search(key, arr);

        [TestCase(5.7, new[] { 0, 1.1, 2.3, 3.9, 4.2, 5.7 }, ExpectedResult = 5)]
        [TestCase(4.2, new[] { 0, 1.1, 2.3, 3.9, 4.2, 5.7 }, ExpectedResult = 4)]
        [TestCase(3.9, new[] { 0, 1.1, 2.3, 3.9, 4.2, 5.7 }, ExpectedResult = 3)]
        [TestCase(1.1, new[] { 0, 1.1, 2.3, 3.9, 4.2, 5.7 }, ExpectedResult = 1)]
        [TestCase(0, new[] { 0, 1.1, 2.3, 3.9, 4.2, 5.7 }, ExpectedResult = 0)]
        [TestCase(-2.84, new[] { -5.12, -2.84, 0, 8.56, 12.39, 23.54, 45.7, 51.2 }, ExpectedResult = 1)]
        [TestCase(-7, new[] { -5.12, -2.84, 0, 8.56, 12.39, 23.54, 45.7, 51.2 }, ExpectedResult = -1)]
        public int BinarySearch_Double_Tests(double key, double[] arr) => BinarySearch.Search(key, arr);

    }
}

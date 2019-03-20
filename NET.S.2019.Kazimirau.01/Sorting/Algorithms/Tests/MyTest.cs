using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class MyTest
    {
        [Test]
        public void QuickSort_Test()
        {
            int[] array1 = { -2, 5, -1, 3, 1, 2, -3, 4, 0 };
            SortingAlgorithm alg = new QuickSortAlgorithm(array1);
            alg.Sort();

            CollectionAssert.AreEquivalent(new[] { -3, -2, -1, 0, 1, 2, 3, 4, 5 }, array1);
        }

        [Test]
        public void MergeSort_Test()
        {
            int[] array1 = { -2, 5, -1, 3, 1, 2, -3, 4, 0 };
            SortingAlgorithm alg = new MergeSortAlgorithm(array1);
            alg.Sort();

            CollectionAssert.AreEquivalent(new[] { -3, -2, -1, 0, 1, 2, 3, 4, 5 }, array1);
        }
    }
}

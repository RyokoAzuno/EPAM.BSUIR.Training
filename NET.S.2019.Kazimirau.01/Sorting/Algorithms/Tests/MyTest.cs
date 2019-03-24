using NUnit.Framework;
using System;

namespace Algorithms.Tests
{
    [TestFixture]
    public class MyTest
    {
        private SortingContext _sortingContext;

        [SetUp]
        public void Init()
        {
            _sortingContext = new SortingContext();
        }

        #region QuickSort Tests
        [Test]
        public void QuickSort_Test()
        {
            int[] array = { -2, 5, -1, 3, 1, 2, -3, 4, 0 };
            _sortingContext.SetAlgorithm(new QuickSortAlgorithm(array));
            _sortingContext.Sort();

            CollectionAssert.AreEquivalent(new[] { -3, -2, -1, 0, 1, 2, 3, 4, 5 }, array);
        }

        [Test]
        public void QuickSort_Random_LargeArray_Test()
        {
            int[] array = SortingAlgorithm.CreateRandomArray(5000);
            int[] expectedArr = new int[5000];

            for (int i = 0; i < array.Length; i++)
            {
                expectedArr[i] = array[i];
            }

            _sortingContext.SetAlgorithm(new QuickSortAlgorithm(array));
            _sortingContext.Sort();

            CollectionAssert.AreEquivalent(expectedArr, array);
        }

        [Test]
        public void QuickSort_ArgumentNullException_Test()
        {
            Assert.Throws<ArgumentNullException>(() => new QuickSortAlgorithm(null));
        }
        #endregion

        #region MergeSort Tests
        [Test]
        public void MergeSort_Test()
        {
            int[] array = { -2, 5, -1, 3, 1, 2, -3, 4, 0, -8 };
            _sortingContext.SetAlgorithm(new MergeSortAlgorithm(array));
            _sortingContext.Sort();

            CollectionAssert.AreEquivalent(new[] { -8, -3, -2, -1, 0, 1, 2, 3, 4, 5 }, array);
        }

        [Test]
        public void MergeSort_Random_LargeArray_Test()
        {
            int[] array = SortingAlgorithm.CreateRandomArray(5000);
            int[] expectedArr = new int[5000];

            for (int i = 0; i < array.Length; i++)
            {
                expectedArr[i] = array[i];
            }

            _sortingContext.SetAlgorithm(new MergeSortAlgorithm(array));
            _sortingContext.Sort();

            CollectionAssert.AreEquivalent(expectedArr, array);
        }

        [Test]
        public void MergeSort_ArgumentNullException_Test()
        {
            Assert.Throws<ArgumentNullException>(() => new MergeSortAlgorithm(null));
        }
        #endregion
    }
}

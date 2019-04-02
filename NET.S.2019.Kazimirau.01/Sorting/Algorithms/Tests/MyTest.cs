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
            CollectionAssert.AreEquivalent(new[] { 0 }, new[] { 0 });
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
            CollectionAssert.AreEquivalent(new[] { 0 }, new[] { 0 });
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

        #region BubbleSort Tests
        [Test]
        public void BubbleSort_Test()
        {
            int[] array = { -2, 5, -1, 3, 1, 2, -3, 4, 0, -8 };
            _sortingContext.SetAlgorithm(new BubbleSortAlgorithm(array));
            _sortingContext.Sort();

            CollectionAssert.AreEquivalent(new[] { -8, -3, -2, -1, 0, 1, 2, 3, 4, 5 }, array);
            CollectionAssert.AreEquivalent(new[] { 0 }, new[] { 0 });
        }

        [Test]
        public void BubbleSort_Random_LargeArray_Test()
        {
            int[] array = SortingAlgorithm.CreateRandomArray(5000);
            int[] expectedArr = new int[5000];

            for (int i = 0; i < array.Length; i++)
            {
                expectedArr[i] = array[i];
            }

            _sortingContext.SetAlgorithm(new BubbleSortAlgorithm(array));
            _sortingContext.Sort();

            CollectionAssert.AreEquivalent(expectedArr, array);
        }

        [Test]
        public void BubbleSort_ArgumentNullException_Test()
        {
            Assert.Throws<ArgumentNullException>(() => new BubbleSortAlgorithm(null));
        }
        #endregion

        #region SelectionSort Tests
        [Test]
        public void SelectionSort_Test()
        {
            int[] array = { -2, 5, -1, 3, 1, 2, -3, 4, 0, -8 };
            _sortingContext.SetAlgorithm(new SelectionSortAlgorithm(array));
            _sortingContext.Sort();

            CollectionAssert.AreEquivalent(new[] { -8, -3, -2, -1, 0, 1, 2, 3, 4, 5 }, array);
            CollectionAssert.AreEquivalent(new[] { 0 }, new[] { 0 });
        }

        [Test]
        public void SelectionSort_Random_LargeArray_Test()
        {
            int[] array = SortingAlgorithm.CreateRandomArray(5000);
            int[] expectedArr = new int[5000];

            for (int i = 0; i < array.Length; i++)
            {
                expectedArr[i] = array[i];
            }

            _sortingContext.SetAlgorithm(new SelectionSortAlgorithm(array));
            _sortingContext.Sort();

            CollectionAssert.AreEquivalent(expectedArr, array);
        }

        [Test]
        public void SelectionSort_ArgumentNullException_Test()
        {
            Assert.Throws<ArgumentNullException>(() => new SelectionSortAlgorithm(null));
        }
        #endregion

        #region SortingContext Tests
        [Test]
        public void SortingContext_ConstructorAndMethod_ArgumentNullException_Test()
        {
            Assert.Throws<ArgumentNullException>(() => new SortingContext(null));
            Assert.Throws<ArgumentNullException>(() => new SortingContext().SetAlgorithm(null));
        }
        #endregion

        
    }
}

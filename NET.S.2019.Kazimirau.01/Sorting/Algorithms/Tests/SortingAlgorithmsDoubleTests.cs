using NUnit.Framework;
using System;

namespace Algorithms.Tests
{
    [TestFixture]
    public class SortingAlgorithmsDoubleTests
    {
        private SortingContext<double> _sortingContext;

        [SetUp]
        public void Init()
        {
            _sortingContext = new SortingContext<double>();
        }

        #region QuickSort Tests
        [Test]
        public void QuickSort_Test()
        {
            double[] array = { -6.2, 5.82, -11.56, 13.34, 1.8, 2.98, -13.46, 4.34, 0.0 };
            _sortingContext.SetAlgorithm(new QuickSortAlgorithm<double>(array));
            _sortingContext.Sort();

            CollectionAssert.AreEquivalent(new[] { -13.46, -11.56, -6.2, 0.0, 1.8, 2.98, 4.34, 5.82, 13.34 }, array);
            CollectionAssert.AreEquivalent(new[] { 0 }, new[] { 0 });
        }

        [Test]
        public void QuickSort_Random_LargeArray_Test()
        {
            double[] array = SortingAlgorithm<double>.CreateDoubleRandomArray(5000);
            double[] expectedArr = new double[5000];

            for (int i = 0; i < array.Length; i++)
            {
                expectedArr[i] = array[i];
            }

            _sortingContext.SetAlgorithm(new QuickSortAlgorithm<double>(array));
            _sortingContext.Sort();

            CollectionAssert.AreEquivalent(expectedArr, array);
        }

        [Test]
        public void QuickSort_ArgumentNullException_Test()
        {
            Assert.Throws<ArgumentNullException>(() => new QuickSortAlgorithm<double>(null));
        }
        #endregion

        #region MergeSort Tests
        [Test]
        public void MergeSort_Test()
        {
            double[] array = { -2, 5, -1, 3, 1, 2, -3, 4, 0, -8 };
            _sortingContext.SetAlgorithm(new MergeSortAlgorithm<double>(array));
            _sortingContext.Sort();

            CollectionAssert.AreEquivalent(new[] { -8, -3, -2, -1, 0, 1, 2, 3, 4, 5 }, array);
            CollectionAssert.AreEquivalent(new[] { 0 }, new[] { 0 });
        }

        [Test]
        public void MergeSort_Random_LargeArray_Test()
        {
            double[] array = SortingAlgorithm<double>.CreateDoubleRandomArray(5000);
            double[] expectedArr = new double[5000];

            for (int i = 0; i < array.Length; i++)
            {
                expectedArr[i] = array[i];
            }

            _sortingContext.SetAlgorithm(new MergeSortAlgorithm<double>(array));
            _sortingContext.Sort();

            CollectionAssert.AreEquivalent(expectedArr, array);
        }

        [Test]
        public void MergeSort_ArgumentNullException_Test()
        {
            Assert.Throws<ArgumentNullException>(() => new MergeSortAlgorithm<double>(null));
        }
        #endregion

        #region BubbleSort Tests
        [Test]
        public void BubbleSort_Test()
        {
            double[] array = { -2, 5, -1, 3, 1, 2, -3, 4, 0, -8 };
            _sortingContext.SetAlgorithm(new BubbleSortAlgorithm<double>(array));
            _sortingContext.Sort();

            CollectionAssert.AreEquivalent(new[] { -8, -3, -2, -1, 0, 1, 2, 3, 4, 5 }, array);
            CollectionAssert.AreEquivalent(new[] { 0 }, new[] { 0 });
        }

        [Test]
        public void BubbleSort_Random_LargeArray_Test()
        {
            double[] array = SortingAlgorithm<int>.CreateDoubleRandomArray(5000);
            double[] expectedArr = new double[5000];

            for (int i = 0; i < array.Length; i++)
            {
                expectedArr[i] = array[i];
            }

            _sortingContext.SetAlgorithm(new BubbleSortAlgorithm<double>(array));
            _sortingContext.Sort();

            CollectionAssert.AreEquivalent(expectedArr, array);
        }

        [Test]
        public void BubbleSort_ArgumentNullException_Test()
        {
            Assert.Throws<ArgumentNullException>(() => new BubbleSortAlgorithm<double>(null));
        }
        #endregion

        #region SelectionSort Tests
        [Test]
        public void SelectionSort_Test()
        {
            double[] array = { -2, 5, -1, 3, 1, 2, -3, 4, 0, -8 };
            _sortingContext.SetAlgorithm(new SelectionSortAlgorithm<double>(array));
            _sortingContext.Sort();

            CollectionAssert.AreEquivalent(new[] { -8, -3, -2, -1, 0, 1, 2, 3, 4, 5 }, array);
            CollectionAssert.AreEquivalent(new[] { 0 }, new[] { 0 });
        }

        [Test]
        public void SelectionSort_Random_LargeArray_Test()
        {
            double[] array = SortingAlgorithm<double>.CreateDoubleRandomArray(5000);
            double[] expectedArr = new double[5000];

            for (int i = 0; i < array.Length; i++)
            {
                expectedArr[i] = array[i];
            }

            _sortingContext.SetAlgorithm(new SelectionSortAlgorithm<double>(array));
            _sortingContext.Sort();

            CollectionAssert.AreEquivalent(expectedArr, array);
        }

        [Test]
        public void SelectionSort_ArgumentNullException_Test()
        {
            Assert.Throws<ArgumentNullException>(() => new SelectionSortAlgorithm<double>(null));
        }
        #endregion

        #region SortingContext Tests
        [Test]
        public void SortingContext_ConstructorAndMethod_ArgumentNullException_Test()
        {
            Assert.Throws<ArgumentNullException>(() => new SortingContext<double>(null));
            Assert.Throws<ArgumentNullException>(() => new SortingContext<double>().SetAlgorithm(null));
        }
        #endregion

        
    }
}

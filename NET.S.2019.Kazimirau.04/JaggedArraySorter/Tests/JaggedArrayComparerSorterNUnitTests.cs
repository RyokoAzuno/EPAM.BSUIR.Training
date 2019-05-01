using JaggedArraySorter.Comparators;
using NUnit.Framework;
using System;

namespace JaggedArraySorter.Tests
{
    [TestFixture]
    public class JaggedArrayComparerSorterNUnitTests
    {
        private int[][] arr;

        [SetUp]
        public void SetUp()
        {
            arr = new int[4][] {
                new []{ -3, 0, 1, 2, 4, 6, 9, 12 },
                new []{-4, -3, -2, -1, 6, 7, 20, 22 },
                new []{ -4, -2, 0, 0, 3, 11, 19, 26 },
                new []{ -13, -10, -9, -2, 4, 16, 21, 52 }

            };
        }
        [TearDown]
        public void TearDown()
        {
            arr = null;
        }
        #region Sort Tests
        [Test]
        public void JaggedArrayComparerSorter_Sort_ByAscending_Test()
        {
            var arr = new int[4][] {
                new []{ 1, 0, 2, 9, 6, 4, -3, 12 },
                new []{-1, 20, -2, 7, 6, -4, -3, 22 },
                new []{ 11, 0, -2, 19, 26, -4, 3, 0 },
                new []{ 21, -10, 52, -9, 16, 4, -13, -2 }
            };
            var expectedArr = new int[4][] {
                new []{ -3, 0, 1, 2, 4, 6, 9, 12 },
                new []{-4, -3, -2, -1, 6, 7, 20, 22 },
                new []{ -4, -2, 0, 0, 3, 11, 19, 26 },
                new []{ -13, -10, -9, -2, 4, 16, 21, 52 }
            };

            JaggedArrayComparerSorter.Sort(arr, (a, b) => a > b);

            Assert.AreEqual(expectedArr, arr);
        }

        [Test]
        public void JaggedArrayComparerSorter_Sort_ByDescending_Test()
        {
            var arr = new int[4][] {
                new []{ 1, 0, 2, 9, 6, 4, -3, 12 },
                new []{-1, 20, -2, 7, 6, -4, -3, 22 },
                new []{ 11, 0, -2, 19, 26, -4, 3, 0 },
                new []{ 21, -10, 52, -9, 16, 4, -13, -2 }
            };
            var expectedArr = new int[4][] {
                new []{ 12, 9, 6, 4, 2, 1, 0, -3 },
                new []{ 22, 20, 7, 6, -1, -2, -3, -4 },
                new []{ 26, 19, 11, 3, 0, 0, -2, -4 },
                new []{ 52, 21, 16, 4, -2, -9, -10, -13 }
            };

            JaggedArrayComparerSorter.Sort(arr, (a, b) => a < b);

            Assert.AreEqual(expectedArr, arr);
        }

        [Test]
        public void JaggedArrayComparerSorter_Sort_ArgumentNullException_Test()
        {
            var arr = new int[2][] {
                new []{ 12, 9, 6 },
                new []{ 6, -1, -2 },
            };
            Assert.Throws<ArgumentNullException>(() => JaggedArrayComparerSorter.Sort(null, (a, b) => a > b));
            Assert.Throws<ArgumentNullException>(() => JaggedArrayComparerSorter.Sort(arr, null));
        }
        #endregion

        #region SortRows Tests
        [Test]
        public void JaggedArrayComparerSorter_SortRows_AscendingRowsSum_Test()
        {
            var expectedArr = new int[4][] {
                new []{ -3, 0, 1, 2, 4, 6, 9, 12 },         // 31
                new []{-4, -3, -2, -1, 6, 7, 20, 22 },      // 45
                new []{ -4, -2, 0, 0, 3, 11, 19, 26 },      // 53
                new []{ -13, -10, -9, -2, 4, 16, 21, 52 }   // 59
            };

            JaggedArrayComparerSorter.SortRows(arr, new JaggedArrayComparer { Comparer = SortBy.AscSum }.Compare);

            Assert.AreEqual(expectedArr, arr);
        }
        [Test]
        public void JaggedArrayComparerSorter_SortRows_DescendingRowsSum_Test()
        {
            var expectedArr = new int[4][] {
                new []{ -13, -10, -9, -2, 4, 16, 21, 52 },   // 59
                new []{ -4, -2, 0, 0, 3, 11, 19, 26 },      // 53
                new []{-4, -3, -2, -1, 6, 7, 20, 22 },      // 45
                new []{ -3, 0, 1, 2, 4, 6, 9, 12 }         // 31
            };

            JaggedArrayComparerSorter.SortRows(arr, new JaggedArrayComparer { Comparer = SortBy.DescSum }.Compare);

            Assert.AreEqual(expectedArr, arr);
        }

        [Test]
        public void JaggedArrayComparerSorter_SortRows_AscendingRowsMaxElement_Test()
        {
            var expectedArr = new int[4][] {
                new []{ -3, 0, 1, 2, 4, 6, 9, 12 },
                new []{-4, -3, -2, -1, 6, 7, 20, 22 },
                new []{ -4, -2, 0, 0, 3, 11, 19, 26 },
                new []{ -13, -10, -9, -2, 4, 16, 21, 52 }   
            };

            JaggedArrayComparerSorter.SortRows(arr, new JaggedArrayComparer { Comparer = SortBy.AscMax }.Compare);

            Assert.AreEqual(expectedArr, arr);
        }

        [Test]
        public void JaggedArrayComparerSorter_SortRows_DescendingRowsMaxElement_Test()
        {
            var expectedArr = new int[4][] {
                new []{ -13, -10, -9, -2, 4, 16, 21, 52 },
                new []{ -4, -2, 0, 0, 3, 11, 19, 26 },
                new []{-4, -3, -2, -1, 6, 7, 20, 22 },
                new []{ -3, 0, 1, 2, 4, 6, 9, 12 }
            };

            JaggedArrayComparerSorter.SortRows(arr, new JaggedArrayComparer { Comparer = SortBy.DescMax }.Compare);

            Assert.AreEqual(expectedArr, arr);
        }

        [Test]
        public void JaggedArrayComparerSorter_SortRows_AscendingRowsMinElement_Test()
        {
            var expectedArr = new int[4][] {
                new []{ -3, 0, 1, 2, 4, 6, 9, 12 },
                new []{-4, -3, -2, -1, 6, 7, 20, 22 },
                new []{ -4, -2, 0, 0, 3, 11, 19, 26 },
                new []{ -13, -10, -9, -2, 4, 16, 21, 52 }
            };

            JaggedArrayComparerSorter.SortRows(arr, new JaggedArrayComparer { Comparer = SortBy.AscMax }.Compare);

            Assert.AreEqual(expectedArr, arr);
        }

        [Test]
        public void JaggedArrayComparerSorter_SortRows_DescendingRowsMinElement_Test()
        {
            var expectedArr = new int[4][] {
                new []{ -13, -10, -9, -2, 4, 16, 21, 52 },
                new []{ -4, -2, 0, 0, 3, 11, 19, 26 },
                new []{-4, -3, -2, -1, 6, 7, 20, 22 },
                new []{ -3, 0, 1, 2, 4, 6, 9, 12 }
            };

            JaggedArrayComparerSorter.SortRows(arr, new JaggedArrayComparer { Comparer = SortBy.DescMax }.Compare);

            Assert.AreEqual(expectedArr, arr);
        }

        [Test]
        public void JaggedArrayComparerSorter_SortRows_ArgumentNullException_Test()
        {
            Assert.Throws<ArgumentNullException>(() => JaggedArrayComparerSorter.SortRows(null, new JaggedArrayComparer { Comparer = SortBy.DescMax }.Compare));
        }
        #endregion
    }
}

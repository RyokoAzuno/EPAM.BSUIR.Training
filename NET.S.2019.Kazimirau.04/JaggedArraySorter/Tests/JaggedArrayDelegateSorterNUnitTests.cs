using JaggedArraySorter.Comparators;
using NUnit.Framework;
using System;

namespace JaggedArraySorter.Tests
{
    [TestFixture]
    public class JaggedArrayDelegateSorterNUnitTests
    {
        #region SortRows Tests
        [Test]
        public void JaggedArrayDelegateSorter_SortRows_AscendingRowsSum_Test()
        {
            var arr = new int[4][] {
                    new []{ -3, 0, 1, 2, 4, 6, 9, 12 },
                    new []{-4, -3, -2, -1, 6, 7, 20, 22 },
                    new []{ -4, -2, 0, 0, 3, 11, 19, 26 },
                    new []{ -13, -10, -9, -2, 4, 16, 21, 52 }

                };
            var expectedArr = new int[4][] {
                    new []{ -3, 0, 1, 2, 4, 6, 9, 12 },         // 31
                    new []{-4, -3, -2, -1, 6, 7, 20, 22 },      // 45
                    new []{ -4, -2, 0, 0, 3, 11, 19, 26 },      // 53
                    new []{ -13, -10, -9, -2, 4, 16, 21, 52 }   // 59
                };

            JaggedArrayDelegateSorter.SortRows(arr, new JaggedArrayComparer { Comparer = SortBy.AscSum }.Compare);

            Assert.AreEqual(expectedArr, arr);
        }
        [Test]
        public void JaggedArrayDelegateSorter_SortRows_DescendingRowsSum_Test()
        {
            var arr = new int[4][] {
                    new []{ -3, 0, 1, 2, 4, 6, 9, 12 },
                    new []{-4, -3, -2, -1, 6, 7, 20, 22 },
                    new []{ -4, -2, 0, 0, 3, 11, 19, 26 },
                    new []{ -13, -10, -9, -2, 4, 16, 21, 52 }

                };
            var expectedArr = new int[4][] {
                    new []{ -13, -10, -9, -2, 4, 16, 21, 52 },   // 59
                    new []{ -4, -2, 0, 0, 3, 11, 19, 26 },      // 53
                    new []{-4, -3, -2, -1, 6, 7, 20, 22 },      // 45
                    new []{ -3, 0, 1, 2, 4, 6, 9, 12 }         // 31
                };

            JaggedArrayDelegateSorter.SortRows(arr, new JaggedArrayComparer { Comparer = SortBy.DescSum }.Compare);

            Assert.AreEqual(expectedArr, arr);
        }

        [Test]
        public void JaggedArrayDelegateSorter_SortRows_AscendingRowsMaxElement_Test()
        {
            var arr = new int[4][] {
                    new []{ -3, 0, 1, 2, 4, 6, 9, 12 },         // 12
                    new []{-4, -3, -2, -1, 6, 7, 20, 22 },      // 22
                    new []{ -4, -2, 0, 0, 3, 11, 19, 26 },      // 26
                    new []{ -13, -10, -9, -2, 4, 16, 21, 52 }   // 52

                };
            var expectedArr = new int[4][] {
                    new []{ -3, 0, 1, 2, 4, 6, 9, 12 },
                    new []{-4, -3, -2, -1, 6, 7, 20, 22 },
                    new []{ -4, -2, 0, 0, 3, 11, 19, 26 },
                    new []{ -13, -10, -9, -2, 4, 16, 21, 52 }
                };

            JaggedArrayDelegateSorter.SortRows(arr, new JaggedArrayComparer { Comparer = SortBy.AscMax }.Compare);

            Assert.AreEqual(expectedArr, arr);
        }

        [Test]
        public void JaggedArrayDelegateSorter_SortRows_DescendingRowsMaxElement_Test()
        {
            var arr = new int[4][] {
                    new []{ -3, 0, 1, 2, 4, 6, 9, 12 },         // 12
                    new []{-4, -3, -2, -1, 6, 7, 20, 22 },      // 22
                    new []{ -4, -2, 0, 0, 3, 11, 19, 26 },      // 26
                    new []{ -13, -10, -9, -2, 4, 16, 21, 52 }   // 52

                };
            var expectedArr = new int[4][] {
                    new []{ -13, -10, -9, -2, 4, 16, 21, 52 },
                    new []{ -4, -2, 0, 0, 3, 11, 19, 26 },
                    new []{-4, -3, -2, -1, 6, 7, 20, 22 },
                    new []{ -3, 0, 1, 2, 4, 6, 9, 12 }
                };

            JaggedArrayDelegateSorter.SortRows(arr, new JaggedArrayComparer { Comparer = SortBy.DescMax }.Compare);

            Assert.AreEqual(expectedArr, arr);
        }

        [Test]
        public void JaggedArrayDelegateSorter_SortRows_AscendingRowsMinElement_Test()
        {
            var arr = new int[4][] {
                    new []{ -3, 0, 1, 2, 4, 6, 9, 12 },         // -3
                    new []{-4, -3, -2, -1, 6, 7, 20, 22 },      // -4
                    new []{ -5, -2, 0, 0, 3, 11, 19, 26 },      // -5
                    new []{ -13, -10, -9, -2, 4, 16, 21, 52 }   // -13

                };
            var expectedArr = new int[4][] {
                    new []{ -3, 0, 1, 2, 4, 6, 9, 12 },
                    new []{-4, -3, -2, -1, 6, 7, 20, 22 },
                    new []{ -5, -2, 0, 0, 3, 11, 19, 26 },
                    new []{ -13, -10, -9, -2, 4, 16, 21, 52 }
                };

            JaggedArrayDelegateSorter.SortRows(arr, new JaggedArrayComparer { Comparer = SortBy.AscMax }.Compare);

            Assert.AreEqual(expectedArr, arr);
        }

        [Test]
        public void JaggedArrayDelegateSorter_SortRows_DescendingRowsMinElement_Test()
        {
            var arr = new int[4][] {
                    new []{ -3, 0, 1, 2, 4, 6, 9, 12 },         // 12
                    new []{-4, -3, -2, -1, 6, 7, 20, 22 },      // 22
                    new []{ -4, -2, 0, 0, 3, 11, 19, 26 },      // 26
                    new []{ -13, -10, -9, -2, 4, 16, 21, 52 }   // 52

                };
            var expectedArr = new int[4][] {
                    new []{ -13, -10, -9, -2, 4, 16, 21, 52 },
                    new []{ -4, -2, 0, 0, 3, 11, 19, 26 },
                    new []{-4, -3, -2, -1, 6, 7, 20, 22 },
                    new []{ -3, 0, 1, 2, 4, 6, 9, 12 }
                };

            JaggedArrayDelegateSorter.SortRows(arr, new JaggedArrayComparer { Comparer = SortBy.DescMax }.Compare);

            Assert.AreEqual(expectedArr, arr);
        }

        [Test]
        public void JaggedArrayDelegateSorter_SortRows_ArgumentNullException_Test()
        {
            Assert.Throws<ArgumentNullException>(() => JaggedArrayDelegateSorter.SortRows(null, new JaggedArrayComparer { Comparer = SortBy.DescMax }));
        }
#endregion
    }
}

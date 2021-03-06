﻿using JaggedArraySorter.Comparators;
using NUnit.Framework;
using System;

namespace JaggedArraySorter.Tests
{
    [TestFixture]
    public class JaggedArrayEnumSorterNUnitTests
    {
        #region Sort Tests
        [Test]
        public void JaggedArrayEnumSorter_Sort_ByAscending_Test()
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

            JaggedArrayEnumSorter.Sort(arr, (a, b) => a > b);

            Assert.AreEqual(expectedArr, arr);
        }

        [Test]
        public void JaggedArrayEnumSorter_Sort_ByDescending_Test()
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

            JaggedArrayEnumSorter.Sort(arr, (a, b) => a < b);

            Assert.AreEqual(expectedArr, arr);
        }

        [Test]
        public void JaggedArrayEnumSorter_Sort_ArgumentNullException_Test()
        {
            var arr = new int[2][] {
                new []{ 12, 9, 6 },
                new []{ 6, -1, -2 },
            };
            Assert.Throws<ArgumentNullException>(() => JaggedArrayEnumSorter.Sort(null, (a, b) => a > b));
            Assert.Throws<ArgumentNullException>(() => JaggedArrayEnumSorter.Sort(arr, null));
        }
        #endregion

        #region SortRows Tests
        [Test]
        public void JaggedArrayEnumSorter_SortRows_AscendingRowsSum_Test()
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

            JaggedArrayEnumSorter.SortRows(arr, SortBy.AscSum/*, Comparisons.AscSum*/);

            Assert.AreEqual(expectedArr, arr);
        }
        [Test]
        public void JaggedArrayEnumSorter_SortRows_DescendingRowsSum_Test()
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

            JaggedArrayEnumSorter.SortRows(arr, SortBy.DescSum);

            Assert.AreEqual(expectedArr, arr);
        }

        [Test]
        public void JaggedArrayEnumSorter_SortRows_AscendingRowsMaxElement_Test()
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

            JaggedArrayEnumSorter.SortRows(arr, SortBy.AscMax);

            Assert.AreEqual(expectedArr, arr);
        }

        [Test]
        public void JaggedArrayEnumSorter_SortRows_DescendingRowsMaxElement_Test()
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

            JaggedArrayEnumSorter.SortRows(arr, SortBy.DescMax);

            Assert.AreEqual(expectedArr, arr);
        }

        [Test]
        public void JaggedArrayEnumSorter_SortRows_AscendingRowsMinElement_Test()
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

            JaggedArrayEnumSorter.SortRows(arr, SortBy.AscMax);

            Assert.AreEqual(expectedArr, arr);
        }

        [Test]
        public void JaggedArrayEnumSorter_SortRows_DescendingRowsMinElement_Test()
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

            JaggedArrayEnumSorter.SortRows(arr, SortBy.DescMax);

            Assert.AreEqual(expectedArr, arr);
        }

        [Test]
        public void JaggedArrayEnumSorter_SortRows_ArgumentNullException_Test()
        {
            Assert.Throws<ArgumentNullException>(() => JaggedArrayEnumSorter.SortRows(null, SortBy.DescMax));
        }

        [Test]
        public void JaggedArrayEnumSorter_SortRows_ArgumentException_Test()
        {
            var arr = new int[2][] {
                new []{ 12, 9, 6 },
                new []{ 6, -1, -2 },
            };
            Assert.Throws<ArgumentException>(() => JaggedArrayEnumSorter.SortRows(arr, (SortBy)(-4)));
            Assert.Throws<ArgumentException>(() => JaggedArrayEnumSorter.SortRows(arr, (SortBy)(9)));
            //Assert.Throws<ArgumentException>(() => JaggedArraySorter.SortRows(arr, (Comparisons)(2)));
        }
        #endregion
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tasks.Day02.Tests
{
    [TestClass]
    public class MSTests
    {
        #region InsertNumberTests
        [TestMethod]
        public void InsertNumber_Test1()
        {
            Assert.AreEqual(120, Tasks.InsertNumber(8, 15, 3, 8));
        }

        [TestMethod]
        public void InsertNumber_Test2()
        {
            Assert.AreEqual(15, Tasks.InsertNumber(15, 15, 0, 0));
        }

        [TestMethod]
        public void InsertNumber_Test3()
        {
            Assert.AreEqual(9, Tasks.InsertNumber(8, 15, 0, 0));
        }
        #endregion

        #region InsertNumberLINQTests
        [TestMethod]
        public void InsertNumberLINQ_Test1()
        {
            Assert.AreEqual(120, Tasks.InsertNumberLINQ(8, 15, 3, 8));
        }

        [TestMethod]
        public void InsertNumberLINQ_Test2()
        {
            Assert.AreEqual(15, Tasks.InsertNumberLINQ(15, 15, 0, 0));
        }

        [TestMethod]
        public void InsertNumberLINQ_Test3()
        {
            Assert.AreEqual(9, Tasks.InsertNumberLINQ(8, 15, 0, 0));
        }
        #endregion

        #region FindNextBiggerNumberTests
        [TestMethod]
        [DataRow(12, 21)]
        [DataRow(513, 531)]
        [DataRow(2017, 2071)]
        [DataRow(414, 441)]
        [DataRow(144, 414)]
        [DataRow(1234321, 1241233)]
        [DataRow(1234126, 1234162)]
        [DataRow(3456432, 3462345)]
        [DataRow(10, -1)]
        [DataRow(20, -1)]
        [DataRow(22222222, -1)]
        [DataRow(777777777, -1)]
        [DataRow(987654321, -1)]
        [DataRow(777000000, -1)]
        [DataRow(777070000, 777700000)]
        public void FindNextBiggerNumber_Test(int n, int result)
        {
            Assert.AreEqual(result, Tasks.FindNextBiggerNumber(n));
        }

        [TestMethod]
        public void FindNextBiggerNumber_ArgumentException_Test()
        {
            Assert.ThrowsException<ArgumentException>(() => Tasks.FindNextBiggerNumber(-2));
        }
        #endregion

        #region FilterDigitTests
        [TestMethod]
        public void FilterDigit_Test()
        {
            var arr = new[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            CollectionAssert.AreEqual(new[] { 7, 7, 70, 17 }, Tasks.FilterDigit(arr, 7));
        }

        [TestMethod]
        public void FilterDigit_ArgumentException_Test()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Tasks.FilterDigit(null, -2));
        }
        #endregion

        #region FindNthRootTests
        [TestMethod]
        [DataRow(1, 5, 0.0001, 1)]
        [DataRow(8, 3, 0.0001, 2)]
        [DataRow(0.001, 3, 0.0001, 0.1)]
        [DataRow(0.04100625, 4, 0.0001, 0.45)]
        [DataRow(8, 3, 0.0001, 2)]
        [DataRow(0.0279936, 7, 0.0001, 0.6)]
        [DataRow(0.0081, 4, 0.1, 0.3)]
        [DataRow(-0.008, 3, 0.1, -0.2)]
        [DataRow(0.004241979, 9, 0.00000001, 0.545)]
        public void FindNthRoot_Test(double number, int n, double eps, double result) 
                    => Assert.AreEqual(result, Tasks.FindNthRoot(number, n, eps), Math.Pow(10, 2 - eps.ToString().Length));


        [TestMethod]
        public void FindNthRoot_ArgumentException_Test()
        {
            Assert.ThrowsException<ArgumentException>(() => Tasks.FindNthRoot(8, 15, -7));
            Assert.ThrowsException<ArgumentException>(() => Tasks.FindNthRoot(8, 15, -0.6));
            Assert.ThrowsException<ArgumentException>(() => Tasks.FindNthRoot(8, 15, 2));
            Assert.ThrowsException<ArgumentException>(() => Tasks.FindNthRoot(8, 15, -3));
            Assert.ThrowsException<ArgumentException>(() => Tasks.FindNthRoot(8, 15, -3));
        }
        #endregion
    }
}

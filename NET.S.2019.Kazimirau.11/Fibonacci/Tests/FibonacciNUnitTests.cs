using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Fibonacci.Tests
{
    [TestFixture]
    public class FibonacciNUnitTests
    {
        [TestCase(20, ExpectedResult = 6765)]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(2, ExpectedResult = 1)]
        [TestCase(0, ExpectedResult = 0)]
        public int FibonacciRecTests(int number) => MyFibonacci.FibonacciRec(number);

        [TestCase(20, ExpectedResult = 6765)]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(2, ExpectedResult = 1)]
        [TestCase(0, ExpectedResult = 0)]
        public int FibonacciTests(int number) => MyFibonacci.Fibonacci(number);

        [Test]
        public void Fibonacci_Negative_Numbers_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => MyFibonacci.FibonacciRec(-1));
            Assert.Throws<ArgumentException>(() => MyFibonacci.Fibonacci(-12));
        }

        [Test]
        public void FibonacciListTests()
        {
            List<int> lst1 = new List<int> { 1 };
            List<int> lst2 = new List<int> { 1, 1 };
            List<int> lst3 = new List<int> { 1, 1, 2 };
            List<int> lst4 = new List<int> { 1, 1, 2, 3 };
            List<int> lst7 = new List<int> { 1, 1, 2, 3, 5, 8, 13 };
            List<int> lst10 = new List<int> { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 };
            CollectionAssert.AreEquivalent(lst1, MyFibonacci.FibonacciList(1));
            CollectionAssert.AreEquivalent(lst2, MyFibonacci.FibonacciList(2));
            CollectionAssert.AreEquivalent(lst3, MyFibonacci.FibonacciList(3));
            CollectionAssert.AreEquivalent(lst4, MyFibonacci.FibonacciList(4));
            CollectionAssert.AreEquivalent(lst7, MyFibonacci.FibonacciList(7));
            CollectionAssert.AreEquivalent(lst10, MyFibonacci.FibonacciList(10));
            Assert.Throws<ArgumentException>(() => MyFibonacci.FibonacciList(0));
            Assert.Throws<ArgumentException>(() => MyFibonacci.FibonacciList(-5));
        }
    }
}

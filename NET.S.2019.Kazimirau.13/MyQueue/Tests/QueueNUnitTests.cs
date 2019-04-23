using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MyQueue.Tests
{
    [TestFixture]
    public class QueueNUnitTests
    {
        [Test]
        public void Queue_String_Test()
        {
            string[] names = { "John", "Mike", "Julia", "Steve", "Alice", "Mary", "Magnus" };
            Queue<string> myQueue = new Queue<string>();

            for (int i = 0; i < names.Length; ++i)
            {
                myQueue.Enqueue(names[i]);
            }

            Assert.AreEqual(names, myQueue.ToArray());
        }

        [Test]
        public void Queue_Int32_Test()
        {
            int[] names = { 5, 34, -8, -22, 9, 0, 1, -4, 29 };
            Queue<int> myQueue = new Queue<int>();

            for (int i = 0; i < names.Length; ++i)
            {
                myQueue.Enqueue(names[i]);
            }

            CollectionAssert.AreEqual(names, myQueue.ToArray());
        }

        [Test]
        public void Queue_Int32_Enumerator_Test()
        {
            int[] names = { 5, 34, -8, -22, 9, 0, 1, -4, 29 };
            Queue<int> myQueue = new Queue<int>();

            for (int i = 0; i < names.Length; ++i)
            {
                myQueue.Enqueue(names[i]);
            }

            List<int> results = new List<int>();
            foreach (var item in myQueue)
            {
                results.Add(item);
            }
            
            CollectionAssert.AreEqual(new[] { 5, 34, -8, -22, 9, 0, 1, -4, 29 }, results.ToArray());
        }

        [Test]
        public void Queue_Int32_ArgumentException_Tests()
        {
            Assert.Throws<ArgumentException>(() => new Queue<int>(-1));
            Assert.Throws<ArgumentException>(() => new Queue<int>(0));
        }
    }
}

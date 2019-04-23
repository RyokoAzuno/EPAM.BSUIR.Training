using NUnit.Framework;

namespace MyQueue.Tests
{
    [TestFixture]
    public class QueueNUnitTests
    {
        [Test]
        public void Queue_String_Tests()
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
        public void Queue_Int32_Tests()
        {
            int[] names = { 5, 34, -8, -22, 9, 0, 1, -4, 29 };
            Queue<int> myQueue = new Queue<int>();

            for (int i = 0; i < names.Length; ++i)
            {
                myQueue.Enqueue(names[i]);
            }

            Assert.AreEqual(names, myQueue.ToArray());
        }
    }
}

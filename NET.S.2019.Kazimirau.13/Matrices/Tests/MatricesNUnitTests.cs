using NUnit.Framework;

namespace Matrices.Tests
{
    [TestFixture]
    public class MatricesNUnitTests
    {
        [Test]
        public void Matrices_Int32_Add_Test()
        {
            int[,] arr1 = { { 1, 3 }, { 1, 0 } };
            int[,] arr2 = { { 0, 0 }, { 7, 5 } };
            SquareMatrix<int> m1 = new SquareMatrix<int>(2, arr1);
            SquareMatrix<int> m2 = new SquareMatrix<int>(2, arr2);

            SquareMatrix<int> m3 = m1.Add(m2);
            CollectionAssert.AreEqual(new[,] { { 1, 3 }, { 8, 5 } }, m3.ToArray());
        }
    }
}

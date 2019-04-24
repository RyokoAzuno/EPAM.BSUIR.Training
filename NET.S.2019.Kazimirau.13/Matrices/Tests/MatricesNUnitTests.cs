using NUnit.Framework;
using System;

namespace Matrices.Tests
{
    [TestFixture]
    public class MatricesNUnitTests
    {
        [Test]
        public void Matrices_Square_Int32_Operator_Add_Test()
        {
            int[,] arr1 = { { 1, 3 }, { 1, 0 } };
            int[,] arr2 = { { 0, 0 }, { 7, 5 } };
            SquareMatrix<int> m1 = new SquareMatrix<int>(arr1);
            SquareMatrix<int> m2 = new SquareMatrix<int>(arr2);

            SquareMatrix<int> m3 = m1 + m2;
            CollectionAssert.AreEqual(new[,] { { 1, 3 }, { 8, 5 } }, m3.ToArray());
        }

        [Test]
        public void Matrices_Square_Int32_OneDimArray_To_Matrix_Test()
        {
            int[] arr1 = { 1, 3, 5, 1, 0, 5, 4, 2, 1 };
            int[] arr2 = { 0, 0, 4, 7, 2, 5, 2, 1, 4 };
            SquareMatrix<int> m1 = new SquareMatrix<int>(arr1);
            SquareMatrix<int> m2 = new SquareMatrix<int>(arr2);

            SquareMatrix<int> m3 = m1 + m2;
            CollectionAssert.AreEqual(new[,] { { 1, 3, 9 }, { 8, 2, 10 }, { 6, 3, 5 } }, m3.ToArray());
        }

        [Test]
        public void Matrices_Diagonal_Int32_Operator_Add_Test()
        {
            int[,] arr1 = { { 1, 0 }, { 0, 4 } };
            int[,] arr2 = { { 3, 0 }, { 0, 5 } };
            int[,] arr3 = { { 1, 0, 0 }, { 0, 2, 0 }, { 0, 0, 5 } };
            int[,] arr4 = { { 2, 0, 0 }, { 0, 4, 0 }, { 0, 0, 3 } };
            SquareMatrix<int> m1 = new DiagonalMatrix<int>(arr1);
            SquareMatrix<int> m2 = new DiagonalMatrix<int>(arr2);
            SquareMatrix<int> m3 = new DiagonalMatrix<int>(arr3);
            SquareMatrix<int> m4 = new DiagonalMatrix<int>(arr4);

            SquareMatrix<int> m = m1 + m2;

            CollectionAssert.AreEqual(new[,] { { 4, 0 }, { 0, 9 } }, m.ToArray());
            m = m3 + m4;
            CollectionAssert.AreEqual(new[,] { { 3, 0, 0 }, { 0, 6, 0 }, { 0, 0, 8 } }, m.ToArray());
        }

        [Test]
        public void Matrices_Diagonal_Int32_IsDiagonal_Exception_Test()
        {
            int[,] arr1 = { { 1, 1 }, { 0, 4 } };
            int[,] arr2 = { { 1, 0, 1 }, { 0, 2, 0 }, { 0, 0, 5 } };
            Assert.Throws<Exception>(() => new DiagonalMatrix<int>(arr1));
            Assert.Throws<Exception>(() => new DiagonalMatrix<int>(arr2));
        }

        [Test]
        public void Matrices_Symmetric_Int32_Operator_Add_Test()
        {
            int[,] arr1 = { { 1, 0 }, { 0, 4 } };
            int[,] arr2 = { { 3, 0 }, { 0, 5 } };
            int[,] arr3 = { { 1, 3, -1 }, { 3, 2, 4 }, { -1, 4, 5 } };
            int[,] arr4 = { { 2, 1, 6 }, { 1, 4, 5 }, { 6, 5, 3 } };
            SquareMatrix<int> m1 = new SymmetricMatrix<int>(arr1);
            SquareMatrix<int> m2 = new SymmetricMatrix<int>(arr2);
            SquareMatrix<int> m3 = new SymmetricMatrix<int>(arr3);
            SquareMatrix<int> m4 = new SymmetricMatrix<int>(arr4);

            SquareMatrix<int> m = m1 + m2;

            CollectionAssert.AreEqual(new[,] { { 4, 0 }, { 0, 9 } }, m.ToArray());
            m = m3 + m4;
            CollectionAssert.AreEqual(new[,] { { 3, 4, 5 }, { 4, 6, 9 }, { 5, 9, 8 } }, m.ToArray());
        }

        [Test]
        public void Matrices_Symmetric_Int32_IsSymmetric_Exception_Test()
        {
            int[,] arr1 = { { 1, 1 }, { 0, 4 } };
            int[,] arr2 = { { 1, 0, 1 }, { 0, 2, 0 }, { 0, 0, 5 } };
            Assert.Throws<Exception>(() => new SymmetricMatrix<int>(arr1));
            Assert.Throws<Exception>(() => new SymmetricMatrix<int>(arr2));
        }
    }
}

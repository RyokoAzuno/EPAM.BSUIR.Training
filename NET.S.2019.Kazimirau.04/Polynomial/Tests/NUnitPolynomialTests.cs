﻿using NUnit.Framework;

namespace Polynomial.Tests
{
    [TestFixture]
    public class NUnitPolynomialTests
    {
        [Test]
        public void Polynomial_MergeDegreesAndCoefficients_Test()
        {
            var degrees1 = new [] { 0, 1, 2, 4, 5 };
            var degrees2 = new[] { 1, 4, 5, 6 };
            var coeffs1 = new[] { 0.3, 9.1, 2.4, 0.4, 5.7 };
            var coeffs2 = new[] { 2.1, -3.4, 1.5, 2.7 };
            //int size = Polynomial.CalculateArraySize(degrees1, degrees2);
            //var degreesResult = new int[size];
            //var coeffsResult = new double[size];

            //Polynomial.MergeDegreesAndCoefficients(coeffsResult, degreesResult, coeffs1, coeffs2, degrees1, degrees2);
            Polynomial p1 = new Polynomial(degrees1, coeffs1);
            Polynomial p2 = new Polynomial(degrees2, coeffs2);
            Polynomial p3 = p1 + p2;
            Assert.AreEqual(new[] { 0, 1, 2, 4, 5, 6 }, p3.GetDegrees);
            CollectionAssert.AreEqual(new[] { 0, 1, 2, 4, 5, 6 }, p3.GetDegrees);
        }

        [Test]
        public void Polynomial_OperatorPlus_Test()
        {
            var degrees1 = new[] { 0, 1, 2, 4, 5 };
            var degrees2 = new[] { 1, 4, 5, 6 };
            var coeffs1 = new[] { 0.3, 9.1, 2.4, 0.4, 5.7 };
            var coeffs2 = new[] { 2.1, -3.4, 1.5, 2.7 };

            Polynomial p1 = new Polynomial(degrees1, coeffs1);
            Polynomial p2 = new Polynomial(degrees2, coeffs2);
            Polynomial p3 = p1 + p2;

            CollectionAssert.AreEqual(new[] { 0.3, 11.2, 2.4, -3, 7.2, 2.7 }, p3.GetCoefficients);
        }

        [Test]
        public void Polynomial_OperatorMinus_Test()
        {
            var degrees1 = new[] { 0, 1, 2, 4, 5 };
            var degrees2 = new[] { 1, 4, 5, 6 };
            var coeffs1 = new[] { 0.3, 9.1, 2.4, 0.4, 5.7 };
            var coeffs2 = new[] { 2.1, -3.4, 1.5, 2.7 };

            Polynomial p1 = new Polynomial(degrees1, coeffs1);
            Polynomial p2 = new Polynomial(degrees2, coeffs2);
            Polynomial p3 = p1 - p2;

            CollectionAssert.AreEqual(new[] { 0.3, 7, 2.4, 3.8, 4.2, -2.7 }, p3.GetCoefficients);
        }

        [Test]
        public void Polynomial_OperatorEquality_Test()
        {
            var degrees1 = new[] { 0, 1, 2, 4, 5 };
            var degrees2 = new[] { 0, 1, 2, 4, 5 };
            var coeffs1 = new[] { 0.3, 9.1, 2.4, 0.4, 5.7 };
            var coeffs2 = new[] { 0.3, 9.1, 2.4, 0.4, 5.7 };

            Polynomial p1 = new Polynomial(degrees1, coeffs1);
            Polynomial p2 = new Polynomial(degrees2, coeffs2);

            Assert.AreEqual(true, p1 == p2);
            Assert.AreEqual(true, p1.Equals(p2));
        }

        [Test]
        public void Polynomial_OperatorInequality_Test()
        {
            var degrees1 = new[] { 0, 1, 2, 4, 5 };
            var degrees2 = new[] { 1, 4, 5, 6 };
            var coeffs1 = new[] { 0.3, 9.1, 2.4, 0.4, 5.7 };
            var coeffs2 = new[] { 2.1, -3.4, 1.5, 2.7 };

            Polynomial p1 = new Polynomial(degrees1, coeffs1);
            Polynomial p2 = new Polynomial(degrees2, coeffs2);

            Assert.AreEqual(true, p1 != p2);
            Assert.AreEqual(true, !p1.Equals(p2));
        }

        [Test]
        public void Polynomial_OperatorMultiply_Test()
        {
            var degrees1 = new[] { 1, 2, 5 };
            var degrees2 = new[] { 1, 4 };
            var coeffs1 = new[] { 0.3, 9.1, 0.4 };
            var coeffs2 = new[] { 2.1, -3.4 };

            Polynomial p1 = new Polynomial(degrees1, coeffs1);
            Polynomial p2 = new Polynomial(degrees2, coeffs2);
            Polynomial p3 = p1 * p2;

            CollectionAssert.AreEqual(new[] { 0.63, 19.11, -1.02, -30.1, -1.36 }, p3.GetCoefficients);
            CollectionAssert.AreEqual(new[] { 2, 3, 5, 6, 9 }, p3.GetDegrees);
        }

        [Test]
        public void Polynomial_OperatorMultiplyOnCoefficient_Test()
        {
            var degrees1 = new[] { 0, 1, 2, 4, 5 };
            var coeffs1 = new[] { -0.3, 9.1, 2.4, -0.4, 5.7 };

            Polynomial p1 = new Polynomial(degrees1, coeffs1);
            Polynomial p2 = p1 * 2.0;

            CollectionAssert.AreEqual(new[] { -0.6, 18.2, 4.8, -0.8, 11.4 }, p2.GetCoefficients);
            CollectionAssert.AreEqual(new[] { 0, 1, 2, 4, 5 }, p2.GetDegrees);
        }
    }
}

using NUnit.Framework;

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
    }
}

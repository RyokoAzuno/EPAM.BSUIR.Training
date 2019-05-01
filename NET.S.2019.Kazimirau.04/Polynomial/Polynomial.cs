using System;
using System.Collections.Generic;

namespace Polynomial
{
    public sealed class Polynomial
    {
        /// <summary>
        /// Array that stores degrees of the polynomial
        /// </summary>
        private int[] _degrees;

        /// <summary>
        /// Array that stores coefficients of the polynomial
        /// </summary>
        private double[] _coeffs;

        /// <summary>
        /// Constructor for initialization
        /// </summary>
        /// <param name="degree"> Array of degrees </param>
        /// <param name="coeffs"> Array of coefficients </param>
        public Polynomial(int[] degrees, double[] coeffs)
        {
            if (degrees == null || coeffs == null)
            {
                throw new ArgumentNullException();
            }

            if (degrees.Length != coeffs.Length)
            {
                throw new ArgumentException();
            }

            _degrees = new int[degrees.Length];
            _coeffs = new double[coeffs.Length];

            for (int i = 0; i < degrees.Length; i++)
            {
                _degrees[i] = degrees[i];
            }

            for (int i = 0; i < coeffs.Length; i++)
            {
                _coeffs[i] = coeffs[i];
            }
        }

        public int GetNumberOfDegrees
        {
            get { return _degrees.Length; }
        }

        public int GetNumberOfCoefficients
        {
            get { return _coeffs.Length; }
        }

        public int[] GetDegrees
        {
            get { return _degrees; }
        }

        public double[] GetCoefficients
        {
            get { return _coeffs; }
        }

        /// <summary>
        /// Operator plus(+) overloading
        /// </summary>
        /// <param name="p1"> Left polynomial </param>
        /// <param name="p2"> Right polynomial </param>
        /// <returns> New polynomial </returns>
        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            if (p1 == null || p2 == null)
            {
                throw new ArgumentNullException();
            }

            int degrees1 = p1.GetNumberOfDegrees;
            int degrees2 = p2.GetNumberOfDegrees;
            int[] degArr = null;
            double[] coeffArr = null;

            if (degrees1 != degrees2)
            {
                int size = CalculateArraySize(p1.GetDegrees, p2.GetDegrees);
                degArr = new int[size];
                coeffArr = new double[size];
            }
            else
            {
                degArr = new int[degrees1];
                coeffArr = new double[degrees1];
            }

            MergeDegreesAndCoefficients(coeffArr, degArr, p1.GetCoefficients, p2.GetCoefficients, p1.GetDegrees, p2.GetDegrees);

            return new Polynomial(degArr, coeffArr);
        }

        /// <summary>
        /// Operator minus(-) overloading
        /// </summary>
        /// <param name="p1"> Left polynomial </param>
        /// <param name="p2"> Right polynomial </param>
        /// <returns> New polynomial = Left - Right</returns>
        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            if (p1 == null || p2 == null)
            {
                throw new ArgumentNullException();
            }

            int length = p2.GetNumberOfCoefficients;

            for (int i = 0; i < length; i++)
            {
                p2._coeffs[i] = -p2._coeffs[i];
            }

            return p1 + p2;
        }

        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            if(p1 == null || p2 == null)
            {
                throw new ArgumentNullException();
            }

            int length1 = p1.GetNumberOfCoefficients;
            int length2 = p2.GetNumberOfCoefficients;
            List<double> coeffs = new List<double>();
            List<int> degrees = new List<int>();

            for (int i = 0; i < length1; i++)
            {
                for (int j = 0; j < length2; j++)
                {
                    coeffs.Add(Math.Round(p1._coeffs[i] * p2._coeffs[j], 5));
                    degrees.Add(p1._degrees[i] + p2._degrees[j]);
                }
            }

            for (int i = 0; i < coeffs.Count; i++)
            {
                List<int> indicesToRemove = new List<int>();
                for (int j = i + 1; j < degrees.Count; j++)
                {
                    if (degrees[i] == degrees[j])
                    {
                        coeffs[i] += coeffs[j];
                        indicesToRemove.Add(j);
                    }
                }

                for (int k = 0; k < indicesToRemove.Count; k++)
                {
                    coeffs.RemoveAt(indicesToRemove[k]);
                    degrees.RemoveAt(indicesToRemove[k]);
                }
            }

            Sort(degrees, coeffs);

            return new Polynomial(degrees.ToArray(), coeffs.ToArray());
        }

        public static Polynomial operator *(Polynomial p1, double coefficient)
        {
            if(p1 == null)
            {
                throw new NullReferenceException();
            }

            for (int i = 0; i < p1.GetNumberOfCoefficients; i++)
            {
                p1._coeffs[i] = Math.Round(p1._coeffs[i] * coefficient, 5);
            }

            return new Polynomial(p1.GetDegrees, p1.GetCoefficients);
        }

        public static bool operator ==(Polynomial p1, Polynomial p2)
        {
            ////if (((object)p1) == null || ((object)p2) == null)
            ////    return Equals(p1, p2);

            return p1.Equals(p2);
        }

        public static bool operator !=(Polynomial p1, Polynomial p2)
        {
            ////if (((object)p1) == null || ((object)p2) == null)
            ////    return !Equals(p1, p2);

            return !p1.Equals(p2);
        }

        /// <summary>
        /// Represent an object as a string
        /// </summary>
        /// <returns> String representation of the object </returns>
        public override string ToString()
        {
            string result = string.Empty;
            int length = GetNumberOfDegrees;

            for (int i = 0; i < length; i++)
            {
                result += (i == (length - 1)) ? $"{_coeffs[i]}X^{_degrees[i]}" : $"{_coeffs[i]}X^{_degrees[i]}, ";
            }

            return result;
        }

        /// <summary>
        /// GetHashCode overriding
        /// Microsoft already provides a good generic and ValueTuple HashCode generator
        /// Good article: https://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode
        /// </summary>
        public override int GetHashCode()
        {
            return (_degrees.Length, _coeffs.Length).GetHashCode(); 
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (!(obj is Polynomial p))
            {
                return false;
            }
            else
            {
                int length = p.GetNumberOfDegrees;

                for (int i = 0; i < length; i++)
                {
                    if ((_degrees[i] != p._degrees[i]) || (_coeffs[i] != p._coeffs[i]))
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        /// <summary>
        /// Sorts degrees and coefficients in ascending order
        /// </summary>
        /// <param name="degrees"> List of degrees </param>
        /// <param name="coeffs"> List of coefficients</param>
        private static void Sort(List<int> degrees, List<double> coeffs)
        {
            for (int i = 0; i < degrees.Count; i++)
            {
                for (int j = i + 1; j < degrees.Count; j++)
                {
                    if (degrees[i] > degrees[j])
                    {
                        degrees[i] ^= degrees[j];
                        degrees[j] ^= degrees[i];
                        degrees[i] ^= degrees[j];

                        double tmp = coeffs[i];
                        coeffs[i] = coeffs[j];
                        coeffs[j] = tmp;
                    }
                }
            }
        }

        /// <summary>
        /// Merge degrees and coefficients of the polynomial into new resulting arrays
        /// </summary>
        /// <param name="resultCoeffs"> Resulting array of coefficients </param>
        /// <param name="resultDegs"> Resulting array of degrees </param>
        /// <param name="leftCoeffs"> Left polynomial array of coefficients </param>
        /// <param name="rightCoeffs"> Right polynomial array of coefficients </param>
        /// <param name="leftDegs"> Left polynomial array of degrees </param>
        /// <param name="rightDegs"> Right polynomial array of degrees </param>
        private static void MergeDegreesAndCoefficients(double[] resultCoeffs, int[] resultDegs, double[] leftCoeffs, double[] rightCoeffs, int[] leftDegs, int[] rightDegs)
        {
            int i = 0;
            int j = 0;

            for (int k = 0; k < resultDegs.Length; k++)
            {
                if (i >= leftDegs.Length && j < rightDegs.Length)
                {
                    resultDegs[k] = rightDegs[j];
                    resultCoeffs[k] = rightCoeffs[j++];
                }
                else if (j >= rightDegs.Length && i < leftDegs.Length)
                {
                    resultDegs[k] = leftDegs[i];
                    resultCoeffs[k] = leftCoeffs[i++];
                }
                else if (leftDegs[i] < rightDegs[j])
                {
                    resultDegs[k] = leftDegs[i];
                    resultCoeffs[k] = leftCoeffs[i++];
                }
                else if (leftDegs[i] > rightDegs[j])
                {
                    resultDegs[k] = rightDegs[j];
                    resultCoeffs[k] = rightCoeffs[j++];
                }
                else if (leftDegs[i] == rightDegs[j])
                {
                    resultDegs[k] = rightDegs[j];
                    resultCoeffs[k] = leftCoeffs[i] + rightCoeffs[j];
                    i++;
                    j++;
                }
            }
        }

        /// <summary>
        /// Calculate the size of the new array arr1NotSimilar + arr2NotSimilar + bothSimilar
        /// </summary>
        /// <param name="degrees1"> First array </param>
        /// <param name="degrees2"> Second array </param>
        /// <returns></returns>
        private static int CalculateArraySize(int[] degrees1, int[] degrees2)
        {
            int countSimilar = 0;
            int countNotSimilar = 0;

            for (int i = 0; i < degrees1.Length; i++)
            {
                bool flag = false;
                for (int j = 0; j < degrees2.Length; j++)
                {
                    if (degrees1[i] == degrees2[j])
                    {
                        countSimilar++;
                        flag = true;
                        break;
                    }
                }

                if (flag == false)
                {
                    countNotSimilar++;
                }
            }

            for (int i = 0; i < degrees2.Length; i++)
            {
                bool flag = false;
                for (int j = 0; j < degrees1.Length; j++)
                {
                    if (degrees2[i] == degrees1[j])
                    {
                        flag = true;
                        break;
                    }
                }

                if (flag == false)
                {
                    countNotSimilar++;
                }
            }

            return countSimilar + countNotSimilar;
        }
    }
}

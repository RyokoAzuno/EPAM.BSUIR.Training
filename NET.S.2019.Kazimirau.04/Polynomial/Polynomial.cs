﻿using System;

namespace Polynomial
{
    public sealed class Polynomial
    {
        /// <summary>
        /// Array that stores degrees of the polynom
        /// </summary>
        private int[] _degrees;
        /// <summary>
        /// Array that stores coefficients of the polynom
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
                throw new ArgumentNullException();

            if (degrees.Length != coeffs.Length)
                throw new ArgumentException();

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
        /// Operator + overloading
        /// </summary>
        /// <param name="p1"> Left polynom </param>
        /// <param name="p2"> Right polynom </param>
        /// <returns> New polynom = Left + Right</returns>
        public static Polynomial operator+(Polynomial p1, Polynomial p2)
        {
            int p1Degrees = p1.GetNumberOfDegrees;
            int p2Degrees = p2.GetNumberOfDegrees;
            int[] degArr = null;
            double[] coeffArr = null;

            if (p1Degrees != p2Degrees)
            {
                int size = CalculateArraySize(p1._degrees, p2._degrees);
                degArr = new int[size];
                coeffArr = new double[size];
            }
            else
            {
                degArr = new int[p1Degrees];
                coeffArr = new double[p1Degrees];
            }

            MergeDegreesAndCoefficients(coeffArr, degArr, p1._coeffs, p2._coeffs, p1._degrees, p2._degrees); ;

            return new Polynomial(degArr, coeffArr);
        }

        public override string ToString()
        {
            return $"Test polynom";
        }

        /// <summary>
        /// Merge degrees and coefficients of the polynom into new resulting arrays
        /// </summary>
        /// <param name="resultCoeffs"> Resulting array of coefficients </param>
        /// <param name="resultDegs"> Resulting array of degrees </param>
        /// <param name="leftCoeffs"> Left polynom's array of coefficients </param>
        /// <param name="rightCoeffs"> Right polynom's array of coefficients </param>
        /// <param name="leftDegs"> Left polynom's array of degrees </param>
        /// <param name="rightDegs"> Right polynom's array of degrees </param>
        private static void MergeDegreesAndCoefficients(double[] resultCoeffs, int[] resultDegs, double[] leftCoeffs, double[] rightCoeffs, int[] leftDegs, int[] rightDegs)
        {
            int i = 0;
            int j = 0;

            for (int k = 0; k < resultDegs.Length; k++)
            {
                if(i >= leftDegs.Length && j < rightDegs.Length)
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
        /// Calculate a size of the array arr1NotSimilar + arr2NotSimilar + bothSimilar
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
                    countNotSimilar++;
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
                    countNotSimilar++;
            }

            return countSimilar + countNotSimilar;
        }
    }
}
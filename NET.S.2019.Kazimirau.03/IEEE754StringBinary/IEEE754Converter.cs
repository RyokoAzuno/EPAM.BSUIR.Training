using System;
using System.Collections;
using System.Text;

namespace IEEE754StringBinary
{
    public class IEEE754Converter
    {
        public static string Convert(double number)
        {
            //string result = string.Empty;
            //char sign = number >= 0 ? '0' : '1';
            //string exp = GetExponenta(number);
            //string whole = GetWholePart(number);
            //string frac = GetFractionalPart(number);
            //result = $"{sign}{exp}{whole.Substring(1)}{frac}";
            //int length = result.Length;
            //if (length < 64)
            //    result = result.PadRight(64, '0');
            //return result;

            byte[] numberBytes = BitConverter.GetBytes(number);
            BitArray bitArray = new BitArray(numberBytes);
            StringBuilder sb = new StringBuilder();

            for (int i = bitArray.Length - 1; i >= 0; i--)
            {
                if (bitArray[i])
                    sb.Append('1');
                else
                    sb.Append('0');
            }

            return sb.ToString();
        }

        public static string GetWholePart(double number)
        {
            StringBuilder sb = new StringBuilder();
            long whole = (long)number;

            while(whole != 0)
            {
                long reminder = whole % 2;
                whole /= 2;
                sb.Append(reminder);
            }
            sb = Reverse(sb);

            return sb.ToString();
        }

        public static string GetFractionalPart(double number)
        {
            double fractional = number % 1;
            StringBuilder sb = new StringBuilder();

            while(fractional != 0)
            {
                double tmp = fractional * 2;

                if(tmp >= 1)
                {
                    sb.Append(1);
                    fractional = tmp % 1;
                }
                else
                {
                    sb.Append(0);
                    fractional = tmp;
                }
            }

            return sb.ToString();
        }

        public static string GetExponenta(double number)
        {
            int power = 0;
            double tmp = number;
            if (number < 1)
            {
                while (tmp < 2)
                {
                    tmp = number / Math.Pow(2, --power);
                }
            }
            else
            {
                while (tmp > 2)
                {
                    tmp = number / Math.Pow(2, ++power);
                }
            }
            return GetWholePart(power + 1023); // 127 for single
        }

        private static StringBuilder Reverse(StringBuilder sb)
        {
            StringBuilder result = new StringBuilder();
            for (int i = sb.Length - 1; i >= 0; i--)
            {
                result.Append(sb[i]);
            }
            return result;
        }
    }
}

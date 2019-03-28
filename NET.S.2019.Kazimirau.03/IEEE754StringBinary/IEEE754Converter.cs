using System;
using System.Collections;
using System.Text;

namespace IEEE754StringBinary
{
    public class IEEE754Converter
    {
        public static string Convert(double number)
        {
            string result = string.Empty;

            if (double.IsNegativeInfinity(number))
            {
                return "1111111111110000000000000000000000000000000000000000000000000000";
            }
            else if(double.IsPositiveInfinity(number))
            {
                return "0111111111110000000000000000000000000000000000000000000000000000";
            }
            else if(double.IsNaN(number))
            {
                return "1111111111111000000000000000000000000000000000000000000000000000";
            }
            
            char sign = number >= 0 ? '0' : '1';            
            string exponent = GetExponenta(number);
            string mantissa = GetMantissa(number);
            result = $"{sign}{exponent}{mantissa}";
            int length = result.Length;

            if (length < 64)
                result = result.PadRight(64, '0');
            return result;
        }

        public static string BuiltInConvert(double number)
        {
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
        private static string GetMantissa(double number)
        {
            string wholePart = GetWholePart(number);
            string fractPart = GetFractionalPart(number);

            string result = string.IsNullOrEmpty(wholePart) == true ? fractPart : wholePart.Substring(1) + fractPart;
            return result.Length == 52 ? result : result.Length < 52 ? result.PadRight(52, '0') : result.Substring(result.Length - 52);
        }

        private static string GetWholePart(double number, int numBits = 52)
        {
            StringBuilder sb = new StringBuilder(numBits);

            long whole = (long)Math.Abs(number);
            long reminder = 0;

            while(whole != 0)
            {
                reminder = whole % 2;
                whole /= 2;
                sb.Append(reminder);
            }
            sb = Reverse(sb);

            return sb.ToString();
        }

        private static string GetFractionalPart(double number)
        {
            double fractional = Math.Abs(number) % 1;                       
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

        private static string GetExponenta(double number)
        {
            string result = string.Empty;
            int power = 0;
            number = Math.Abs(number);
            double tmp = number;

            if (number < 1)
            {
                while (tmp < 2)
                {
                    tmp = number / Math.Pow(2, --power);
                }
                ++power;
            }
            else
            {
                while (tmp > 2)
                {
                    tmp = number / Math.Pow(2, ++power);
                }
            }
            //int power = wholePart.Length - 1;
            result = GetWholePart(power + 1023); // 127 for single
            return result.Length == 11 ? result : result.PadLeft(11, '0'); 
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

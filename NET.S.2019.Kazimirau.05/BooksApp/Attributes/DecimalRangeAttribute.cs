using System;
using System.ComponentModel.DataAnnotations;

namespace BooksApp.Attributes
{
    //[AttributeUsage(AttributeTargets.Property)]
    public class DecimalRangeAttribute : ValidationAttribute
    {
        public decimal Min { get; set; }
        public decimal Max { get; set; }

        public DecimalRangeAttribute(object min, object max)
        {
            Min = Convert.ToDecimal(min);
            Max = Convert.ToDecimal(max);
        }

        public override bool IsValid(object value)
        {
            if(value != null)
            {
                decimal val = Convert.ToDecimal(value);

                if(val < Min || val > Max)
                {
                    this.ErrorMessage = $"Should be in the range from {Min} to {Max}";
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
    }
}

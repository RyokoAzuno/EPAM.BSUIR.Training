using System;
using System.ComponentModel.DataAnnotations;

namespace BooksApp.Attributes
{
    ////[AttributeUsage(AttributeTargets.Property)]
    public class DecimalRangeAttribute : ValidationAttribute
    {
        public DecimalRangeAttribute(object min, object max)
        {
            this.Min = Convert.ToDecimal(min);
            this.Max = Convert.ToDecimal(max);
        }

        public decimal Min { get; set; }

        public decimal Max { get; set; }

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                decimal val = Convert.ToDecimal(value);

                if (val < this.Min || val > this.Max)
                {
                    this.ErrorMessage = $"Should be in the range from {this.Min} to {this.Max}";
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

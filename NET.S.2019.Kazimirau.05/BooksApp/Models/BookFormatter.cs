using System;
using System.Globalization;

namespace BooksApp.Models
{
    // Class allows to add custom formats to Book
    public class BookFormatter : ICustomFormatter, IFormatProvider
    {
        // Add new custom formats
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg is Book book)
            {
                if(!string.IsNullOrEmpty(format))
                {
                    switch(format.ToUpper())
                    {
                        case "SAT":
                            {
                                return string.Format($"{book.Author}, {book.Name}");
                            }
                        case "SATPY":
                            {
                                return string.Format($"{book.Author}, {book.Name}, {book.Publisher}, {book.Year}");
                            }
                        case "SIATPYN":
                            {
                                return string.Format($"ISBN {book.ISBN}, {book.Author}, {book.Name}, {book.Publisher}, {book.Year}, P. {book.NumberOfPages}");
                            }
                        default:
                            {
                                return HandleOtherFormats(format, arg);
                            }
                    }
                }
            }

            throw new FormatException($"The format of '{format}' is invalid.");
        }

        // Returns an object that provides formatting services for the specified type.
        public object GetFormat(Type formatType) => formatType == typeof(ICustomFormatter) ? this : null;

        // Method handles other available formats
        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
            {
                return ((IFormattable)arg).ToString(format, CultureInfo.GetCultureInfo("en-us"));
            }
            else if (arg != null)
            {
                return arg.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}

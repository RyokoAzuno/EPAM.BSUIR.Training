using BooksApp.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace BooksApp.Models
{
    // Class that define Book abstraction 
    public class Book : IEntity, IEquatable<Book>, IComparable<Book>, IFormattable
    {
        public int Id { get; set; }
        [RegularExpression(@"^\d{1}-\d{2}-\d{6}-\d{1}$", ErrorMessage = "Must be: x-xx-xxxxxx-x")]
        public string ISBN { get; set; }
        [StringLength(maximumLength: 30, MinimumLength = 5, ErrorMessage = "Author name should be between 5 to 30 characters")]
        public string Author { get; set; }
        [StringLength(maximumLength: 40, MinimumLength = 5, ErrorMessage = "Book name should be between 5 to 40 characters")]
        public string Name { get; set; }
        [StringLength(maximumLength: 40, MinimumLength = 5, ErrorMessage = "Publisher name should be between 5 to 40 characters")]
        public string Publisher { get; set; }
        [Range(1900, 2050, ErrorMessage = "Should be in the range from 1900 to 2050")]
        public int Year { get; set; }
        [Range(20, 2000, ErrorMessage = "Should be in the range from 20 to 2000 ")]
        public int NumberOfPages { get; set; }
        public decimal Price { get; set; }

        // Implementation of IComparable<Book> interface
        public int CompareTo(Book book)
        {
            if (this.Year.Equals(book.Year))
                return this.Name.CompareTo(book.Name);

            return this.Year.CompareTo(book.Year);
        }
        // Implementation of IEquatable<Book> interface
        public bool Equals(Book book)
        {
            if (ReferenceEquals(book, null))
                return false;
            if (ReferenceEquals(this, null))
                return false;
            if (this.GetType() != book.GetType())
                return false;

            if (!this.ISBN.Equals(book.ISBN))
                return false;

            if (!this.Author.Equals(book.Author))
                return false;

            if (!this.Name.Equals(book.Name))
                return false;

            if (!this.Publisher.Equals(book.Publisher))
                return false;

            if (!this.Year.Equals(book.Year))
                return false;

            if (!this.NumberOfPages.Equals(book.NumberOfPages))
                return false;

            if (!this.Price.Equals(book.Price))
                return false;

            return true;
        }

        // Overriding Equals method from the base class Object
        public override bool Equals(object obj)
        {
            return Equals(obj as Book);
        }

        // Overriding GetHashCode method from the base class Object
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + this.Id.GetHashCode();
                hash = hash * 23 + this.ISBN.GetHashCode();
                hash = hash * 23 + this.Author.GetHashCode();
                hash = hash * 23 + this.Name.GetHashCode();
                hash = hash * 23 + this.Publisher.GetHashCode();
                hash = hash * 23 + this.Year.GetHashCode();
                hash = hash * 23 + this.NumberOfPages.GetHashCode();
                hash = hash * 23 + this.Price.GetHashCode();

                return hash;
            }
        }

        // Overriding ToString() from Object class
        public override string ToString()
        {
            return this.ToString("G", CultureInfo.GetCultureInfo("en-us"));
        }

        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.GetCultureInfo("en-us"));
        }

        // Implementing ToString method from IFormattable interface
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format)) format = "G";

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.GetCultureInfo("en-us");
            }

            switch (format.ToUpperInvariant())
            {
                case "G":
                    return BuildFormatString(format, formatProvider);
                case "AT":
                    return BuildFormatString(format, formatProvider);
                case "ATPY":
                    return BuildFormatString(format, formatProvider);
                default:
                    throw new FormatException(string.Format($"The {format} format string is not supported."));
            }
        }

        // Build a string which depends on the current format and current format provider
        private string BuildFormatString(string format, IFormatProvider formatProvider)
        {
            StringBuilder sb = new StringBuilder();
            switch (format)
            {
                case "AT":
                    {
                        sb.AppendFormat($"Author:  {Author}\n");
                        sb.AppendFormat($"Name: {Name}\n");
                        break;
                    }
                case "ATPY":
                    {
                        sb.AppendFormat($"Author:  {Author}\n");
                        sb.AppendFormat($"Name: {Name}\n");
                        sb.AppendFormat($"Publisher:  {Publisher}\n");
                        sb.AppendFormat($"Year:  {Year}\n");
                        break;
                    }
                default:
                    {
                        sb.AppendFormat($"Id: {Id}\n");
                        sb.AppendFormat($"ISBN: {ISBN}\n");
                        sb.AppendFormat($"Author:  {Author}\n");
                        sb.AppendFormat($"Name: {Name}\n");
                        sb.AppendFormat($"Publisher:  {Publisher}\n");
                        sb.AppendFormat($"Year:  {Year}\n");
                        sb.AppendFormat($"Pages:  {NumberOfPages}\n");
                        sb.AppendFormat($"Price:  {Price.ToString("C", formatProvider)}\n");
                        sb.Append("*************\n");
                        break;
                    }
            }

            return sb.ToString();
        }
    }
}
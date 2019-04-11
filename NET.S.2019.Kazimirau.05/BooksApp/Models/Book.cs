using BooksApp.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace BooksApp
{
    public class Book : IEntity, IEquatable<Book>, IComparable<Book>
    {
        public int Id { get; set; }
        [RegularExpression(@"^\d{1}-\d{2}-\d{6}-\d{1}$", ErrorMessage = "Must be: x-xx-xxxxxx-x")]
        public string ISBN { get; set; }
        [StringLength(maximumLength: 30, MinimumLength = 5, ErrorMessage = "Author name should be between 5 to 30 characters")]
        public string Author { get; set; }
        [StringLength(maximumLength: 20, MinimumLength = 5, ErrorMessage = "Book name should be between 5 to 20 characters")]
        public string Name { get; set; }
        [StringLength(maximumLength: 40, MinimumLength = 5, ErrorMessage = "Publisher name should be between 5 to 40 characters")]
        public string Publisher { get; set; }
        [Range(1900, 2050, ErrorMessage = "Should be in a range from 1900 to 2050")]
        public int Year { get; set; }
        [Range(20, 2000, ErrorMessage = "Should be in a range from 20 to 2000 ")]
        public int NumberOfPages { get; set; }
        public decimal Price{ get; set; }

        // Implementation of IComparable<Book> interface
        public int CompareTo(Book book)
        {
            if (Year.Equals(book.Year))
                return Name.CompareTo(book.Name);

            return Year.CompareTo(book.Year);
        }
        // Implementation of IEquatable<Book> interface
        public bool Equals(Book book)
        {
            if (ReferenceEquals(book, null))
                return false;
            if (ReferenceEquals(this, null))
                return false;
            if (GetType() != book.GetType())
                return false;

            if (!ISBN.Equals(book.ISBN))
                return false;

            if (!Author.Equals(book.Author))
                return false;

            if (!Name.Equals(book.Name))
                return false;

            if (!Publisher.Equals(book.Publisher))
                return false;

            if (!Year.Equals(book.Year))
                return false;

            if (!NumberOfPages.Equals(book.NumberOfPages))
                return false;

            if (!Price.Equals(book.Price))
                return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Book);
        }

        public override string ToString()
        {
            return $"ISBN: {ISBN}\nAuthor:  {Author}\nName: {Name}\nPublisher:  {Publisher}\nYear:  {Year}\nPages:  {NumberOfPages}\nPrice:  {Price}\n*************\n";
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Id.GetHashCode();
                hash = hash * 23 + ISBN.GetHashCode();
                hash = hash * 23 + Author.GetHashCode();
                hash = hash * 23 + Name.GetHashCode();
                hash = hash * 23 + Publisher.GetHashCode();
                hash = hash * 23 + Year.GetHashCode();
                hash = hash * 23 + NumberOfPages.GetHashCode();
                hash = hash * 23 + Price.GetHashCode();

                return hash;
            }
        }
    }
}
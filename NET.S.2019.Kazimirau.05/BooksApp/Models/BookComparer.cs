using System.Collections.Generic;

namespace BooksApp.Models
{
    public enum SortBy
    {
        ISBN,
        Author,
        Name,
        Publisher,
        Year,
        Pages,
        Price
    }

    public class BookComparer : IComparer<Book>
    {
        private SortBy _comparer = SortBy.Year;

        public SortBy Comparer
        {
            get
            {
                return _comparer;
            }

            set
            {
                _comparer = value;
            }
        }

        public int Compare(Book b1, Book b2)
        {
            switch (Comparer)
            {
                case SortBy.ISBN:
                    return b1.ISBN.CompareTo(b2.ISBN);

                case SortBy.Author:
                    return b1.Author.CompareTo(b2.Author);

                case SortBy.Name:
                    return b1.Name.CompareTo(b2.Name);

                case SortBy.Publisher:
                    return b1.Publisher.CompareTo(b2.Publisher);

                case SortBy.Pages:
                    return b1.NumberOfPages.CompareTo(b2.NumberOfPages);

                case SortBy.Price:
                    return b1.Price.CompareTo(b2.Price);

                default:
                    break;
            }

            return b1.Year.CompareTo(b2.Year);
        }
    }
}
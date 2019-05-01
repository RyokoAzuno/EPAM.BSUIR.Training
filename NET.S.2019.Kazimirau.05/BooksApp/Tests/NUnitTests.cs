using BooksApp.Models;
using NUnit.Framework;
using System.Text;

namespace BooksApp.Tests
{
    [TestFixture]
    public class NUnitTests
    {
        [Test]
        public void Book_Format_Test()
        {
            Book book = new Book
            {
                Id = 0,
                ISBN = "1-61-729453-5",
                Author = "Jon Skeet",
                Name = "C# in Depth",
                NumberOfPages = 528,
                Price = 43m,
                Publisher = "Manning Publications",
                Year = 2019
            };
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"Author:  {book.Author}\n");
            sb.AppendFormat($"Name: {book.Name}\n");
            sb.AppendFormat($"Publisher:  {book.Publisher}\n");
            sb.AppendFormat($"Year:  {book.Year}\n");

            Assert.AreEqual($"{book.Author}, {book.Name}", string.Format(new BookFormatter(), "{0:SAT}", book));
            Assert.AreEqual($"{book.Author}, {book.Name}, {book.Publisher}, {book.Year}", string.Format(new BookFormatter(), "{0:SATPY}", book));
            Assert.AreEqual($"ISBN {book.ISBN}, {book.Author}, {book.Name}, {book.Publisher}, {book.Year}, P. {book.NumberOfPages}", string.Format(new BookFormatter(), "{0:SIATPYN}", book));
            Assert.AreEqual(book.ToString(), book.ToString("G"));
            Assert.AreEqual(sb.ToString(), book.ToString("ATPY"));
        }

        [Test]
        public void Book_Equals_Test()
        {
            Book b1 = new Book
            {
                Id = 0,
                ISBN = "1-61-729453-5",
                Author = "Jon Skeet",
                Name = "C# in Depth",
                NumberOfPages = 528,
                Price = 43m,
                Publisher = "Manning Publications",
                Year = 2019
            };

            Book b2 = new Book
            {
                Id = 0,
                ISBN = "1-61-729453-5",
                Author = "Jon Skeet",
                Name = "C# in Depth",
                NumberOfPages = 528,
                Price = 43m,
                Publisher = "Manning Publications",
                Year = 2019
            };

            Assert.AreEqual(true, b1.Equals(b2));
        }
    }
}

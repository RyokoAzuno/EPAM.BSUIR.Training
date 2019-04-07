using System;
using System.Collections.Generic;
using System.Linq;

namespace BooksApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IBookRepository service = new BookService();
            byte[] booksToBytes = service.StoreBooksInMemory();
            List<Book> books = service.RestoreBooksFromMemory().ToList();
            bool areEqual = true;

            for (int i = 0; i < books.Count; i++)
            {
                if(!books[i].Equals(service[i]))
                {
                    areEqual = false;
                    break;
                }
            }
            Console.WriteLine($"Are equal(serialized) := {areEqual}");
            Console.WriteLine("*********Book Comparer************");
            BookComparer comparer = new BookComparer { Comparer = SortBy.ISBN };
            BooksStorage.Books.Sort(comparer);
            Console.WriteLine(BooksStorage.ToString());
            Console.WriteLine("Add new book");

            Console.ReadLine();
        }
    }
}

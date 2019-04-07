using System;
using System.Collections.Generic;

namespace BooksApp
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] booksToBytes = BooksStorage.Serialize();
            List<Book> books = BooksStorage.Deserialize(booksToBytes);
            bool areEqual = true;

            for (int i = 0; i < books.Count; i++)
            {
                if(!books[i].Equals(BooksStorage.Books[i]))
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

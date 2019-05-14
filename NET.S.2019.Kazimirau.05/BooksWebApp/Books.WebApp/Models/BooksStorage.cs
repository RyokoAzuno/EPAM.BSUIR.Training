using System.Collections.Generic;

namespace Books.WebApp.Models
{
    public static class BooksStorage
    {
        public static List<Book> Books = RestoreInitialState();

        public static void SortByTag(IComparer<Book> comparer)
        {
            Books.Sort(comparer);
        }

        public static List<Book> RestoreInitialState()
        {
            Books = new List<Book> {
                new Book{ ISBN = "1-61-729453-5", Author = "Jon Skeet", Name = "C# in Depth", NumberOfPages = 528, Price = 43m, Publisher = "Manning Publications", Year = 2019 },
                new Book{ ISBN = "9-78-149198-6", Author = "Joseph Albahari", Name = "C# 7.0 in a Nutshell", NumberOfPages = 1088, Price = 65m, Publisher = "O'Reilly Media", Year = 2017 },
                new Book{ ISBN = "1-48-423017-5", Author = "Andrew Troelsen, Phil Japikse", Name = "Pro C# 7: With .NET and .NET Core", NumberOfPages = 1372, Price = 32.82m, Publisher = "Apress", Year = 2017 },
                new Book{ ISBN = "0-73-566745-4", Author = "Jeffrey Richter", Name = "CLR via C#", NumberOfPages = 896, Price = 49.17m, Publisher = "Microsoft Press", Year = 2012 },
                new Book{ ISBN = "9-78-026203-8", Author = "Thomas Cormen, Ronals Rivest", Name = "Introduction to Algorithms", NumberOfPages = 1320, Price = 87.67m, Publisher = "The MIT Press", Year = 2009 },
            };

            return Books;
        }
    }
}
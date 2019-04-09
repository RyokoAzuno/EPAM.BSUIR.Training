using System;
using System.Collections.Generic;
using System.Linq;

namespace BooksApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //IBookRepository service = new BookService();
            //byte[] booksToBytes = service.StoreBooksInMemory();
            //List<Book> books = service.RestoreBooksFromMemory().ToList();
            //bool areEqual = true;

            //for (int i = 0; i < books.Count; i++)
            //{
            //    if(!books[i].Equals(service[i]))
            //    {
            //        areEqual = false;
            //        break;
            //    }
            //}
            //Console.WriteLine($"Are equal(serialized) := {areEqual}");
            //Console.WriteLine("*********Book Comparer************");
            //BookComparer comparer = new BookComparer { Comparer = SortBy.ISBN };
            //service.SortByTag(comparer);
            //Console.WriteLine(service.ToString());
            //Console.WriteLine("Add new book");
            bool isRunning = true;
            IBookRepository bookService = new BookService();

            while (isRunning)
            {
                Console.WriteLine("!!!BooksApp!!!");
                Console.WriteLine("1- Get all books");
                Console.WriteLine("2- Get book by ISBN");
                Console.WriteLine("3- Add book");
                Console.WriteLine("4- Remove book");
                Console.WriteLine("5- Edit book");
                Console.WriteLine("6- Sort books");
                Console.WriteLine("7- Find book by tag");
                Console.WriteLine("0- Exit");
                Console.WriteLine("Select operation:");
                bool res = int.TryParse(Console.ReadLine(), out int operation);

                if (res)
                {
                    switch (operation)
                    {
                        case 0: isRunning = false; break;
                        case 1: bookService.GetAll().ToList().ForEach(b => Console.WriteLine(b.ToString())); break;
                        case 2:
                            {
                                Console.WriteLine("Enter ISBN(exmp:9-78-149198-6):");
                                try
                                {
                                    string isbn = Console.ReadLine();
                                    Console.WriteLine(bookService.GetById(isbn));
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine();
                                Console.WriteLine("Enter ISBN:");
                                string isbn = Console.ReadLine();
                                Console.WriteLine("Enter Author:");
                                string author = Console.ReadLine();
                                Console.WriteLine("Enter Name:");
                                string name = Console.ReadLine();
                                Console.WriteLine("Enter Publisher:");
                                string publisher = Console.ReadLine();
                                Console.WriteLine("Enter Year:");
                                int year = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter Pages:");
                                int pages = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter Price:");
                                decimal price = decimal.Parse(Console.ReadLine());
                                bookService.Create(new Book
                                {
                                    ISBN = isbn,
                                    Author = author,
                                    Name = name,
                                    Publisher = publisher,
                                    Year = year,
                                    NumberOfPages = pages,
                                    Price = price
                                });
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine("Enter ISBN to remove book:");
                                try
                                {
                                    string isbn = Console.ReadLine();
                                    bookService.Delete(isbn);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            }
                        case 5: break;
                        case 6: break;
                        case 7: break;
                        default: break;
                    }
                }

                Console.WriteLine("Press Enter to continue!!!");
                Console.ReadLine();
                Console.Clear();
            }
            Console.ReadLine();
        }
    }
}

using BooksApp.Interfaces;
using BooksApp.Services;
using System;
using System.Linq;

namespace BooksApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            IRepository<Book> repository = new BookRepository();
            BookService bookService = new BookService(repository);

            while (isRunning)
            {
                Console.WriteLine("!!!BooksApp!!!");
                Console.WriteLine("1- Get all books");
                Console.WriteLine("2- Get book by ID");
                Console.WriteLine("3- Add book");
                Console.WriteLine("4- Remove book");
                Console.WriteLine("5- Edit book");
                Console.WriteLine("6- Sort books");
                Console.WriteLine("7- Find book by tag");
                Console.WriteLine("8- To XML file");
                Console.WriteLine("9- To JSON file");
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
                                Console.WriteLine("Enter ID:");
                                try
                                {
                                    int id = int.Parse(Console.ReadLine());
                                    Console.WriteLine(bookService.Get(id));
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
                                Console.WriteLine("Enter ID to remove book:");
                                try
                                {
                                    int id = int.Parse(Console.ReadLine());
                                    bookService.Delete(id);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            }
                        case 5:
                            {
                                Console.WriteLine("Enter book's tag(name of the author, isbn, book name etc) which you want to edit:");
                                try
                                {
                                    string bookTag = Console.ReadLine();
                                    Book book = bookService.FindBookByTag(bookTag);
                                    if (book != null)
                                    {
                                        Console.WriteLine("What field do you want to change?(field name):");
                                        string fieldName = Console.ReadLine();
                                        switch (fieldName)
                                        {
                                            case "ISBN":
                                                {
                                                    Console.WriteLine("Enter new ISBN:");
                                                    string isbn = Console.ReadLine();
                                                    book.ISBN = isbn;
                                                    break;
                                                }
                                            case "Author":
                                                {
                                                    Console.WriteLine("Enter new Author:");
                                                    string author = Console.ReadLine();
                                                    book.Author = author;
                                                    break;
                                                }
                                            case "Name":
                                                {
                                                    Console.WriteLine("Enter new book Name:");
                                                    string name = Console.ReadLine();
                                                    book.Name = name;
                                                    break;
                                                }
                                            case "Publisher":
                                                {
                                                    Console.WriteLine("Enter new Publisher:");
                                                    string publisher = Console.ReadLine();
                                                    book.Publisher = publisher;
                                                    break;
                                                }
                                            default: break;
                                        }
                                        bookService.Update(book);
                                    }
                                    break;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            }
                        case 6:
                            {
                                Console.WriteLine("Sort by:\n1 - ISBN\n2 - Author\n3 - Name\n4 - Publisher\n5 - Year\n6 - Pages\n7 - Price\n:");
                                bool isSucceeded = int.TryParse(Console.ReadLine(), out int num);
                                if (isSucceeded)
                                {
                                    BookComparer cmp = null;
                                    switch (num)
                                    {
                                        case 1:
                                            {
                                                cmp = new BookComparer { Comparer = SortBy.ISBN };
                                                break;
                                            }
                                        case 2:
                                            {
                                                cmp = new BookComparer { Comparer = SortBy.Author };
                                                break;
                                            }
                                        case 3:
                                            {
                                                cmp = new BookComparer { Comparer = SortBy.Name };
                                                break;
                                            }
                                        case 4:
                                            {
                                                cmp = new BookComparer { Comparer = SortBy.Publisher };
                                                break;
                                            }
                                        case 5:
                                            {
                                                cmp = new BookComparer { Comparer = SortBy.Year };
                                                break;
                                            }
                                        case 6:
                                            {
                                                cmp = new BookComparer { Comparer = SortBy.Pages };
                                                break;
                                            }
                                        case 7:
                                            {
                                                cmp = new BookComparer { Comparer = SortBy.Price };
                                                break;
                                            }
                                        default:
                                            {
                                                cmp = new BookComparer();
                                                break;
                                            }
                                    }
                                    bookService.SortByTag(cmp);
                                }
                                break;
                            }
                        case 7:
                            {
                                Console.WriteLine("Enter tag name:");
                                string tag = Console.ReadLine();
                                Console.WriteLine(bookService.FindBookByTag(tag));
                                break;
                            }
                        case 8:
                            {
                                bookService.ToXML();
                                break;
                            }
                        case 9:
                            {
                                bookService.ToJSON();
                                break;
                            }
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

using System;

namespace Books.WebApp.Models
{
    public class Book
    {
        //[RegularExpression(@"^\d{1}-d{2}-d{6}-d{1}$", ErrorMessage = "Must be: x-xx-xxxxxx-x")]
        public string ISBN { get; set; }
        //[StringLength(maximumLength: 30, MinimumLength = 5, ErrorMessage = "Author name should be between 5 to 30 characters")]
        public string Author { get; set; }
        //[StringLength(maximumLength: 20, MinimumLength = 5, ErrorMessage = "Book name should be between 5 to 20 characters")]
        public string Name { get; set; }
        //[StringLength(maximumLength: 40, MinimumLength = 5, ErrorMessage = "Publisher name should be between 5 to 40 characters")]
        public string Publisher { get; set; }
        //[Range(1900, 2050, ErrorMessage = "Should be in a range from 1900 to 2050")]
        public int Year { get; set; }
        //[Range(20, 2000, ErrorMessage = "Should be in a range from 20 to 2000 ")]
        public int NumberOfPages { get; set; }
        public decimal Price{ get; set; }
    }
}
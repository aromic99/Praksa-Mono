using Models.Common;
using System;


namespace MyBooks.Model
{
    public class Book : IBooks
    {
        public Guid BookId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public Guid AuthorID { get; set; }

        public Book() { }
    }

}
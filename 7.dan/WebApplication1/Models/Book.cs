using Models.Common;


namespace MyBooks.Model
{
    public class Book : IBooks
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int AuthorID { get; set; }

        public Book() { }
    }

}
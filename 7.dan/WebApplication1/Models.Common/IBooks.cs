namespace Models.Common
{
    public interface IBooks
    {
        int AuthorID { get; set; }
        int BookId { get; set; }
        string Name { get; set; }
        int Year { get; set; }
    }
}
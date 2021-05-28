using System;
namespace Models.Common
{
    public interface IBooks
    {
        Guid AuthorID { get; set; }
        Guid BookId { get; set; }
        string Name { get; set; }
        int Year { get; set; }
    }
}
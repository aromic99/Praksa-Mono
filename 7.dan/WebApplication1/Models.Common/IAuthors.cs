namespace Models.Common
{
    public interface IAuthors
    {
        int AuthorID { get; set; }
        bool IsAlive { get; set; }
        string Name { get; set; }
    }
}
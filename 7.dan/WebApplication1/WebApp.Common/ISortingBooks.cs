namespace WebApp.Common
{
    public interface ISortingBooks
    {
        string SortBy { get; set; }
        string SortOrder { get; set; }

        bool Sort();
    }
}
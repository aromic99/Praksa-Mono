namespace WebApp.Common
{
    public interface ISortingAuthors
    {
        string SortBy { get; set; }
        string SortOrder { get; set; }

        bool Sort();
      
        
    }
}
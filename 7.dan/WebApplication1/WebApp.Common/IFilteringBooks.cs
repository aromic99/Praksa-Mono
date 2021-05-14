namespace WebApp.Common
{
    public interface IFilteringBooks
    {
        int Year { get; set; }
        string HowToFilter(IFilteringBooks howToFilter);
    }
}
namespace WebApp.Common
{
    public interface IPaging
    {
        int DataPerPage { get; set; }
        int Page { get; set; }
    }
}
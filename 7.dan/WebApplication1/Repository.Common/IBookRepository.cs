using MyBooks.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Models.Common;
using WebApp.Common;

namespace IRepository
{
    public interface IBookRepository
    {
        Task AddBook([FromBody] IBooks book);
        Task<List<IBooks>> AllBooks(ISortingBooks howToSort,IFilteringBooks howToFilter, IPaging bookPaging);
        Task<IBooks> BookById(int id);
        Task DeleteBook(int id);
        Task Updatebook(int id, [FromBody] IBooks book);
    }
}
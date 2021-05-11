using MyBooks.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Models.Common;

namespace IRepository
{
    public interface IBookRepository
    {
        Task AddBook([FromBody] IBooks book);
        Task<List<IBooks>> AllBooks();
        Task<IBooks> BookById(int id);
        Task DeleteBook(int id);
        Task Updatebook(int id, [FromBody] IBooks book);
    }
}
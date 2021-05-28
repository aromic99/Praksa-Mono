using MyBooks.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Models.Common;
using WebApp.Common;
using System;

namespace IRepository
{
    public interface IBookRepository
    {
        Task AddBook([FromBody] IBooks book);
        Task<List<IBooks>> AllBooks(ISortingBooks howToSort,IFilteringBooks howToFilter, IPaging bookPaging);
        Task<IBooks> BookById(Guid id);
        Task DeleteBook(Guid id);
        Task Updatebook(Guid id, [FromBody] IBooks book);
    }
}
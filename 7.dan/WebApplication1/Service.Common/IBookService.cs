using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Common;
using WebApp.Common;

namespace IService
{
    public interface IBookService
    {
        Task AddNewBook(IBooks book);
        Task DeleteTheBook(int id);
        Task<List<IBooks>> FindAllBooks(ISortingBooks howToSort, IFilteringBooks howToFilter, IPaging bookPaging);
        Task<IBooks> FindBookById(int id);
        Task UpdateBook(int id, IBooks book);
    }
}
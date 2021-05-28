using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Common;
using WebApp.Common;
using System;

namespace IService
{
    public interface IBookService
    {
        Task AddNewBook(IBooks book);
        Task DeleteTheBook(Guid id);
        Task<List<IBooks>> FindAllBooks(ISortingBooks howToSort, IFilteringBooks howToFilter, IPaging bookPaging);
        Task<IBooks> FindBookById(Guid id);
        Task UpdateBook(Guid id, IBooks book);
    }
}
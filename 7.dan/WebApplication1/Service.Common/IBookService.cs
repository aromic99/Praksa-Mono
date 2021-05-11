using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Common;

namespace IService
{
    public interface IBookService
    {
        Task AddNewBook(IBooks book);
        Task DeleteTheBook(int id);
        Task<List<IBooks>> FindAllBooks();
        Task<IBooks> FindBookById(int id);
        Task UpdateBook(int id, IBooks book);
    }
}
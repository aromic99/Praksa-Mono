using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Common;

namespace IService
{
    public interface IAuthorService
    {
        Task AddNewAuthor(IAuthors author);
        Task DeleteAnAuthor(int id);
        Task<List<IAuthors>> FindAllAuthors();
        Task<IAuthors> FindAuthorById(int id);
        Task UpdateAnAuthor(int id, IAuthors author);
    }
}
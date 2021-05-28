using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Common;
using WebApp.Common;
using System;

namespace IService
{
    public interface IAuthorService
    {
        Task AddNewAuthor(IAuthors author);
        Task DeleteAnAuthor(Guid id);
        Task<List<IAuthors>> FindAllAuthors(ISortingAuthors howToSort, IPaging authorPaging);
        Task<IAuthors> FindAuthorById(Guid id);
        Task UpdateAnAuthor(Guid id, IAuthors author);
    }
}
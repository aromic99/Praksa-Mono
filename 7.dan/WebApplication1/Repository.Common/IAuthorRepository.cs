using MyAuthors.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Models.Common;
using WebApp.Common;
using System;

namespace IRepository
{
    public interface IAuthorRepository
    {
        Task AddAnAuthor([FromBody] IAuthors author);
        Task<List<IAuthors>> AllAuthors(ISortingAuthors howToSort, IPaging authorPaging);
        Task<IAuthors> AuthorById(Guid id);
        Task DeleteAnAuthor(Guid id);
        Task UpdateAnAuthor(Guid id, [FromBody] IAuthors author);
    }
}
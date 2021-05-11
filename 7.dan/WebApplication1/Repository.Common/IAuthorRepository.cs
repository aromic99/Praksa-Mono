using MyAuthors.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Models.Common;

namespace IRepository
{
    public interface IAuthorRepository
    {
        Task AddAnAuthor([FromBody] IAuthors author);
        Task<List<IAuthors>> AllAuthors();
        Task<IAuthors> AuthorById(int id);
        Task DeleteAnAuthor(int id);
        Task UpdateAnAuthor(int id, [FromBody] IAuthors author);
    }
}
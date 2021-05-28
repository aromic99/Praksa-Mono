using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IService;
using IRepository;
using Models.Common;
using WebApp.Common;


namespace ProjectService
{
    public class AuthorService : IAuthorService
    {
        protected IAuthorRepository Repository { get; set; }
        public AuthorService(IAuthorRepository repository)
        {
            this.Repository = repository;
        }
        public async Task<List<IAuthors>> FindAllAuthors(ISortingAuthors howToSort, IPaging authorPaging)
        {
            return await Repository.AllAuthors(howToSort, authorPaging);
        }
        public async Task<IAuthors> FindAuthorById(Guid id)
        {
            return await Repository.AuthorById(id);
        }
        public async Task AddNewAuthor(IAuthors author)
        {
            await Repository.AddAnAuthor(author);
        }

        public async Task UpdateAnAuthor(Guid id, IAuthors author)
        {
            await Repository.UpdateAnAuthor(id, author);
        }
        public async Task DeleteAnAuthor(Guid id)
        {
            await Repository.DeleteAnAuthor(id);
        }
    }
}

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
    public class BookService : IBookService
    {
        protected IBookRepository Repository { get; set; }
        public BookService(IBookRepository repository)
        {
            this.Repository = repository;
        }
        public async Task<List<IBooks>> FindAllBooks(ISortingBooks howToSort, IFilteringBooks howToFilter, IPaging bookPaging)
        {
            return await Repository.AllBooks(howToSort, howToFilter, bookPaging);
        }

        public async Task<IBooks> FindBookById(int id)
        {
            return await Repository.BookById(id);
        }
        public async Task AddNewBook(IBooks book)
        {
            await Repository.AddBook(book);
        }
        public async Task UpdateBook(int id, IBooks book)
        {
            await Repository.Updatebook(id, book);
        }

        public async Task DeleteTheBook(int id)
        {
            await Repository.DeleteBook(id);
        }
    }
}
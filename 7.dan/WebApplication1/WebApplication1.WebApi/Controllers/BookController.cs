using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectService;
using MyBooks.Model;
using MyAuthors.Model;
using System.Threading.Tasks;
using IService;
using Models.Common;
using AutoMapper;
using WebApp.Common;

namespace WebApplication1.WebAPI.Controllers
{
    public class BookController : ApiController
    {
        public IBookService service { get; set; }
        public IAuthorService authorService { get; set; }
        private readonly IMapper _mapper;
        public BookController(IBookService service, IMapper mapper , IAuthorService authorService)
        {
            this.service = service;
            _mapper = mapper;
            this.authorService = authorService;
        }
        public class BookRest
        {
            public int BookId { get; set; }
            public string Name { get; set; }
            public int Year { get; set; }
            public int AuthorID { get; set; }

        }
        public class SortingBooksRest
        {
            public string SortBy { get; set; }
            public string SortOrder { get; set; }
        }
        public class FilteringBooksRest
        {
            public int Year { get; set; }
        }
        public class PagingRest
        {
            public int Page { get; set; }
            public int DataPerPage { get; set; }
        }
        [HttpGet]
        public async Task<HttpResponseMessage> GetBooks([FromUri]SortingBooksRest howToSort, [FromUri]FilteringBooksRest howToFilter, [FromUri] PagingRest bookPaging)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _mapper.Map<List<BookRest>>
                (await service.FindAllBooks(_mapper.Map<SortingBooks>(howToSort),_mapper.Map<FilteringBooks>(howToFilter), _mapper.Map<Paging>(bookPaging))));
        }
        // GET api/values/5
        [HttpGet]
        public async Task<HttpResponseMessage> GetBookById(int id)
        {
            
                if (await service.FindBookById(id) != null)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _mapper.Map<BookRest>(await service.FindBookById(id)));

                    return response;
                }
            return Request.CreateResponse(HttpStatusCode.NotFound, "ERROR 404, Book not found");
        }

        // POST api/values
        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] BookRest book)
        {
            if (await service.FindBookById(book.BookId) == null)
            {
                if (await authorService.FindAuthorById(book.AuthorID) != null)
                {
                    await service.AddNewBook(_mapper.Map<IBooks>(book));
                    return Request.CreateResponse(HttpStatusCode.OK, "New book added");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "There is no author with that ID");

            }
                return Request.CreateResponse(HttpStatusCode.NotFound, "There is already a book with that ID");

            }

        // PUT api/values/5
        public async Task<HttpResponseMessage> Put(int id, [FromBody] BookRest book)
        {
            
                if ( await service.FindBookById(id) == null)
                {
                    
                        if (await authorService .FindAuthorById(book.AuthorID) != null)
                        {
                            await service.UpdateBook(id, _mapper.Map<IBooks>(book));
                            return Request.CreateResponse(HttpStatusCode.OK, "Book updated");
                        }
                    
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "There is no author with that ID");
                }
            
            return Request.CreateResponse(HttpStatusCode.NotFound, "There is no book with that ID");
        }
        public async Task<HttpResponseMessage> Delete(int id)
        {
            
                if (await service.FindBookById(id) != null)
                {
                    await service.DeleteTheBook(id);
                    return Request.CreateResponse(HttpStatusCode.OK, "Book deleted");

                }
            return Request.CreateResponse(HttpStatusCode.NotFound, "ERROR 404, There is no book with that ID");

        }
    }
}

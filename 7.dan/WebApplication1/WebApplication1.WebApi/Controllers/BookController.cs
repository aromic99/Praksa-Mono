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

namespace WebApplication1.WebAPI.Controllers
{
    public class BookController : ApiController
    {
        public static IBookService service = new BookService();
        public static IAuthorService authorService = new AuthorService();
        [HttpGet]
        public async Task<HttpResponseMessage> GetBooks()
        {
            return Request.CreateResponse(HttpStatusCode.OK, await service.FindAllBooks());
        }
        // GET api/values/5
        [HttpGet]
        public async Task<HttpResponseMessage> GetBookById(int id)
        {
            List<IBooks> bookList = await service.FindAllBooks();
            for (int i = 0; i < bookList.Count; i++)
            {
                if (bookList[i].BookId == id)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, await service.FindBookById(id));

                    return response;
                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "ERROR 404, Book not found");
        }

        // POST api/values
        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] Book book)
        {
            List<IBooks> bookList = await service.FindAllBooks();
            for (int i = 0; i < bookList.Count; i++)
            {
                if (bookList[i].BookId == book.BookId)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "ERROR 400, There is already a book with that ID");
                }
            }
            await service.AddNewBook(book);
            return Request.CreateResponse(HttpStatusCode.OK, "New book added");
        }

        // PUT api/values/5
        public async Task<HttpResponseMessage> Put(int id, [FromBody] Book book)
        {
            List<IAuthors> authorList = await authorService.FindAllAuthors();
            List<IBooks> bookList = await service.FindAllBooks();
            for (int i = 0; i < bookList.Count; i++)
            {
                if (bookList[i].BookId == id)
                {
                    for (int j = 0; j < authorList.Count; j++)
                    {
                        if (authorList[j].AuthorID == book.AuthorID)
                        {
                            await service.UpdateBook(id, book);
                            return Request.CreateResponse(HttpStatusCode.OK, "Book updated");
                        }
                    }
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "There is no author with that ID");
                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "There is no book with that ID");
        }
        public async Task<HttpResponseMessage> Delete(int id)
        {
            List<IBooks> bookList = await service.FindAllBooks();
            for (int i = 0; i < bookList.Count; i++)
            {
                if (bookList[i].BookId == id)
                {
                    await service.DeleteTheBook(id);
                    return Request.CreateResponse(HttpStatusCode.OK, "Book deleted");

                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "ERROR 404, There is no book with that ID");

        }
    }
}

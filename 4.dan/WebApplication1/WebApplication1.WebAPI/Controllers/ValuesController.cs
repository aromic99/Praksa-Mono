using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Project.Repository;
using Project.Service;
using MyBooks.Model;
using MyAuthors.Model;

namespace WebApplication1.WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [HttpGet]
        [Route("api/values/books")]
        public HttpResponseMessage GetBooks()
        {
            return Request.CreateResponse(HttpStatusCode.OK, Service.FindAllBooks() );
        }
        [HttpGet]
        [Route("api/values/authors")]
        public HttpResponseMessage GetAuthors()
        {
            return Request.CreateResponse(HttpStatusCode.OK, Service.FindAllAuthors());
        }
        
       // GET api/values/5
       [HttpGet]
       public Books GetBookById(int id)
       {    

           return Service.FindBookById(id);
       }
        
       // POST api/values
       [HttpPost]
       [Route("api/values")]
       public void Post([FromBody] Books book)
       {
            Service.AddNewBook(book);
       }
        
       // PUT api/values/5
       public void Put(int id, [FromBody] Authors author)
       {
            Service.UpdateAnAuthor(id, author);
       }
        
       // DELETE api/values/5
       public void Delete(int id)
       {    
            Service.DeleteTheBook(id);
       }
    }
}

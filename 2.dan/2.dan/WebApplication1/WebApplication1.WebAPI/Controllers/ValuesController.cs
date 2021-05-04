using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.WebAPI.Controllers
{
    public class Author
    {
        public int id;
        public string name;
        public bool isAlive;

        public Author(int id, string name, bool isAlive)
        {
            this.id = id;
            this.name = name;
            this.isAlive = isAlive;

        }
        public Author() { }
        
        public int Id
        {
            set { id = value; }
        }
        public string Name
        {
            set { name = value; }
        }

        public bool IsAlive
        {

            set { isAlive = value; }
        }
        
 

    }
    public class ValuesController : ApiController
    {
        static List<Author> AuthorList = new List<Author>()
        {
            new Author { id = 0, name = "Albert Camus", isAlive = false },
            new Author { id = 1, name = "Marko Marulić", isAlive = false },
            new Author { id = 2, name = "Agatha Christie", isAlive = false },
            new Author { id = 3, name = "J.K. Rowling", isAlive = true },
            new Author { id = 4, name = "George R.R. Martin", isAlive = true },
            new Author { id = 5, name = "J.R.R. Tolkien", isAlive = false }

        };
        // GET api/values
        public IEnumerable<Author> Get()
        {
            return AuthorList;
        }

        // GET api/values/5
        [HttpGet]
        public HttpResponseMessage getName(int id)
        {
            
            if (id > AuthorList.Count) 
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "ERROR, NOT FOUND");
            }
            else if (id<0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ERROR, BAD REQUEST");
            }
            else
            { 
                return Request.CreateResponse(HttpStatusCode.OK, AuthorList[id].name);
            
            }
        }

        // POST api/values
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Author value)
        {
            if (value.id < AuthorList.Count)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ERROR 400, BAD REQUEST");
            }
            else
            {
                AuthorList.Add(value);
                return Request.CreateResponse(HttpStatusCode.OK, value.id); 
            }
        }

        // PUT api/values/5
        [HttpPut]
        public HttpResponseMessage died(int id, [FromBody] Author value)
        {
            if (id < 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "ERROR 40,BAD REQUEST");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, AuthorList[id] = value);
            }
            
        }

        // DELETE api/values/5
        public void Delete (int id)
        {   
            AuthorList.RemoveAt(id);
        }
    }
}

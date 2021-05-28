using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectService;
using MyAuthors.Model;
using System.Threading.Tasks;
using IService;
using AutoMapper;
using Models.Common;
using WebApp.Common;

namespace WebApplication1.WebAPI.Controllers
{
    public class AuthorController : ApiController
    {
        public IAuthorService Service { get; set; }
        private readonly IMapper _mapper;
        public AuthorController(IAuthorService service, IMapper mapper)
        {
            this.Service = service;
            _mapper = mapper;
        }
        public class SortingAuthorsRest 
        {
            public string SortBy { get; set; }
            public string SortOrder { get; set; }
            
        }
        public class PagingRestA
        {
            public int Page { get; set; }
            public int DataPerPage { get; set; }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetAuthors([FromUri] SortingAuthorsRest howToSort, [FromUri] PagingRestA authorPaging)
        {
            return Request.CreateResponse(_mapper.Map<List<AuthorRest>>(await Service.FindAllAuthors(_mapper.Map<SortingAuthors>(howToSort), _mapper.Map<Paging>(authorPaging))));
        }
        public class AuthorRest
        {
            public Guid AuthorID { get; set; }
            public string Name { get; set; }
            public bool IsAlive { get; set; }
        }
        
        [HttpGet]
        public async Task<HttpResponseMessage> GetAuthorById(Guid id)
        {
            
                if (await Service.FindAuthorById(id)!=null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, _mapper.Map<AuthorRest>(await Service.FindAuthorById(id)));

                }

            return Request.CreateResponse(HttpStatusCode.BadRequest, "There is no author with that ID");
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] AuthorRest author)
        {
            if (await Service.FindAuthorById(author.AuthorID) != null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "There is already an author with that ID");
            }
            await Service.AddNewAuthor(_mapper.Map<IAuthors>(author));
            return Request.CreateResponse(HttpStatusCode.OK, "New author added");
        }

        public async Task<HttpResponseMessage> Put(Guid id, [FromBody] AuthorRest author)
        {
            
                if (await Service.FindAuthorById(id) != null)
                {
                    await Service.UpdateAnAuthor(id, _mapper.Map<IAuthors>(author));
                    return Request.CreateResponse(HttpStatusCode.OK, "Author updated");

                }

            return Request.CreateResponse(HttpStatusCode.BadRequest, "There is no author with that ID");
        }

        public async Task<HttpResponseMessage> Delete(Guid id)
        {
                if (await Service.FindAuthorById(id) != null)
                {
                    await Service.DeleteAnAuthor(id);
                    return Request.CreateResponse(HttpStatusCode.OK, "Author deleted");
                }

            return Request.CreateResponse(HttpStatusCode.NotFound, "ERROR 404, There is no author with that ID");
        }
    }
}

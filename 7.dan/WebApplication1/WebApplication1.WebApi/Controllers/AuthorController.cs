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
using Models.Common;

namespace WebApplication1.WebAPI.Controllers
{
    public class AuthorController : ApiController
    {
        public static IAuthorService service = new AuthorService();

        [HttpGet]
        public async Task<HttpResponseMessage> GetAuthors()
        {
            return Request.CreateResponse(HttpStatusCode.OK, await service.FindAllAuthors());
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetAuthorById(int id)
        {
            List<IAuthors> authorList = await service.FindAllAuthors();
            for (int i = 0; i < authorList.Count; i++)
            {
                if (authorList[i].AuthorID == id)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, await service.FindAuthorById(id));

                }

            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "There is no author with that ID");
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] Author author)
        {
            List<IAuthors> authorList = await service.FindAllAuthors();
            for (int i = 0; i < authorList.Count; i++)
            {
                if (authorList[i].AuthorID == author.AuthorID)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "There is already an author with that ID");
                }
            }
            await service.AddNewAuthor(author);
            return Request.CreateResponse(HttpStatusCode.OK, "New author added");
        }

        public async Task<HttpResponseMessage> Put(int id, [FromBody] Author author)
        {
            List<IAuthors> authorList = await service.FindAllAuthors();
            for (int i = 0; i < authorList.Count; i++)
            {
                if (authorList[i].AuthorID == id)
                {
                    await service.UpdateAnAuthor(id, author);
                    return Request.CreateResponse(HttpStatusCode.OK, "Author updated");

                }

            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "There is no author with that ID");
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            List<IAuthors> authorList = await service.FindAllAuthors();
            for (int i = 0; i < authorList.Count; i++)
            {
                if (authorList[i].AuthorID == id)
                {
                    await service.DeleteAnAuthor(id);
                    return Request.CreateResponse(HttpStatusCode.OK, "Author deleted");

                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "ERROR 404, There is no author with that ID");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Common;
using AutoMapper;
using static WebApplication1.WebAPI.Controllers.BookController;
using static WebApplication1.WebAPI.Controllers.AuthorController;

namespace MyAutoMapper
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<BookRest, IBooks>().ReverseMap();
            CreateMap<AuthorRest, IAuthors>().ReverseMap();
        }
    }
}
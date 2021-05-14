using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Common;
using AutoMapper;
using static WebApplication1.WebAPI.Controllers.BookController;
using static WebApplication1.WebAPI.Controllers.AuthorController;
using DAL;
using WebApp.Common;

namespace MyAutoMapper
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<BookRest, IBooks>().ReverseMap();
            CreateMap<AuthorRest, IAuthors>().ReverseMap();
            CreateMap<IBooks, BookEntity>().ReverseMap();
            CreateMap<IAuthors, AuthorEntity>().ReverseMap();
            CreateMap<SortingAuthors, SortingAuthorsRest>().ReverseMap();
            CreateMap<SortingBooksRest, SortingBooks>().ReverseMap();
            CreateMap<FilteringBooksRest, FilteringBooks>().ReverseMap();
            CreateMap<PagingRest,Paging>().ReverseMap();
            CreateMap<PagingRestA, Paging>().ReverseMap();
        }
    }
}
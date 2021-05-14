using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;
using System.Reflection;
using IService;
using ProjectService;
using Models.Common;
using MyAuthors.Model;
using MyBooks.Model;
using IRepository;
using Project.Repository;
using WebApplication1.WebAPI.Controllers;
using AutoMapper;
using MyAutoMapper;

namespace WebApplication1.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            var config = new HttpConfiguration();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<Author>().As<IAuthors>();
            builder.RegisterType<Book>().As<IBooks>();
            builder.RegisterType<AuthorRepository>().As<IAuthorRepository>();
            builder.RegisterType<BookRepository>().As<IBookRepository>();
            builder.RegisterType<AuthorService>().As<IAuthorService>();
            builder.RegisterType<BookService>().As<IBookService>();


            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<OrganizationProfile>();
            })).AsSelf().InstancePerRequest();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var configuration = context.Resolve<MapperConfiguration>();
                return configuration.CreateMapper(context.Resolve);
            }).As<IMapper>().InstancePerLifetimeScope();

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver =
                 new AutofacWebApiDependencyResolver(container);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
}

using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using DomainLayer.Interfaces;
using RepositoryLayer;
using RepositoryLayer.Repositories;
using ServiceLayer.Services;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MarketPlaceProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            // Register MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register services and repositories
            builder.RegisterType<ItemService>().As<IItemService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<SubCategoryService>().As<ISubCategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<ItemContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ItemRepository>().As<IItemRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SubCategoryRepository>().As<ISubCategoryRepository>().InstancePerLifetimeScope();

            // Configure AutoMapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                // Assume AutoMapperProfile is your configuration class
                cfg.AddProfile(new AutoMapperProfile());
            });

            builder.RegisterInstance(mapperConfig).As<MapperConfiguration>(); // Register configuration
            builder.Register<IMapper>(ctx => new Mapper(mapperConfig, type => ctx.Resolve(type))); // Register IMapper

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}

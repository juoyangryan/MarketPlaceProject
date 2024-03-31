using DomainLayer.Interfaces;
using ServiceLayer.Services;
using RepositoryLayer.Repositories;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;


namespace MarketPlaceProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Standard MVC setup...
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            // Register MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register your types, e.g., services and repositories
            builder.RegisterType<ItemService>().As<IItemService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<SubCategoryService>().As<ISubCategoryService>();
            builder.RegisterType<UserService>().As<IUserService>();
            // Register the ItemContext. Adjust the lifetime scope as necessary.
            builder.RegisterType<ItemContext>()
                   .AsSelf() 
                   .InstancePerLifetimeScope(); // Adjust this based on your requirements

            // Register the ItemRepository to be resolved via its interface
            builder.RegisterType<ItemRepository>()
                   .As<IItemRepository>() 
                   .InstancePerLifetimeScope();
            builder.RegisterType<CategoryRepository>()
                   .As<ICategoryRepository>()
                    .InstancePerLifetimeScope();
            builder.RegisterType<SubCategoryRepository>()
                    .As<ISubCategoryRepository>()
                    .InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>()
                    .As<IUserRepository>()
                    .InstancePerLifetimeScope();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }


    }
}

using Autofac;
using Autofac.Integration.WebApi;
using Bll;
using Dal;
using System.Reflection;
using System.Web.Http;

namespace WebApplication1
{
    public static class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<NorthwindContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<Clock>().As<IClock>().SingleInstance();


            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}

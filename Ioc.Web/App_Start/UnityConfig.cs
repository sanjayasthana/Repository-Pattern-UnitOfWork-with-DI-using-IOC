using Ioc.Data;
using Ioc.Service;
using System.Web.Mvc;
using Unity;
using Unity.Lifetime;
using Unity.Mvc5;

namespace Ioc.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IDbContext, IocDbContext>(new ContainerControlledLifetimeManager());
            container.RegisterType<IUserService, UserService>();
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
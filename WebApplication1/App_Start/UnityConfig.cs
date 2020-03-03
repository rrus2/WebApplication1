using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;
using WebApplication1.Controllers;
using WebApplication1.Services;

namespace WebApplication1
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IProductService, ProductSevice>();
            container.RegisterType<IGenreService, GenreService>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
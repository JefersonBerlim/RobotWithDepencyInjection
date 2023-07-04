using IOC;
using System.Web.Mvc;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;


namespace WebApplication.App_Start
{
    public static class SimpleInjectorInitializer
    {
        internal static void Initialize()
        {

                var container = new ContainerBase();            
                container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

                // Chamada dos módulos do Simple Injector
                InitializeContainer(container);

                // container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
                container.Verify();

                DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(ContainerBase container)
        {
            RegisterServicesApplication.Register(container);
        }
    }
}
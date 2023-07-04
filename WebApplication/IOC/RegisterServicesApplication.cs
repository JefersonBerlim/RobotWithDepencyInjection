using Application.Interface;
using Application.Service;
using Domain.Interface;
using Domain.Model;
using Domain.Services;
using SimpleInjector;

namespace IOC
{
    public class RegisterServicesApplication
    {
        public static void Register(ContainerBase container)
        {
            container.Register<IRobo, Robo>(Lifestyle.Singleton);
            container.Register<IBracoService, BracoService>(Lifestyle.Scoped);
            container.Register<ICabecaService, CabecaService>(Lifestyle.Scoped);
            container.Register<IAppBracoService, AppBracoService>(Lifestyle.Scoped);
            container.Register<IAppCabecaService, AppCabecaService>(Lifestyle.Scoped);
        }
    }
}

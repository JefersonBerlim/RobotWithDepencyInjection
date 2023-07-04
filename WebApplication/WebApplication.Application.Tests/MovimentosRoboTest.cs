using System;
using Application.Interface;
using Application.Service;
using Domain.Enum;
using Domain.Interface;
using Domain.Model;
using Domain.Services;
using IOC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace WebApplication.Application.Tests
{
    [TestClass]
    public class MovimentosRoboTest
    {
        private void RegisterInterfaces(ContainerBase container)
        {
            container.Register<IRobo, Robo>(Lifestyle.Scoped);
            container.Register<IBracoService, BracoService>(Lifestyle.Scoped);
            container.Register<ICabecaService, CabecaService>(Lifestyle.Scoped);
            container.Register<IAppBracoService, AppBracoService>(Lifestyle.Scoped);
            container.Register<IAppCabecaService, AppCabecaService>(Lifestyle.Scoped);
        }

        [TestMethod]
        public void EstadoInicialTest()
        {
            var container = new ContainerBase();
            container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();
            this.RegisterInterfaces(container);

            using (ThreadScopedLifestyle.BeginScope(container))
            {
                IRobo robo = container.GetInstance<IRobo>();

                Assert.IsTrue(
                    robo.Cabeca.Inclinacao == (int)CabecaInclinacao.EmRepouso &&
                    robo.Cabeca.Rotacao == (int)CabecaRotacao.EmRepouso &&
                    robo.BracoDireito.Cotovelo == (int)Cotovelo.EmRepouso &&
                    robo.BracoEsquerdo.Cotovelo == (int)Cotovelo.EmRepouso &&
                    robo.BracoDireito.Pulso == (int)Pulso.EmRepouso &&
                    robo.BracoEsquerdo.Pulso == (int)Pulso.EmRepouso
                    );

            }
        }

        [TestMethod]
        public void MovimentoRotacaoCabecaInvalidoTest()
        {
            var container = new ContainerBase();
            container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();
            this.RegisterInterfaces(container);

            using (ThreadScopedLifestyle.BeginScope(container))
            {
                IRobo robo = container.GetInstance<IRobo>();
                ICabecaService cabecaService = container.GetInstance<ICabecaService>();
                IAppCabecaService service = new AppCabecaService(cabecaService, robo);

                robo.Cabeca.Inclinacao = (int)CabecaInclinacao.ParaBaixo;
                if (service.ValidaMovimentoRotacao((int)CabecaRotacao.Rotacao45, robo.Cabeca ))
                    service.RotacionaCabeca((int)CabecaRotacao.Rotacao45);

                Assert.IsTrue(robo.Cabeca.Rotacao != (int)CabecaRotacao.Rotacao45);

            }
        }

        [TestMethod]
        public void MovimentoRotacaoCabecaValidoTest()
        {
            var container = new ContainerBase();
            container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();
            this.RegisterInterfaces(container);

            using (ThreadScopedLifestyle.BeginScope(container))
            {
                IRobo robo = container.GetInstance<IRobo>();
                ICabecaService cabecaService = container.GetInstance<ICabecaService>();
                IAppCabecaService service = new AppCabecaService(cabecaService, robo);

                robo.Cabeca.Inclinacao = (int)CabecaInclinacao.ParaCima;

                service.RotacionaCabeca((int)CabecaRotacao.Rotacao45);

                Assert.IsTrue(robo.Cabeca.Rotacao == (int)CabecaRotacao.Rotacao45);

            }
        }

        [TestMethod]
        public void MovimentoInclinacaoCabecaInvalidoTest()
        {
            var container = new ContainerBase();
            container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();
            this.RegisterInterfaces(container);

            using (ThreadScopedLifestyle.BeginScope(container))
            {
                IRobo robo = container.GetInstance<IRobo>();
                ICabecaService cabecaService = container.GetInstance<ICabecaService>();
                IAppCabecaService service = new AppCabecaService(cabecaService, robo);

                var value = (int)CabecaInclinacao.ParaCima - 1;

                if (service.ValidaMovimentoInclinacao(value))
                    service.InclinaCabeca(value);

                Assert.IsTrue(robo.Cabeca.Inclinacao != value);

            }
        }

        [TestMethod]
        public void MovimentoInclinacaoCabecaValidoTest()
        {
            var container = new ContainerBase();
            container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();
            this.RegisterInterfaces(container);

            using (ThreadScopedLifestyle.BeginScope(container))
            {
                IRobo robo = container.GetInstance<IRobo>();
                ICabecaService cabecaService = container.GetInstance<ICabecaService>();
                IAppCabecaService service = new AppCabecaService(cabecaService, robo);

                var value = (int)CabecaInclinacao.ParaCima + 1;
                service.InclinaCabeca(value);

                Assert.IsTrue(robo.Cabeca.Inclinacao == value);

            }
        }

        [TestMethod]
        public void MovimentoPulsoInvalidoTest()
        {
            var container = new ContainerBase();
            container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();
            this.RegisterInterfaces(container);

            using (ThreadScopedLifestyle.BeginScope(container))
            {
                IRobo robo = container.GetInstance<IRobo>();
                IBracoService bracoService = container.GetInstance<IBracoService>();
                IAppBracoService service = new AppBracoService(bracoService, robo);

                robo.BracoDireito.Cotovelo = (int)Cotovelo.EmRepouso;

                if (service.ValidaMovimentoPulso((int)Pulso.Rotacao45, robo.BracoDireito))
                    service.MovimentaPulsoDireito((int)Pulso.Rotacao45);

                Assert.IsTrue(robo.BracoDireito.Pulso != (int)Pulso.Rotacao45);
            }
        }

        [TestMethod]
        public void MovimentoPulsoValidoTest()
        {
            var container = new ContainerBase();
            container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();
            this.RegisterInterfaces(container);

            using (ThreadScopedLifestyle.BeginScope(container))
            {
                IRobo robo = container.GetInstance<IRobo>();
                IBracoService bracoService = container.GetInstance<IBracoService>();
                IAppBracoService service = new AppBracoService(bracoService, robo);

                robo.BracoDireito.Cotovelo = (int)Cotovelo.FortementeContraido;

                service.MovimentaPulsoDireito((int)Pulso.Rotacao45);

                Assert.IsTrue(robo.BracoDireito.Pulso == (int)Pulso.Rotacao45);
            }
        }

        [TestMethod]
        public void MovimentoCotoveloInvalidoTest()
        {
            var container = new ContainerBase();
            container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();
            this.RegisterInterfaces(container);

            using (ThreadScopedLifestyle.BeginScope(container))
            {
                IRobo robo = container.GetInstance<IRobo>();
                IBracoService bracoService = container.GetInstance<IBracoService>();
                IAppBracoService service = new AppBracoService(bracoService, robo);

                var value = (int)Cotovelo.EmRepouso - 1;

                if (service.ValidaMovimentoCotovelo(value))
                    service.MovimentaCotoveloDireito(value);

                Assert.IsTrue(robo.BracoDireito.Cotovelo != value);

            }
        }

        [TestMethod]
        public void MovimentoCotoveloValidoTest()
        {
            var container = new ContainerBase();
            container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();
            this.RegisterInterfaces(container);

            using (ThreadScopedLifestyle.BeginScope(container))
            {
                IRobo robo = container.GetInstance<IRobo>();
                IBracoService bracoService = container.GetInstance<IBracoService>();
                IAppBracoService service = new AppBracoService(bracoService, robo);

                var value = (int)Cotovelo.FortementeContraido;

                robo.BracoDireito.Cotovelo = value;

                if (service.ValidaMovimentoCotovelo(value))
                    service.MovimentaCotoveloDireito(value);

                Assert.IsTrue(robo.BracoDireito.Cotovelo == value);

            }
        }
    }
}

using Application.Interface;
using Domain.Interface;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class AppBracoService : IAppBracoService
    {
        private readonly IBracoService _bracoService;

        public AppBracoService(IBracoService bracoService, IRobo robo)
        {
            _bracoService = bracoService;
        }

        public int RetornaStatusCotoveloEsquerdo()
        {
            return _bracoService.RetornaStatusCotoveloEsquerdo();
        }
        public int RetornaStatusCotoveloDireito()
        {
            return _bracoService.RetornaStatusCotoveloDireito();
        }

        public int RetornaStatusPulsoEsquerdo()
        {
            return _bracoService.RetornaStatusPulsoEsquerdo();
        }

        public int RetornaStatusPulsoDireito()
        {
            return _bracoService.RetornaStatusPulsoDireito();

        }

        public bool ValidaMovimentoPulso(int novoStatus, Braco braco)
        {
            return _bracoService.ValidaMovimentoPulso(novoStatus, braco);
        }

        public bool ValidaMovimentoCotovelo(int novoStatus)
        {
            return _bracoService.ValidaMovimentoCotovelo(novoStatus);
        }

        public IRobo MovimentaCotoveloEsquerdo(int novoStatus)
        {
            return _bracoService.MovimentaCotoveloEsquerdo(novoStatus);
        }

        public IRobo MovimentaCotoveloDireito(int novoStatus)
        {
            return _bracoService.MovimentaCotoveloDireito(novoStatus);
        }

        public IRobo MovimentaPulsoDireito(int novoStatus)
        {
            return _bracoService.MovimentaPulsoDireito(novoStatus);
        }

        public IRobo MovimentaPulsoEsquerdo(int novoStatus)
        {
            return _bracoService.MovimentaPulsoEsquerdo(novoStatus);
        }
    }
}

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
    public class AppCabecaService : IAppCabecaService
    {

        private readonly ICabecaService _cabecaService;

        public AppCabecaService(ICabecaService cabecaService, IRobo robo)
        {
            _cabecaService = cabecaService;
        }

        public int RetornaStatusRotacao()
        {
            return _cabecaService.RetornaStatusRotacao();
        }

        public int RetornaStatusInclinacao()
        {
            return _cabecaService.RetornaStatusInclinacao();
        }

        public bool ValidaMovimentoInclinacao(int novoStatus)
        {

            return _cabecaService.ValidaMovimentoInclinacao(novoStatus);
        }

        public bool ValidaMovimentoRotacao(int novoStatus, Cabeca cabeca)
        {
            return _cabecaService.ValidaMovimentoRotacao(novoStatus, cabeca);
        }

        public IRobo RotacionaCabeca(int novoStatus)
        {
            return _cabecaService.RotacionaCabeca(novoStatus);
        }

        public IRobo InclinaCabeca(int novoStatus)
        {
            return _cabecaService.InclinaCabeca(novoStatus);
        }
    }
}

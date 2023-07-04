using Domain.Enum;
using Domain.Interface;
using Domain.Model;
using System;

namespace Domain.Services
{
    public class CabecaService : ICabecaService
    {

        private readonly IRobo _robo;

        public CabecaService(IRobo robo)
        {
            _robo = robo;
        }

        public bool ValidaMovimentoInclinacao(int novoStatus)
        {
            if ((novoStatus < (int)CabecaInclinacao.ParaCima) ||
                novoStatus > (int)CabecaInclinacao.ParaBaixo)
            {
                return false;
            }

            return true;
        }

        public bool ValidaMovimentoRotacao(int novoStatus, Cabeca cabeca)
        {
            if (((novoStatus > (int)CabecaRotacao.Rotacao90) ||
                novoStatus < (int)CabecaRotacao.RotacaoMenos90) ||
                cabeca.Inclinacao == (int)CabecaInclinacao.ParaBaixo)
            {
                return false;
            }

            return true;
        }

        public IRobo InclinaCabeca(int novoStatus)
        {
            _robo.Cabeca.Inclinacao = novoStatus;

            return _robo;
        }

        public IRobo RotacionaCabeca(int novoStatus)
        {
            _robo.Cabeca.Rotacao = novoStatus;

            return _robo;
        }

        public int RetornaStatusInclinacao()
        {
            return _robo.Cabeca.Inclinacao;
        }

        public int RetornaStatusRotacao()
        {
            return _robo.Cabeca.Rotacao;
        }
    }
}

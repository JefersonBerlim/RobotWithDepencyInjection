using Domain.Enum;
using Domain.Interface;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class BracoService : IBracoService
    {

        private IRobo _robo;

        public BracoService(IRobo robo)
        {
            _robo = robo;
        }

        public bool ValidaMovimentoCotovelo(int novoStatus)
        {
            if ((novoStatus < (int)Cotovelo.EmRepouso) ||
                novoStatus > (int)Cotovelo.FortementeContraido)
            {
                return false;
            }

            return true;
        }

        public bool ValidaMovimentoPulso(int novoStatus, Braco braco)
        {
            if (((novoStatus < (int)Pulso.RotacaoMenos90) ||
                novoStatus > (int)Pulso.Rotacao180) ||
                braco.Cotovelo != (int)Cotovelo.FortementeContraido)
            {
                return false;
            }

            return true;
        }

        public IRobo MovimentaCotoveloDireito(int novoStatus)
        {
            _robo.BracoDireito.Cotovelo = novoStatus;

            return _robo;
        }

        public IRobo MovimentaCotoveloEsquerdo(int novoStatus)
        {
            _robo.BracoEsquerdo.Cotovelo = novoStatus;

            return _robo;

        }
        public IRobo MovimentaPulsoEsquerdo(int novoStatus)
        {
            _robo.BracoEsquerdo.Pulso = novoStatus;

            return _robo;
        }

        public IRobo MovimentaPulsoDireito(int novoStatus)
        {
            _robo.BracoDireito.Pulso = novoStatus;

            return _robo;
        }

        public int RetornaStatusCotoveloDireito()
        {
            return _robo.BracoDireito.Cotovelo;
        }

        public int RetornaStatusCotoveloEsquerdo()
        {
            return _robo.BracoEsquerdo.Cotovelo;
        }

        public int RetornaStatusPulsoDireito()
        {
            return _robo.BracoDireito.Pulso;
        }

        public int RetornaStatusPulsoEsquerdo()
        {
            return _robo.BracoEsquerdo.Pulso;
        }

    }
}

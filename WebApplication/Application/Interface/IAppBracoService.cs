using Domain.Interface;
using Domain.Model;

namespace Application.Interface
{
    public interface IAppBracoService
    {
        int RetornaStatusCotoveloEsquerdo();
        int RetornaStatusCotoveloDireito();

        int RetornaStatusPulsoEsquerdo();

        int RetornaStatusPulsoDireito();

        bool ValidaMovimentoPulso(int novoStatus, Braco braco);

        bool ValidaMovimentoCotovelo(int novoStatus);

        IRobo MovimentaCotoveloEsquerdo(int novoStatus);

        IRobo MovimentaCotoveloDireito(int novoStatus);

        IRobo MovimentaPulsoDireito(int novoStatus);

        IRobo MovimentaPulsoEsquerdo(int novoStatus);
    }
}

using Domain.Model;

namespace Domain.Interface
{
    public interface IBracoService
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

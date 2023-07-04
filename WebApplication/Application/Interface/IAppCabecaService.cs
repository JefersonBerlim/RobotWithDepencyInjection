using Domain.Interface;
using Domain.Model;

namespace Application.Interface
{
    public interface IAppCabecaService
    {
        int RetornaStatusRotacao();

        int RetornaStatusInclinacao();

        bool ValidaMovimentoInclinacao(int novoStatus );

        bool ValidaMovimentoRotacao(int novoStatus, Cabeca cabeca);

        IRobo RotacionaCabeca(int novoStatus);

        IRobo InclinaCabeca(int novoStatus);
    }
}

using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface ICabecaService
    {

        int RetornaStatusRotacao();

        int RetornaStatusInclinacao();

        bool ValidaMovimentoInclinacao(int novoStatus);

        bool ValidaMovimentoRotacao(int novoStatus, Cabeca cabeca);

        IRobo RotacionaCabeca(int novoStatus);

        IRobo InclinaCabeca(int novoStatus);
    }
}

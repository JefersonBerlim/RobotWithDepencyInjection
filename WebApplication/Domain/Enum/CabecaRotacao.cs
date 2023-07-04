using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enum
{
    public enum CabecaRotacao : int
    {
        RotacaoMenos90 = 1,
        RotacaoMenos45 = 2,
        EmRepouso = 3,
        Rotacao45 = 4,
        Rotacao90 = 5
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enum
{
    public enum Pulso : int
    {
        RotacaoMenos90 = 1,
        RotacaoMenos45 = 2,
        EmRepouso = 3,
        Rotacao45 = 4,
        Rotacao90 = 5,
        Rotacao135 = 6,
        Rotacao180 = 7
    }
}

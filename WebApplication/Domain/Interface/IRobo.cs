using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IRobo
    {
        Braco BracoDireito { get; set; }
        Braco BracoEsquerdo { get; set; }
        Cabeca Cabeca { get; set; }
    }
}

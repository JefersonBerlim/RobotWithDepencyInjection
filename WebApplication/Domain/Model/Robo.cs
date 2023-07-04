using Domain.Enum;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Robo : IRobo
    {
        public Cabeca Cabeca { get; set; }
        public Braco BracoEsquerdo { get; set; }
        public Braco BracoDireito { get; set; }

        public Robo()
        {
            Cabeca = new Cabeca();
            BracoEsquerdo = new Braco();
            BracoDireito = new Braco();

            Cabeca.Inclinacao = (int)CabecaInclinacao.EmRepouso;
            Cabeca.Rotacao = (int)CabecaRotacao.EmRepouso;

            BracoDireito.Cotovelo = (int)Cotovelo.EmRepouso;
            BracoDireito.Pulso = (int)Pulso.EmRepouso;

            BracoEsquerdo.Cotovelo = (int)Cotovelo.EmRepouso;
            BracoEsquerdo.Pulso = (int)Pulso.EmRepouso;
        }
    }
}
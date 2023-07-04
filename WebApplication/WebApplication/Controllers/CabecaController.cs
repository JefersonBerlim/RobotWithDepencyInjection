using Domain.Interface;
using System;
using System.Net;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class CabecaController : Controller
    {
        private ICabecaService _cabecaService;
        private IRobo _robo;
        public CabecaController(ICabecaService cabecaService, IRobo robo)
        {
            _cabecaService = cabecaService;
            _robo = robo;
        }

        public ActionResult MovimentoInclinacaoAcima()
        {
            var Inclinacao = _robo.Cabeca.Inclinacao + 1;
            if (_cabecaService.ValidaMovimentoInclinacao(Inclinacao))
                _cabecaService.InclinaCabeca(Inclinacao);
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);

            return Json(_robo);
        }

        public ActionResult MovimentoInclinacaoAbaixo()
        {
            var Inclinacao = _robo.Cabeca.Inclinacao - 1;
            if (_cabecaService.ValidaMovimentoInclinacao(Inclinacao))
                _cabecaService.InclinaCabeca(Inclinacao);
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);

            return Json(_robo);
        }

        public ActionResult MovimentoRotacaoAcima()
        {
            var Rotacao = _robo.Cabeca.Rotacao + 1;
            if (_cabecaService.ValidaMovimentoRotacao(Rotacao, _robo.Cabeca))
                _cabecaService.RotacionaCabeca(Rotacao);
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);

            return Json(_robo);
        }

        public ActionResult MovimentoRotacaoAbaixo()
        {
            var Rotacao = _robo.Cabeca.Rotacao - 1;
            if (_cabecaService.ValidaMovimentoRotacao(Rotacao, _robo.Cabeca))
                _cabecaService.RotacionaCabeca(Rotacao);
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);

            return Json(_robo);
        }
    }
}
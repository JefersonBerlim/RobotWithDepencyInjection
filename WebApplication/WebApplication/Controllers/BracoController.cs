using Application.Interface;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class BracoController : Controller
    {
        private IAppBracoService _appBracoService;
        private IRobo _robo;
        public BracoController(IAppBracoService appBracoService, IRobo robo)
        {
            _appBracoService = appBracoService;
            _robo = robo;
        }

        public ActionResult MovimentoCotoveloDireitoAcima()
        {
            var CotoveloDireito = _robo.BracoDireito.Cotovelo + 1;
            if (_appBracoService.ValidaMovimentoCotovelo(CotoveloDireito))            
                _appBracoService.MovimentaCotoveloDireito(CotoveloDireito);
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);

            return Json(_robo);
        }

        public ActionResult MovimentoCotoveloDireitoAbaixo()
        {
            var CotoveloDireito = _robo.BracoDireito.Cotovelo - 1;
            if (_appBracoService.ValidaMovimentoCotovelo(CotoveloDireito))
                _appBracoService.MovimentaCotoveloDireito(CotoveloDireito);
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);

            return Json(_robo);
        }

        public ActionResult MovimentoCotoveloEsquerdoAcima()
        {
            var CotoveloEsquerdo = _robo.BracoEsquerdo.Cotovelo + 1;
            if (_appBracoService.ValidaMovimentoCotovelo(CotoveloEsquerdo))
                _appBracoService.MovimentaCotoveloEsquerdo(CotoveloEsquerdo);
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);

            return Json(_robo);
        }

        public ActionResult MovimentoCotoveloEsquerdoAbaixo()
        {
            var CotoveloEsquerdo = _robo.BracoEsquerdo.Cotovelo - 1;
            if (_appBracoService.ValidaMovimentoCotovelo(CotoveloEsquerdo))
                _appBracoService.MovimentaCotoveloEsquerdo(CotoveloEsquerdo);
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);

            return Json(_robo);
        }

        public ActionResult MovimentoPulsoDireitoAcima()
        {
            var PulsoDireito = _robo.BracoDireito.Pulso + 1;
            if (_appBracoService.ValidaMovimentoPulso(PulsoDireito, _robo.BracoDireito))
                _appBracoService.MovimentaPulsoDireito(PulsoDireito);
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);

            return Json(_robo);
        }

        public ActionResult MovimentoPulsoDireitoAbaixo()
        {
            var PulsoDireito = _robo.BracoDireito.Pulso - 1;
            if (_appBracoService.ValidaMovimentoPulso(PulsoDireito, _robo.BracoDireito))
                _appBracoService.MovimentaPulsoDireito(PulsoDireito);
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);

            return Json(_robo);
        }

        public ActionResult MovimentoPulsoEsquerdoAcima()
        {
            var PulsoEsquerdo = _robo.BracoEsquerdo.Pulso + 1;
            if (_appBracoService.ValidaMovimentoPulso(PulsoEsquerdo, _robo.BracoEsquerdo))
                _appBracoService.MovimentaPulsoEsquerdo(PulsoEsquerdo);
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);

            return Json(_robo);
        }

        public ActionResult MovimentoPulsoEsquerdoAbaixo()
        {
            var PulsoEsquerdo = _robo.BracoEsquerdo.Pulso - 1;
            if (_appBracoService.ValidaMovimentoPulso(PulsoEsquerdo, _robo.BracoEsquerdo))
                _appBracoService.MovimentaPulsoEsquerdo(PulsoEsquerdo);
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);

            return Json(_robo);
        }
    }
}
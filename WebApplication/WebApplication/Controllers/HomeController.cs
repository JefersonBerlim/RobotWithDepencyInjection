using Domain.Interface;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private IRobo _robo;
        public HomeController(IRobo robo)
        {
            _robo = robo;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult StatusRobo()
        {
            return Json(_robo, JsonRequestBehavior.AllowGet);
        }
    }
}
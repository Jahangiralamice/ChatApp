using ChatApp.Models;
using ChatApp.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ChatApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        public ActionResult Index()
        {
            IList<UserRegistration> list = _unitOfWork.UserRegistrationRepository.Get().ToList();
            return View(list);
        }






















        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
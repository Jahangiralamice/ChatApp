using ChatApp.Models;
using ChatApp.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ChatApp.Controllers
{
    public class UserRegistrationController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        public ActionResult Index()
        {
            ViewBag.SuccessMessage = "";
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserRegistration userRegistration)
        {
            _unitOfWork.UserRegistrationRepository.Insert(userRegistration);
            _unitOfWork.Save();
            ViewBag.SuccessMessage = "Registration has been done successfully! ";
            ModelState.Clear();
            return View();
        }

        #region Login and Log Off
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(string email)
        {
            IList<UserRegistration> list = _unitOfWork.UserRegistrationRepository.Get().Where(x => x.Email == email).ToList();

            if (list.Count > 0)
            {
                Session["logUser"] = list.FirstOrDefault();
                return Json(new JsonResult() { Data = new { Status = "Success" } }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new JsonResult() { Data = new { Status = "Failed" } }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult LogOut()
        {
            Session["logUser"] = null;
            return RedirectToAction("Index");
        }
        #endregion
    }
}
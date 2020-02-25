using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AVcompanyWeb.Models;
using AVcompanyWeb.Repositories;

namespace AVcompanyWeb.Controllers
{
    public class HomeController : Controller
    {
        private UserRepository userRepository;

        public HomeController()
        {
            userRepository = new UserRepository();
        }

        public ActionResult Index()
        {
            return View();
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

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            User validateUser = userRepository.FindBy(x => x.username == user.username && x.password == user.password).FirstOrDefault();

            if (validateUser != null)
            {
                if (validateUser.isActive)
                {
                    Session["user"] = validateUser;
                    return RedirectToAction("List", "Product");
                }
                else
                {
                    TempData["message"] = "Nombre de usuario y/o contraseña incorrecta.";
                    return RedirectToAction("Login", "Home");
                }
            }
            else
            {
                TempData["message"] = "Nombre de usuario y/o contraseña incorrecta.";
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Remove("user");
            return RedirectToAction("Login", "Home");
        }


    }
}
using ECOMMERCE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECOMMERCE.Controllers
{
    public class HomeController : Controller
    {
        private ECommerceContext db = new ECommerceContext();
        public ActionResult Index()
        {
            //Cuando el usuario se loggee vamos a buscar la foto de la compañia y se la pegamos a la vista.
            //Busca si el usuario está registrado como usuario en las tablas
            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault(); 
            return View(user);
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
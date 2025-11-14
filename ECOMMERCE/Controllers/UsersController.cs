using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECOMMERCE.Clases;
using ECOMMERCE.Models;

namespace ECOMMERCE.Controllers
{
    public class UsersController : Controller
    {
        private ECommerceContext db = new ECommerceContext();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.City).Include(u => u.Company).Include(u => u.Deparment);
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(ComboHelper.GetCities(), "CityId", "Name");
            ViewBag.CompanyId = new SelectList(ComboHelper.GetCompanies(), "CompanyId", "Name");
            ViewBag.DepartmentId = new SelectList(ComboHelper.GetDepartments(), "DepartmentId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                UserHelper.CreateUserASP(user.UserName, "User"); //Creamos el usuario como User.

                if (user.PhotoFile != null) //Si tiene foto, que suba la foto en la carpeta.
                {
                    var folder = "~/Content/Users";
                    var file = string.Format("{0}.jpg", user.UserId);
                    var response = FileHelper.UploadPhoto(user.PhotoFile, folder, file);
                    if (response)
                    {
                        var pic = string.Format("{0}/{1}", folder, file); //La ruta es el folder y el pic
                        user.Photo = pic;
                        db.Entry(user).State = EntityState.Modified;//Actualizamos la base de datos
                        db.SaveChanges();
                    }
                }

                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(ComboHelper.GetCities(), "CityId", "Name", user.CityId);
            ViewBag.CompanyId = new SelectList(ComboHelper.GetCompanies(), "CompanyId", "Name", user.CompanyId);
            ViewBag.DepartmentId = new SelectList(ComboHelper.GetDepartments(), "DepartmentId", "Name", user.DepartmentId);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(ComboHelper.GetCities(), "CityId", "Name", user.CityId);
            ViewBag.CompanyId = new SelectList(ComboHelper.GetCompanies(), "CompanyId", "Name", user.CompanyId);
            ViewBag.DepartmentId = new SelectList(ComboHelper.GetDepartments(), "DepartmentId", "Name", user.DepartmentId);
            return View(user);
        }

        // POST: Users/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.PhotoFile != null) //Si tiene logo, que suba la foto en la carpeta.
                {
                    var folder = "~/Content/Users";
                    var file = string.Format("{0}.jpg", user.UserId);
                    var response = FileHelper.UploadPhoto(user.PhotoFile, folder, file);

                    if (response)
                    {
                        var pic = string.Format("{0}/{1}", folder, file); //La ruta es el folder y el pic
                        user.Photo = pic;
                    }
                }
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(ComboHelper.GetCities(), "CityId", "Name", user.CityId);
            ViewBag.CompanyId = new SelectList(ComboHelper.GetCompanies(), "CompanyId", "Name", user.CompanyId);
            ViewBag.DepartmentId = new SelectList(ComboHelper.GetDepartments(), "DepartmentId", "Name", user.DepartmentId);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult GetCities(int departmentId) //Devuelve datos en formato Json (devuelve las ciudades de un determiando departamento)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var cities = db.Cities.Where(c => c.DepartmentId == departmentId);
            return Json(cities); //Me pasa los datos en formato Json (para poder consumirlos en JavaScript)
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

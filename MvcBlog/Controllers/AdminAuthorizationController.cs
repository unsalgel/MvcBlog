using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class AdminAuthorizationController : Controller
    {
        Context c = new Context();
        AdminManager  repoadmn = new AdminManager();
        // GET: AdminAuthorization
        public ActionResult AdminAuthorizationUpdate()
        {
            var adminlist = repoadmn.GetAll();
            return View(adminlist);
        }
        [HttpGet]
        public ActionResult AdminUpdate(int id)
        {
            Admin admin = repoadmn.FindAdmin(id);
            return View(admin);
        }
        [HttpPost]
        public ActionResult AdminUpdate(Admin a)
        {
            repoadmn.EditAdmin(a);
            return RedirectToAction("AdminAuthorizationUpdate");
        }
    }
}
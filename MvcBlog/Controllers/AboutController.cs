using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    [AllowAnonymous] //authorize özelligini kapatma
    public class AboutController : Controller
    {
        AboutManager Abm = new AboutManager();
        // GET: About
        public ActionResult Index()
        {
            var AboutContent = Abm.GetAll();
            return View(AboutContent);
        }
        public PartialViewResult Footer()
        {

            var sorgu = Abm.GetAll();
            return PartialView(sorgu);
        }
        public PartialViewResult MeetTheTeam()
        {
            AuthorManager au = new AuthorManager();
            var authorList = au.GetAll().OrderByDescending(p=>p.AuthorID).Take(3); // son üç yazarı getiriyor
            return PartialView(authorList); // Yazarları listeleme
        }
        [HttpGet]
        public ActionResult UpdateAboutList()
        {
            var aboutlist = Abm.GetAll();
            return View(aboutlist);
        }
        [HttpPost]
        public  ActionResult UpdateAbout(About a)
        {
            Abm.UpdateAboutBM(a);
            return RedirectToAction("UpdateAboutList");
        }


    }

}
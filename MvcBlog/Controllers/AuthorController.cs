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
    public class AuthorController : Controller
    {
 
        BlogManager bm = new BlogManager();
        AuthorManager am = new AuthorManager();
        [AllowAnonymous] //authorize özelligini kapatma
        public PartialViewResult AuthorAbout(int id)
        {
           
            var authordetail = bm.GetBlogByID(id);
            return PartialView(authordetail);
        }
        // yazara ait blogları getirme
        [AllowAnonymous] //authorize özelligini kapatma
        public PartialViewResult AuthorPopularPost(int id)
        {
            var blogauthorid = bm.GetAll().Where(p=>p.BlogID == id).Select(y => y.AuthorID).FirstOrDefault();
            var authorblog = bm.GetAuthorByID(blogauthorid);
            return PartialView(authorblog);
        }
        public ActionResult AuthorList()
        {
           var adminauthorlist= am.GetAll();
            return View(adminauthorlist);
        }
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(Author a)
        {
            am.AddAuthorBL(a);
            return RedirectToAction("AuthorList");
        }
       [HttpGet]
       //Yazarların verilerini çekme
        public ActionResult AuthorEdit(int id)
        {
            Author author = am.FindAuthor(id);
            return View(author);
        }
        [HttpPost]
        public ActionResult AuthorEdit(Author p)
        {
            am.EditAuthor(p);
            return RedirectToAction("AuthorList");
        }
    }
}
using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcBlog.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        Context c = new Context();
        BlogManager bm = new BlogManager();
        // Yazar controller
        UserProfileManager userProfile = new UserProfileManager();
        public ActionResult Index()
        {
            return View();
        } 
        //Profilimi Düzenle Sayfası
        public PartialViewResult SettingsPartial(string p)
        {
            p = (string)Session["Mail"];
            var profilevalues = userProfile.GetAuthorByMail(p);
            return PartialView(profilevalues);
        }
        public ActionResult UpdateAuthorProfile(Author p)
        {
            userProfile.EditAuthor(p);
            return RedirectToAction("Index");
        }



        //Giriş yapan yazara göre verilerini getirme
        public ActionResult BlogList(string p)
        {
            Context c = new Context();
            p = (string)Session["Mail"];
            int id = c.Authors.Where(a=>a.Mail==p).Select(y=>y.AuthorID).FirstOrDefault();
            var blogs = userProfile.GetBlogByAuthor(id);
            return View(blogs);
        }
        public ActionResult UpdateBlog(int id)
        {
            Blog blog = bm.FindBlog(id);

            List<SelectListItem> Category = (from item in c.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = item.CategoryName,
                                                 Value = item.CategoryID.ToString()
                                             }
                                            ).ToList();
            ViewBag.category = Category;
            List<SelectListItem> Author = (from x in c.Authors.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AuthorName,
                                               Value = x.AuthorID.ToString()
                                           }
                                           ).ToList();
            ViewBag.Author = Author;
            return View(blog);

        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            bm.UpdateBlog(p);
            return RedirectToAction("BlogList");
        }
        public ActionResult AddNewBlog()
        {

            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName, //kategori adını çekerken
                                               Value = x.CategoryID.ToString() // arka tarafta idsi ile işlem yapsın
                                           }).ToList();
            ViewBag.values = values;
            List<SelectListItem> authorvalues = (from p in c.Authors.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = p.AuthorName,
                                                     Value = p.AuthorID.ToString()
                                                 }).ToList();
            ViewBag.authorvalues = authorvalues;

            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog b)
        {
            bm.BlogAddBL(b);
            return RedirectToAction("BlogList");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin", "Login");
        }
    }
}
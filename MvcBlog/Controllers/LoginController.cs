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
    [AllowAnonymous] //authorize özelligini kapatma
    public class LoginController : Controller
    {

        Context c = new Context();
        // GET: Login
        [HttpGet]
        public ActionResult AuthorLogin()
        {
            return View();
        }
        //Yazar Oturum Açma
        [HttpPost]
        public ActionResult AuthorLogin(Author p)
        {
            var userinfo = c.Authors.FirstOrDefault(a => a.Mail == p.Mail && a.Password == p.Password);
            if (userinfo !=null)
            {
                FormsAuthentication.SetAuthCookie(userinfo.Mail, false);
                Session["Mail"] = userinfo.Mail.ToString();
                Session["AuthorName"] = userinfo.AuthorName.ToString();
                return RedirectToAction("Index", "User");

            }
            else
            {
            return RedirectToAction("AuthorLogin", "Login");
            }
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        //Admin Oturum Açma
        [HttpPost]
        public ActionResult AdminLogin(Admin admn)
        {
            var admininfo = c.Admins.FirstOrDefault(x => x.UserName == admn.UserName && x.Password == admn.Password);
            if (admininfo!=null)
            {
                FormsAuthentication.SetAuthCookie(admininfo.UserName, false);
                Session["UserName"] = admininfo.UserName.ToString();
                return RedirectToAction("AdminBlogList", "Blog");
            }
            else
            {
                return RedirectToAction("AdminLogin", "Login");
            }
        }
       
    }
}
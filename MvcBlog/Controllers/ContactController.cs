using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager();
        // GET: Contact
        [AllowAnonymous] //authorize özelligini kapatma
        public ActionResult Index()
        {  
            return View();
        }
        [HttpGet]
        [AllowAnonymous] //authorize özelligini kapatma
        public ActionResult SendMessage()
        {
            return View();
        }
        [AllowAnonymous] //authorize özelligini kapatma
        [HttpPost]
        public ActionResult SendMessage(Contact c)
        {
            cm.BLContactAdd(c);
            return View();
        }
        //İletişim  kısmından gönderilen mesajların listelenmesi 
        public ActionResult SendBox()
        {
            var maillist = cm.GetAll();
            return View(maillist);
        }
        //Admin kısmında  gönderilen mesajın içerigini görmek için yazdığım kod blogu
        public ActionResult MessageDetails(int id)
        {
            Contact contact = cm.GetContactDetails(id);
            return View(contact);

        }
    }
}
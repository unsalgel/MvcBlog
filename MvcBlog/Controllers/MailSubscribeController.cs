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
    [AllowAnonymous] //authorize özelligini kapatma
    public class MailSubscribeController : Controller
    { 
        SubscribeMailManager sm = new SubscribeMailManager();
        // GET: MailSubscribe
        [HttpGet]
        public PartialViewResult AddMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult AddMail(SubscribeMail p)
        {
            var sorgu = sm.BLAdd(p);
            return PartialView();
        }
    }
}
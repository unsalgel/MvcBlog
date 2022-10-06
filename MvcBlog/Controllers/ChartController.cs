using DataAccesLayer.Concrete;
using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeResult()
        {
            return Json(bloglist(), JsonRequestBehavior.AllowGet);
        }
        public List<Class1> bloglist()
        {
            List<Class1> cs = new List<Class1>();
            Context c = new Context();
            cs = c.Blogs.Select(p => new Class1
            {

                BlogName = p.BlogTitle,
                Rating = p.BlogRating


            }).ToList();
            return cs;
        }
        public ActionResult Chart2()
        {
            return View();  
        }
        public ActionResult LimeChart()
        {
            return View();
        }
    }
}



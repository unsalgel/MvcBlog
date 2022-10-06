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
    public class CategoryController : Controller
    {

        CategoryManager cm = new CategoryManager();
        [AllowAnonymous] //authorize özelligini kapatma
        public ActionResult Index()
        {
         
            var categoryvalues = cm.GetAll();
            return View(categoryvalues);
        }
        [AllowAnonymous] //authorize özelligini kapatma
        public PartialViewResult BlogDetailsCategoryList()
        {  
            var categoryvalues = cm.GetAll().Where(p=>p.CategoryStatus==true);
            return PartialView(categoryvalues);
        }
        public ActionResult AdminCategoryList()
        {
            var categorylist = cm.GetAll();
            return View(categorylist);
        }
        [HttpGet]
        public ActionResult AdminCategoryAdd()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AdminCategoryAdd(Category cat)
        {
            cm.AdminCategoryAddBL(cat);
            return RedirectToAction("AdminCategoryList");
            
        }
        public ActionResult DeleteCategory(int id)
        {
            cm.AdminCategoryDeleteBL(id);
            return RedirectToAction("AdminCategoryList");
        }
        [HttpGet]
        public ActionResult CategoryEdit(int id)
        {
            Category category = cm.FindCategory(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult CategoryEdit(Category ct)
        {
            cm.CategoryEdit(ct);
            return RedirectToAction("AdminCategoryList");
        }
        //Kategorileri gizleme
        public ActionResult CategoryStatusFalse(int id)
        {
         cm.CategoryStatusChangeToFalse(id);
            return RedirectToAction("AdminCategoryList");
        }
        public ActionResult CategoryStatusTrue(int id)
        {
            cm.CategoryStatusChangeToTrue(id);
            return RedirectToAction("AdminCategoryList");
        }
    }
}
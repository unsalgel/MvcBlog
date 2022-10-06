using BusinessLayer.Concrete;
using PagedList.Mvc;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer.Concrete;
using DataAccesLayer.Concrete;

namespace MvcBlog.Controllers
{
    public class BlogController : Controller
    {
        Context c = new Context();
        BlogManager bm = new BlogManager();
        // GET: Blog
        [AllowAnonymous] //authorize özelligini kapatma
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous] //authorize özelligini kapatma
        public PartialViewResult BlogList(int page = 1)
        {
            var getir = bm.GetAll().Where(p=>p.Category.CategoryStatus==true).OrderByDescending(p => p.BlogID).ToPagedList(page, 4);
            return PartialView(getir);
        }
        [AllowAnonymous] //authorize özelligini kapatma
        public PartialViewResult FeaturedPosts() //Öne çıkan postlar
        {
            //1.post   Yazılım
            var posttitle1 = bm.GetAll().OrderByDescending(p => p.BlogID).Where(p => p.CategoryID == 1 && p.Category.CategoryStatus == true).Select(p => p.BlogTitle).FirstOrDefault();
            var postimage1 = bm.GetAll().OrderByDescending(p => p.BlogID).Where(p => p.CategoryID == 1 && p.Category.CategoryStatus == true).Select(p => p.BlogImage).FirstOrDefault();
            var postdate1 = bm.GetAll().OrderByDescending(p => p.BlogID).Where(p => p.CategoryID == 1 && p.Category.CategoryStatus == true).Select(p => p.BlogDate.ToString("dd-MMM-yyyy")).FirstOrDefault();
            var blogpostid1 = bm.GetAll().OrderByDescending(p => p.BlogID).Where(p => p.CategoryID == 1 && p.Category.CategoryStatus == true).Select(P => P.BlogID).FirstOrDefault();
            ViewBag.posttitle1 = posttitle1;
            ViewBag.postimage1 = postimage1;
            ViewBag.postdate1 = postdate1;
            ViewBag.blogpostid1 = blogpostid1;
            //2.post  Teknoloji
            var posttitle2 = bm.GetAll().OrderByDescending(p => p.BlogID).Where(p => p.CategoryID == 2 && p.Category.CategoryStatus == true).Select(p => p.BlogTitle).FirstOrDefault();
            var postimage2 = bm.GetAll().OrderByDescending(p => p.BlogID).Where(p => p.CategoryID == 2 && p.Category.CategoryStatus == true).Select(p => p.BlogImage).FirstOrDefault();
            var postdate2 = bm.GetAll().OrderByDescending(p => p.BlogID).Where(p => p.CategoryID == 2 && p.Category.CategoryStatus == true).Select(p => p.BlogDate.ToString("dd-MMM-yyyy")).FirstOrDefault();
            var blogpostid2 = bm.GetAll().OrderByDescending(p => p.BlogID).Where(p => p.CategoryID == 2 && p.Category.CategoryStatus == true).Select(p => p.BlogID).FirstOrDefault();
            ViewBag.posttitle2 = posttitle2;
            ViewBag.postimage2 = postimage2;
            ViewBag.postdate2 = postdate2;
            ViewBag.blogpostid2 = blogpostid2;
            //3.post  Film & Dizi
            var posttitle3 = bm.GetAll().OrderByDescending(p => p.BlogID).Where(p => p.CategoryID == 3 && p.Category.CategoryStatus == true).Select(p => p.BlogTitle).FirstOrDefault();
            var postimage3 = bm.GetAll().OrderByDescending(p => p.BlogID).Where(p => p.CategoryID == 3 && p.Category.CategoryStatus == true).Select(p => p.BlogImage).FirstOrDefault();
            var postdate3 = bm.GetAll().OrderByDescending(p => p.BlogID).Where(p => p.CategoryID == 3 && p.Category.CategoryStatus == true).Select(p => p.BlogDate.ToString("dd-MMM-yyyy")).FirstOrDefault();
            var blogpostid3 = bm.GetAll().OrderByDescending(p => p.BlogID).Where(p => p.CategoryID == 3 && p.Category.CategoryStatus == true).Select(P => P.BlogID).FirstOrDefault();
            ViewBag.blogpostid3 = blogpostid3;
            ViewBag.posttitle3 = posttitle3;
            ViewBag.postimage3 = postimage3;
            ViewBag.postdate3 = postdate3;
            //4.post  Seyahat
            var posttitle4 = bm.GetAll().OrderByDescending(p => p.BlogID).Where(p => p.CategoryID == 4 && p.Category.CategoryStatus == true).Select(p => p.BlogTitle).FirstOrDefault();
            var postimage4 = bm.GetAll().OrderByDescending(p => p.BlogID).Where(p => p.CategoryID == 4 && p.Category.CategoryStatus == true).Select(p => p.BlogImage).FirstOrDefault();
            var postdate4 = bm.GetAll().OrderByDescending(p => p.BlogID).Where(p => p.CategoryID == 4 && p.Category.CategoryStatus == true).Select(p => p.BlogDate.ToString("dd-MMM-yyyy")).FirstOrDefault();
            var blogpostid4 = bm.GetAll().OrderByDescending(p => p.BlogID).Where(p => p.CategoryID == 4 && p.Category.CategoryStatus == true).Select(P => P.BlogID).FirstOrDefault();
            ViewBag.blogpostid4 = blogpostid4;
            ViewBag.posttitle4 = posttitle4;
            ViewBag.postimage4 = postimage4;
            ViewBag.postdate4 = postdate4;
            //5.post  Kültür sanat 6. kategoriden çektim
            var posttitle5 = bm.GetAll().OrderByDescending(p => p.BlogID).Where(p => p.CategoryID == 6 && p.Category.CategoryStatus == true).Select(p => p.BlogTitle).FirstOrDefault();
            var postimage5 = bm.GetAll().OrderByDescending(p => p.BlogID).Where(p => p.CategoryID == 6 && p.Category.CategoryStatus == true).Select(p => p.BlogImage).FirstOrDefault();
            var postdate5 = bm.GetAll().OrderByDescending(p => p.BlogID).Where(p => p.CategoryID == 6 && p.Category.CategoryStatus == true).Select(p => p.BlogDate.ToString("dd-MMM-yyyy")).FirstOrDefault();
            var postkategori = bm.GetAll().OrderByDescending(p => p.BlogID).Where(p => p.CategoryID == 6 && p.Category.CategoryStatus == true).Select(p => p.Category.CategoryName).FirstOrDefault();
            var blogpostid6 = bm.GetAll().OrderByDescending(p => p.BlogID).Where(p => p.CategoryID == 6 && p.Category.CategoryStatus == true).Select(P => P.BlogID).FirstOrDefault();
            ViewBag.blogpostid6 = blogpostid6;
            ViewBag.posttitle5 = posttitle5;
            ViewBag.postimage5 = postimage5;
            ViewBag.postdate5 = postdate5;
            ViewBag.postkategori = postkategori;
            return PartialView();
        }
        [AllowAnonymous] //authorize özelligini kapatma
        public PartialViewResult OtherFeaturedPost() //Footer'in ordaki Öne çıkan postlar
        {
            return PartialView();
        }
        [AllowAnonymous] //authorize özelligini kapatma
        public ActionResult BlogDetails()
        {
            return View();
        }
        [AllowAnonymous] //authorize özelligini kapatma
        public PartialViewResult BlogCover(int id)
        {
            var Blogcover = bm.GetBlogByID(id);
            return PartialView(Blogcover);
        }
        [AllowAnonymous] //authorize özelligini kapatma
        public PartialViewResult BlogReadAll(int id)
        {
            var BlogDetailList = bm.GetBlogByID(id);
            return PartialView(BlogDetailList);
        }
        [AllowAnonymous] //authorize özelligini kapatma
        public ActionResult BlogByCategory(int id)
        {
            var BlogListByCategory = bm.GetBlogByCategory(id);
            var CategoryName = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryName).FirstOrDefault();
            var CategoryDescription = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryDescription).FirstOrDefault();
            ViewBag.CategoryDescription = CategoryDescription;
            ViewBag.CategoryName = CategoryName;
            return View(BlogListByCategory);
        }
        //  BLOG Admin Paneli işlemleri   
        public ActionResult AdminBlogList(int sayfa = 1)
        {
            var sorgu = bm.GetAll().ToPagedList(sayfa, 8);
            return View(sorgu);
        }
        public ActionResult AdminBlogList2(int sayfa = 1)
        {
            var sorgu = bm.GetAll().ToPagedList(sayfa, 8);
            return View(sorgu);
        }
        [Authorize(Roles ="A")]
        [HttpGet]
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
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult DeleteBlog(int id)
        {
            bm.DeleteBlogBL(id);
            return RedirectToAction("AdminBlogList");
        }
        [HttpGet]
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
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult GetCommentByBlog(int id)
        {
            CommentManager cm = new CommentManager();
            var commentlist = cm.CommentByBlog(id);
            return View(commentlist);
        }
        public ActionResult AuthorBlogList(int id)
        {
            var blogs = bm.GetBlogByAuthor(id);
            return View(blogs);
        }
    }
}
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager();

        // GET: Comment
        [AllowAnonymous] //authorize özelligini kapatma
        public PartialViewResult CommentList(int id)
        {
            var comlist = cm.CommentByBlog(id);
            return PartialView(comlist);
        }

        [HttpGet]
        [AllowAnonymous] //authorize özelligini kapatma
        public PartialViewResult LeaveComment(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }
        [AllowAnonymous] //authorize özelligini kapatma
        [HttpPost]
        public PartialViewResult LeaveComment(Comment c)
        {
            CommentManager veri = new CommentManager();
            veri.CommentAdd(c);
            return PartialView();
        }
        public ActionResult DeleteComment(int id)
        {
            cm.DeleteCommentBL(id);
            return RedirectToAction("AdminBlogList","Blog");
        }
        //Pasif olmayan yorumları listeleme
        public ActionResult AdminCommentListTrue()
        {
            var commentlist = cm.CommentByStatusTrue();
            return View(commentlist);
        }
        //Pasif olan yorumları listeleme
        public ActionResult AdminCommentListFalse()
        {
            var commentlist = cm.CommentByStatusFalse();
            return View(commentlist);
        }
        //Yorumları pasifleştirme
        public ActionResult StatusChangeToFalse(int id)
        {
            cm.CommentStatusChangeToFalse(id);
            return RedirectToAction("AdminCommentListTrue");
        }
        //Yorumu Aktifleştirme
        public ActionResult StatusChangeToTrue(int id)
        {
            cm.CommentStatusChangeToTrue(id);
            return RedirectToAction("AdminCommentListTrue");
        }

    }
}
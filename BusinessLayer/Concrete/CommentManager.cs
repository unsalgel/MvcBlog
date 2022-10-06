using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{

    public class CommentManager
    {
        Repository<Comment> repocom = new Repository<Comment>();
        //Yorumları Listeleme
        public List<Comment> CommentList()
        {
            return repocom.List(); 
        }
        //Bloga ait yorumu  listeleme
        public List<Comment>CommentByBlog(int id)
        {
            return repocom.List(p=>p.CommentStatus==true && p.BlogID==id);
        }
        // Durumu true olan yorumları listeleyen method.
        public List<Comment> CommentByStatusTrue()
        {
            return repocom.List(p=>p.CommentStatus==true);
        }
        // Durumu False olan yorumları listeleyen method
        public List<Comment> CommentByStatusFalse()  
        {
            return repocom.List(p => p.CommentStatus == false);
        }
        //Yorum Ekleme
        public int CommentAdd(Comment c)
        {
            if (c.CommentText.Length<1 || c.CommentText.Length>=301 || c.UserName==null || c.Mail==null)
            {
                return -1;
            }
            else
            {
                return repocom.Insert(c);
            }
        }
        // Yorumu komple silme
        public int DeleteCommentBL(int id)
        {
            Comment c = repocom.find(p => p.CommentID == id);
            return repocom.Delete(c);
        }
        //Yorumu pasifleştirme
        public int CommentStatusChangeToFalse(int id)
        {
            Comment c = repocom.find(x => x.CommentID == id);
            c.CommentStatus = false;
            return repocom.Update(c);
        }
        //Yorumu Aktifleştirme
        public int CommentStatusChangeToTrue(int id)
        {
            Comment c = repocom.find(x => x.CommentID == id);
            c.CommentStatus = true;
            return repocom.Update(c);
        }
    }
}

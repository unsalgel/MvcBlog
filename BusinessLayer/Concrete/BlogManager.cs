using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager
    {
        Repository<Blog> repoblog = new Repository<Blog>();
        public List<Blog> GetAll()
        {
            return repoblog.List();
        }
        public List<Blog> GetBlogByID(int id)
        {
            return repoblog.List(p => p.BlogID == id);
        }
        public List<Blog> GetAuthorByID(int id)
        {
            return repoblog.List(p => p.AuthorID == id);
        }
        public List<Blog> GetBlogByCategory(int id)
        {
            return repoblog.List(p=>p.CategoryID==id);
        }
        public int BlogAddBL(Blog p)
        {
            if (p.BlogTitle==null || p.BlogImage==null || p.BlogContent==null || p.BlogTitle.Length<5 )
            {
                return -1;
            }
           return repoblog.Insert(p);
        }
      public int DeleteBlogBL(int id)
        {
            Blog b = repoblog.find(p => p.BlogID == id);
            return repoblog.Delete(b);
        }
        public Blog FindBlog(int getid)
        {
            return repoblog.find(p => p.BlogID == getid);
        }
        public int UpdateBlog(Blog p)
        {
            Blog blog = repoblog.find(x=>x.BlogID==p.BlogID);
            blog.BlogTitle = p.BlogTitle;
            blog.CategoryID = p.CategoryID;
            blog.BlogDate = p.BlogDate;
            blog.BlogImage = p.BlogImage;
            blog.AuthorID=p.AuthorID;
            blog.BlogContent = p.BlogContent;
            return repoblog.Update(blog);
        }
        public  List<Blog> GetBlogByAuthor(int id)
        {
            return repoblog.List(p => p.AuthorID == id && p.Category.CategoryStatus==true);

        }
    }
}

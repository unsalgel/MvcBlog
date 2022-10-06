using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    
    public class UserProfileManager
    {
        Repository<Author> repouser = new Repository<Author>();
        Repository<Blog> repouserblog = new Repository<Blog>();
     
        // Mail adresine göre yazar bilgileri getirme
        public List<Author> GetAuthorByMail(string p) //string p mail adresimiz
        {
            return repouser.List(a=>a.Mail==p);
        }
        //Yazara göre blog listesini getirme
        public List<Blog> GetBlogByAuthor(int id)
        {
            return repouserblog.List(p => p.AuthorID == id);
        }

        public int EditAuthor(Author a)
        {
            Author au = repouser.find(p => p.AuthorID == a.AuthorID);
            au.AboutShort = a.AboutShort;
            au.AuthorName = a.AuthorName;
            au.AuthorImage = a.AuthorImage;
            au.AuthorAbout = a.AuthorAbout;
            au.AuthorTitle = a.AuthorTitle;
            au.Mail = a.Mail;
            au.Password = a.Password;
            au.PhoneNumber = a.PhoneNumber;

            return repouser.Update(au); 

        }
    }
}

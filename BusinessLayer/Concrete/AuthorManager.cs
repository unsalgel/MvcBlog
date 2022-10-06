using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthorManager
    {
        //Tüm yazar listesini getirme
        Repository<Author> repoau = new Repository<Author>();
        public List<Author> GetAll()
        {
            return repoau.List();
        }
        // Yeni yazar ekleme işlemi
        public int AddAuthorBL(Author a)
        {  //parametreden gönderilen değerlerin geçerliliğini kontrol etme
            if (a.AuthorName == null || a.AboutShort == null || a.AuthorTitle == null)
            {
                return -1;
            }
            else
            {
                return repoau.Insert(a);
            }   
        }
        // yazarın  id değerine göre edit sayfasına taşıması için
        public Author FindAuthor(int id)
        {
            return repoau.find(p => p.AuthorID == id);
        }
        public int EditAuthor(Author a)
        {
            Author au = repoau.find(p => p.AuthorID == a.AuthorID);
            au.AboutShort = a.AboutShort;
            au.AuthorName = a.AuthorName;
            au.AuthorImage = a.AuthorImage;
            au.AuthorAbout = a.AuthorAbout;
            au.AuthorTitle = a.AuthorTitle;
            au.Mail = a.Mail;
            au.Password = a.Password;
            au.PhoneNumber = a.PhoneNumber;
         
            return repoau.Update(au); 

        }
    }
}

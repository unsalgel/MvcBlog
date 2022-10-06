using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager
    {
        Repository<Contact> Repocontact = new Repository<Contact>();
        public int  BLContactAdd(Contact c)
        {
            if (c.Mail==null || c.Message== null || c.Name== null || c.SurName == null || c.Subject== null || c.Mail.Length<=10)
            {
                return -1;
            }
            return Repocontact.Insert(c);
        }
        public List<Contact> GetAll()
        {
            return Repocontact.List();
        }
        // Admin Paneli Mesaj Detaylarını Getirme 
        public Contact GetContactDetails(int id)
        {
            return Repocontact.find(p=>p.ContactID==id);

        }

    }
}

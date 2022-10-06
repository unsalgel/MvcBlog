using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{

    public class AdminManager
    {
        Repository<Admin> repoadmin = new Repository<Admin>();
        public List<Admin> GetAll()
        {
            return repoadmin.List();
        }
           
        public Admin FindAdmin(int id)
        {
            return repoadmin.find(p=>p.AdminID==id);
        }
        public int EditAdmin(Admin a)
        {
            Admin admin = repoadmin.find(p=>p.AdminID==a.AdminID);
            admin.UserName = a.UserName;
            admin.Password = a.Password;
            return repoadmin.Update(admin);
        }
    }
}

using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager 
    {
        Repository<Category> Repocategory = new Repository<Category>();

       
        public List<Category> GetAll()
        {
            return Repocategory.List();
        }
        public int AdminCategoryAddBL(Category c)
        {
           return  Repocategory.Insert(c);
              
        }
        public int AdminCategoryDeleteBL(int id)
        {
            Category bul = Repocategory.find(p=>p.CategoryID==id);
            return Repocategory.Delete(bul);
        }
        // Kategorinin  id değerine göre edit sayfasına taşıması için
        public Category FindCategory(int id)
        {
           
            return Repocategory.find(p=>p.CategoryID==id);
        }
        public int CategoryEdit(Category ct)
        {
            Category ctg = Repocategory.find(p=>p.CategoryID==ct.CategoryID);
            ctg.CategoryName = ct.CategoryName;
            ctg.CategoryDescription = ct.CategoryDescription;
            return Repocategory.Update(ctg);
            
        }
        //Kategori Pasifleştirme
        public int CategoryStatusChangeToFalse(int id)
        {
            Category ct = Repocategory.find(p => p.CategoryID == id);
            ct.CategoryStatus = false;
            return Repocategory.Update(ct);
        }
        public int CategoryStatusChangeToTrue(int id)
        {
            Category ct = Repocategory.find(p=>p.CategoryID==id);
            ct.CategoryStatus = true;
            return Repocategory.Update(ct);
        }
    }
}

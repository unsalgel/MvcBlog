using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();
        int Insert(T p);
        int Update(T p);
        int Delete(T p);
        T GetByID(int id); //güncellemede kullanılıcak
        List<T> List(Expression<Func<T, bool>> filter); //istedigimiz şarta göre listeleme arama işlemi yapabileceğimiz bir expression methodu
        T find(Expression<Func<T, bool>> where); // silme komutu için kullandıgımız method
    }
}

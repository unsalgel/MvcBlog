using DataAccesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _Object;
        public Repository()
        {
            _Object = c.Set<T>();
        }
        public int Delete(T p)
        {
            _Object.Remove(p);
            return c.SaveChanges();
        }

        public T find(Expression<Func<T, bool>> where)
        {
            return _Object.FirstOrDefault(where);
        }

        public T GetByID(int id)
        {
            return _Object.Find(id);
        }

        public int Insert(T p)
        {
            _Object.Add(p);
            return c.SaveChanges();
        }
        //listeleme

        public List<T> List()
        {
            return _Object.ToList();
        }
        //şartlı listeleme
        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _Object.Where(filter).ToList();
        }

        public int Update(T p)
        {
            return c.SaveChanges();
        }

    }
}

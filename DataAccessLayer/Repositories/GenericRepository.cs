using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<E> : IGenericDal<E> where E : class
    {
        public void Delete(E e)
        {
            using var db = new Context();
            db.Remove(e);
            db.SaveChanges();
        }

        public E GetById(int id)
        {
            using var db = new Context();
            return db.Set<E>().Find(id);
        }

        public List<E> GetList()
        {
            using var db = new Context();
            return db.Set<E>().ToList();
        }

        public void Insert(E e)
        {
            using var db = new Context();
            db.Add(e);
            db.SaveChanges();
        }

        public void Update(E e)
        {
            using var db = new Context();
            db.Update(e);
            db.SaveChanges();
        }
    }
}

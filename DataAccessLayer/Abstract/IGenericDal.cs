using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<E> where E : class
    {
        void Insert(E e);
        void Delete(E e);
        void Update(E e);
        List<E> GetList();
        E GetById(int id);
    }
}

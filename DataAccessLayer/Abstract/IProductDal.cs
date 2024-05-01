using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductListWithCategory();
        List<Product> GetProductsByCategoryId(int id);
        List<Product> SelectedProductItem(int id);
    }
}

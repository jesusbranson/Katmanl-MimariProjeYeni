using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
     public  interface IProductService:IGenericService<Product>
    {
        List<Product> GetProductsListWithCategory();
        List<Product> GetProductsByCategoryId(int id);
        List<Product> SelectedProductItem(int id);
    }
}

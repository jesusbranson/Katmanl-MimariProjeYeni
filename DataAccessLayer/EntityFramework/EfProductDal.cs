using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public List<Product> GetProductListWithCategory()
        {
            using (var c = new Context())
            {
                return c.Products.Include(x => x.Category).ToList();
            }
                
        }

        public List<Product> GetProductsByCategoryId(int id)
        {
            using (var c = new Context())
            {
                return c.Products.Where(x => x.CategoryId == id).ToList();
            }
        }

        public List<Product> SelectedProductItem(int id)
        {
            using (var c = new Context())
            {
                List<Product> productlist = c.Products.Where(p => p.Id == id).ToList();
                return productlist;
            }
        }
    }
}

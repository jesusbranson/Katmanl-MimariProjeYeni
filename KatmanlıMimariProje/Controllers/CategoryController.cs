using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KatmanlıMimariProje.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        ProductManager productManager = new ProductManager(new EfProductDal());

        [HttpGet]
        public IActionResult Index()
        {
            var values = categoryManager.TGetList();
            return View(values);
        }
        public IActionResult DeleteCategory(Category p)
        {
            var products = productManager.GetProductsByCategoryId(p.Id);

            if(products.Any())
            {
                return RedirectToAction("Index");

            }
            var value = categoryManager.TGetByID(p.Id);
            categoryManager.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult AddCategory(Category p1)
        {
            categoryManager.TInsert(p1);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddCategory()
        {

            return View();
        }
    }
}

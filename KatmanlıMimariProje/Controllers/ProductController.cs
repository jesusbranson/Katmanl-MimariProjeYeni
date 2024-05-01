using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KatmanlıMimariProje.Controllers
{
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public IActionResult Index()
        {
            var values = productManager.GetProductsListWithCategory();
            return View(values);


        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            List<SelectListItem> values = (from x in categoryManager.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct1(Product veri)
        {
            Productvalidator validationRules = new Productvalidator();
            ValidationResult results = validationRules.Validate(veri);
            if (results.IsValid)
            {
                productManager.TInsert(veri);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }

        public IActionResult DeleteProduct(Product veri)
        {
            int valueFind = veri.Id;
            var value = productManager.TGetByID(valueFind);
            productManager.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var value = productManager.TGetByID(id);
            TempData["productID"] = id;
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product veri)
        {
            Productvalidator validationRules = new Productvalidator();
            ValidationResult results = validationRules.Validate(veri);
            var ProductId = TempData["ProductID"] as int?;

            if (ProductId != null)
            {
                if (veri.Id == ProductId && results.IsValid)
                {

                    productManager.TUpdate(veri);
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }

                }
            }


            return View();
        }
    }
}

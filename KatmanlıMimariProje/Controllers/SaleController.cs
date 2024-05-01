using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using KatmanlıMimariProje.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace KatmanlıMimariProje.Controllers
{
    public class SaleController : Controller
    {
        SaleManager saleManager = new SaleManager(new EfSaleDal());
        ProductManager productManager = new ProductManager(new EfProductDal());
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

        public IActionResult Index()
        {
            var values = saleManager.GetSalesListWithProductCustomer();
            return View(values);
        }
        [HttpGet]
        public IActionResult SaleProduct(int id)
        {

            var values = productManager.TGetByID(id);
            var viewModel1 = ConvertToSaleProductCustomViewModel(values); 
            List<SelectListItem> values1 = (from x in customerManager.TGetList()
                                            select new SelectListItem
                                           {
                                               Text = x.Name,
                                                Value = x.ID.ToString()

                                            }).ToList();

            List<SelectListItem> values2 = (from x in productManager.SelectedProductItem(id)
                                            select new SelectListItem
                                            {
                                                Text = x.Name,
                                                Value = x.Id.ToString()

                                            }).ToList();

            
            ViewBag.v3 = values2;

            ViewBag.v2 = values1;

            

            TempData["SatılacakÜrünID"] = values.Id;


            HttpContext.Session.SetString("Price", values.Price.ToString());

            
            





            return View(viewModel1);
        }
        [HttpPost]
        public IActionResult SaleProduct1(Sale p1)
        {
            int? SatısÜrünID = TempData["SatılacakÜrünID"] as int?;
            
            decimal price = decimal.Parse(HttpContext.Session.GetString("Price"));

            SaleValidator validationRules = new SaleValidator();
            ValidationResult results = validationRules.Validate(p1);

             decimal TotalPrice = p1.Quantity * p1.Price;

            p1.TotalPrice = TotalPrice;

            if (p1.ProductID == SatısÜrünID  && p1.Price == price)
            {
                
                    saleManager.TInsert(p1);


                return RedirectToAction("Index");
            }

            return View();
        }

        public SaleProductCustomerViewModel ConvertToSaleProductCustomViewModel(Product product)
        {
            
            SaleProductCustomerViewModel viewModel = new SaleProductCustomerViewModel
            {
                

                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
               
            };

            return viewModel;
        }
    }
}

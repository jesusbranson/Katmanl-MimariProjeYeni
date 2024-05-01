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
    public class CustomerController : Controller
    {
        CustomerManager CustomerManager = new CustomerManager(new EfCustomerDal());
        JobManager jobManager = new JobManager(new EfJobDal());

        public IActionResult Index()
        {
            var values = CustomerManager.GetCustomersListWithJob();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {
           
            List<SelectListItem> values = (from x in jobManager.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.JobID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer p)
        {
            CustomerValidator customerValidator = new CustomerValidator();
            ValidationResult result = customerValidator.Validate(p);
            if (result.IsValid)
            {
                CustomerManager.TInsert(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                

            }
                return View();

        }
        public IActionResult DeleteCustomer(Customer p)
        {
            var value = CustomerManager.TGetByID(p.ID);
            CustomerManager.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            List<SelectListItem> values1 = (from x in jobManager.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.JobID.ToString()
                                           }).ToList();
            ViewBag.v1 = values1;
            var values = CustomerManager.TGetByID(id);
            TempData["customerID"] = id;
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer p)
        {

            CustomerValidator customerValidator = new CustomerValidator();
            ValidationResult result = customerValidator.Validate(p);
            var CustomerID = TempData["customerID"] as int?;
            if (CustomerID != null)
            {

                if (p.ID == CustomerID && result.IsValid)
                {

                    CustomerManager.TUpdate(p);
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                       ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                        

                    }

                }
            }
            return View();

        }
    }
}

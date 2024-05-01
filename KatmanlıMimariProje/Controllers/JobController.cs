using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KatmanlıMimariProje.Controllers
{
    public class JobController : Controller
    {

        JobManager jobManager = new JobManager(new EfJobDal());
        public IActionResult Index()
        {
            var values = jobManager.TGetList();
            return View(values);


        }
        [HttpGet]
        public IActionResult AddJob()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddJob(Job veri)
        {
            JobValidator validationRules = new JobValidator();
            ValidationResult results = validationRules.Validate(veri);
            if (results.IsValid)
            {
                jobManager.TInsert(veri);
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

        public IActionResult DeleteJob(Job veri)
        {
            int valueFind = veri.JobID;
            var value = jobManager.TGetByID(valueFind);
            jobManager.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateJob(int id)
        {
            var value = jobManager.TGetByID(id);
            TempData["JobID"] = id;
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateJob(Job veri)
        {
            JobValidator validationRules = new JobValidator();
            ValidationResult results = validationRules.Validate(veri);
            var JobID = TempData["JobID"] as int?;

            if (JobID != null)
            {
                if (veri.JobID == JobID && results.IsValid)
                {

                    jobManager.TUpdate(veri);
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

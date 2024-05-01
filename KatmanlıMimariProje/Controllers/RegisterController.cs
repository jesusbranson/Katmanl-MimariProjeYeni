

using EntityLayer.Concrete;

using KatmanlıMimariProje.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KatmanlıMimariProje.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel veri)
        {
            AppUser appUser = new AppUser()
            {
                Name = veri.Name,
                Surname = veri.SurName,
                UserName = veri.UserName,
                Email = veri.Email 

            };
            
            
            if (veri.Password == veri.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser,veri.Password);

                if(result.Succeeded)
                {

                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }
            }
            return View(veri);
        }
    }
}

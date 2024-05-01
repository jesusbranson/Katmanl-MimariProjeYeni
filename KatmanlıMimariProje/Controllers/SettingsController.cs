using EntityLayer.Concrete;
using KatmanlıMimariProje.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KatmanlıMimariProje.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values =  await _userManager.FindByNameAsync(User.Identity.Name); //sisteme Bağlanan Kullanıcının adından bul
            UserEditViewModel userEditViewModel = new UserEditViewModel();

            userEditViewModel.Name = values.Name;
            userEditViewModel.SurName = values.Surname;
            userEditViewModel.Email = values.Email;
            

            return View(userEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name); //sisteme Bağlanan Kullanıcının adından bul

            values.Name = p.Name;
            values.Surname = p.SurName;
            values.Email = p.Email;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values,p.Password);
            var result = await _userManager.UpdateAsync(values);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Product");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            
            


            
        }

    }
}

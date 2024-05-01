using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KatmanlıMimariProje.Controllers._ViewComponents
{
    [ViewComponent(Name = "_UILayout")]
    public class _UILayoutViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _UILayoutViewComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                return View("Default",user);
            }
            return View();
        }
    }
}

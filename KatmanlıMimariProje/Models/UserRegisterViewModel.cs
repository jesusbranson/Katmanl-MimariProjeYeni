using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace KatmanlıMimariProje.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage ="Lütfen İsim Giriniz")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Lütfen Soyad Giriniz")]
        public string SurName { get; set; }


        [Required(ErrorMessage = "Lütfen Kullanıc Adı Giriniz")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Lütfen Şifre Giriniz")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Lütfen Mail Giriniz")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Lütfen Mail Giriniz")]
        [Compare("Password",ErrorMessage ="Lütfen Şifrelerin Eşleştiğinden Emin olun.")]
        public string ConfirmPassword { get; set; }
    }
}

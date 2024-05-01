using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.FluentValidation
{
    public class Productvalidator : AbstractValidator<Product>
    {
        public Productvalidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ürün Adını Boş Geçemezsiniz.");


            RuleFor(x => x.Price);



            RuleFor(x => x.Stock);

            RuleFor(x => x.CategoryId);








        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using EntityLayer.Concrete;

namespace BusinessLayer.FluentValidation
{
    public class SaleValidator: AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(x => x.Price);
            RuleFor(x => x.ProductID);
            RuleFor(x => x.Quantity);
            RuleFor(x => x.CustomerID);


        }
    }
}

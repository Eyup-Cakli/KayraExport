using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductStatusId).NotEmpty();

            RuleFor(p => p.ProductStatusName).NotEmpty();
            RuleFor(p => p.ProductStatusName).MinimumLength(1);
        }
    }
}

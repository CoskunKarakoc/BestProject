using Best.Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Best.BusinessLayer.ValidationRules.FluentValidation
{
    //install-package fluentvalidation
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.CategoryId).NotEmpty();//RuleFor(p => p.CategoryId).NotEmpty().WithMessage("CategoryId boş geçilemez");=>Client'ın diline göre mesajları otomatik çeviriyor.
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.ProductName).Length(2, 20);
            //RuleFor(p => p.ProductName).Must(startwithA); misal :))


        }

        /* private bool startwithA(string arg)
            {
                return arg.StartsWith("A");
            }
        */
    }
}

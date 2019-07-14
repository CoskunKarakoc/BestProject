using Best.Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Best.BusinessLayer.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {

        public UserValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.UserName).NotEmpty();
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.Password).Length(2, 50).NotEmpty();
            RuleFor(p => p.Email).NotEmpty().Length(100).EmailAddress();

        }
    }
}
